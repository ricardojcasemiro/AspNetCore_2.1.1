using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
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
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public ViewResult Index()
        {
            //var data = _ctx.Produtos
            //                //.Skip(2).Take(2)  // carrega apenas 10 itens -> paginação
            //                // Include("Categoria")            
            //                .Include(p => p.Categoria)
            //                .ToList();

            var data = _produtoRepository.Get();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            Produto produto = null;

            if (id != null)
            {

                produto = _produtoRepository.Get(id);
            }

            // trafaga a informação de view pra view ou view pra controle uma única vez
            ViewBag.Categorias = _categoriaRepository.Get()
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

            var msg = $"Produto {produto.Nome} ";

            if (produto.Id == 0)
            {
                _produtoRepository.Add(produto);
                msg += "adicionado ";
            }
            else
            {
                _produtoRepository.Update(produto);
                msg += "atualizado ";
            }

            msg += "com sucesso!";
            TempData["msg"] = msg;

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var produto = _produtoRepository.Get(id);

            if (produto == null)
            {
                return BadRequest("Esse cara não existe");
            }

            _produtoRepository.Delete(produto);

            return Ok(); // devolve um tipo sucesso no status
        }

    }
}
