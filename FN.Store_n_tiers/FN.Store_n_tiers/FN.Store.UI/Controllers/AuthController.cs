using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Helpers;
using FN.Store.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class AuthController: Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public IActionResult SignIn(SignInVM model)
        {

            var usuario = _usuarioRepository.GetByEmail(model.Email);

            if (usuario == null)
            {
                ModelState.AddModelError("Email", "Email não cadastrado");
            }
            else
            {
                if (model.Senha.Encrypt() != usuario.Senha) ModelState.AddModelError("Senha", "Senha inválida");
            }

            if (ModelState.IsValid)
            { 
                // gerar o cookie de autenticação
                var claims = new List<Claim>()
                {
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("nome", usuario.Nome),
                    new Claim("email", model.Email),
                    new Claim("perfis", string.Join(',', new string[]{"admin", "ti"}))
                };
                // vai ser encapsulado dentro de um cookie
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "email", "perfis");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);

                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Produtos");
            }

            ModelState.AddModelError("Email", "usuário ou senha inválidos");
            

            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("SignIn");
        }
    }
}
