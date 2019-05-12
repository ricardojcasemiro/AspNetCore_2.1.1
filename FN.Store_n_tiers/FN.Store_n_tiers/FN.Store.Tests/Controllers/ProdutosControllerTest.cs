using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using FN.Store.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Tests.Controllers
{
    [TestClass]
    [TestCategory("ProdutosController")]
    public class ProdutosControllerTest
    {
        // Dado um ProdutosController

        [TestMethod]
        public void OMetodoIndexDeveRetornarUmaViewComProdutos()
        {
            // arrange
            var produtoCtrl = new ProdutosController(new ProdutoRepository(), new CategoriaRepository());

            // action
            var result = produtoCtrl.Index();
            var model = result.Model as IEnumerable<Produto>; // cast pra uma lista de produtos

            // assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            Assert.IsNotNull(model);
        }
    }

    public class ProdutoRepository : IProdutoRepository
    {
        public void Add(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Produto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            return new List<Produto> { }; // Para simular uma lista de produtos vindo do anco de dados
        }

        public Produto Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetByName(string contains)
        {
            throw new NotImplementedException();
        }

        public void Update(Produto entity)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoriaRepository : ICategoriaRepository
    {
        public void Add(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Get()
        {
            throw new NotImplementedException();
        }

        public Categoria Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
