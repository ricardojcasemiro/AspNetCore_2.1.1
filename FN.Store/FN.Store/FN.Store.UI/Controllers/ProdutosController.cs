using FN.Store.UI.Data;
using FN.Store.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class ProdutosController: Controller
    {
        public ProdutosController(IDataContext ctx)
        {
            _ctx = ctx;
        }

        private IDataContext _ctx;

        public ViewResult Index()
        {
            var data = _ctx.Produtos.ToList();

            return View(data);
        }
    }
}
