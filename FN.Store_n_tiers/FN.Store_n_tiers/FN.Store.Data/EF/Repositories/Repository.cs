using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly StoreDataContext _ctx;
        protected readonly DbSet<TEntity> _db;

        public Repository(StoreDataContext ctx)
        {
            _ctx = ctx;
            _db = ctx.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
            _ctx.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
            _ctx.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return _db.ToList();
        }

        public TEntity Get(object id)
        {
            return _db.Find(id);
        }

        public void Update(TEntity entity)
        {
            _db.Update(entity);
            _ctx.SaveChanges();
        }
    }
}
