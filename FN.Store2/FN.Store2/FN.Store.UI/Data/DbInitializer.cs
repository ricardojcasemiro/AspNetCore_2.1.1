using FN.Store.UI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Data
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Alimento" },
                new Categoria { Id = 2, Nome = "Higiene" },
                new Categoria { Id = 3, Nome = "Papelaria" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto() { Id = 1, Nome = "Picanha", Preco = 80.5M, CategoriaId = 1 },
                new Produto() { Id = 2, Nome = "Danone", Preco = 9.5M, CategoriaId = 1 },
                new Produto() { Id = 3, Nome = "Fralda Pampers", Preco = 50.5M, CategoriaId = 2 },
                new Produto() { Id = 4, Nome = "Pasta de Dente", Preco = 10.99M, CategoriaId = 2 },
                new Produto() { Id = 5, Nome = "Caneta Bic", Preco = 8.99M, CategoriaId = 3 }
            );
        }
    }
}
