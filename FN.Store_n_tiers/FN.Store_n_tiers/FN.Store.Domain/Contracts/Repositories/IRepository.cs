﻿using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity: Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IEnumerable<TEntity> Get();
        TEntity Get(object id);
    }
}
