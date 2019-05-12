using FN.Store.UI.Data;
using FN.Store.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly StoreDataContext _ctx;

        public ProdutosController(IConfiguration config)
        {
            _ctx = new StoreDataContext(config);
        }

        public ViewResult Index()
        {
            var data = _ctx.Produtos
                            //.Skip(2).Take(2)  // carrega apenas 10 itens -> paginação
                            // Include("Categoria")            
                            .Include(p => p.Categoria)
                            .ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            Produto produto = null;

            if (id != null)
            {

                produto = _ctx.Produtos.Find(id);
            }

            ViewBag.Categorias = _ctx.Categorias.ToList()
                                    .Select(c => new SelectListItem {
                                        Value = c.Id.ToString(),
                                        Text = c.Nome
                                    });

            return View(produto);
        }

        [HttpPost]
        //public IActionResult Save(Produto produto)
        public IActionResult AddEdit(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (produto.Id == 0)
            {
                _ctx.Produtos.Add(produto);
            }
            else
            {
                _ctx.Update(produto);
            }

            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var produto = _ctx.Produtos.Find(id);

            if (produto == null)
            {
                return BadRequest("Esse cara não existe");
            }

            _ctx.Produtos.Remove(produto);
            _ctx.SaveChanges();

            return Ok(); // devolve um tipo sucesso no status
        }

    }
}
