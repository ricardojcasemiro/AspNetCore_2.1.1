﻿using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(StoreDataContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Produto> GetByName(string contains)
        {
            throw new NotImplementedException();
        }
    }
}
