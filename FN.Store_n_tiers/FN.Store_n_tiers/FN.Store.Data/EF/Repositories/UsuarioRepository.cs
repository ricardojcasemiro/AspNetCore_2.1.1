﻿using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(StoreDataContext ctx) : base(ctx)
        {

        }

        public Usuario GetByEmail(string email)
        {
            return _db.FirstOrDefault(u => u.Email == email);
        }
    }
}
