using CadCli.Data;
using CadCli.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Controllers
{
    public class ClientesController: Controller
    {
        private CadCliDataContext _ctx = new CadCliDataContext();

        public ViewResult Index()
        {
            //var clientes = new List<Cliente>() {
            //    new Cliente() { Id = 1, Nome = "Ricardo", Idade = 43 },
            //    new Cliente() { Id = 2, Nome = "Priscila", Idade = 42 },
            //    new Cliente() { Id = 3, Nome = "Raphael", Idade = 41 },
            //    new Cliente() { Id = 4, Nome = "Isral", Idade = 40 },
            //    new Cliente() { Id = 5, Nome = "Nair", Idade = 39 }
            //};

            var clientes = _ctx.Clientes.ToList();

            return View(clientes);
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Cliente cli)
        {
            _ctx.Clientes.Add(cli);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
