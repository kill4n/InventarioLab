using InventarioAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventarioAPI.Reposotory
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private InventarioContext _context;
        private DbSet<TEntity> _dbSet;
        public Repository(InventarioContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _context.Database.EnsureCreated();
        }
        public void Add(TEntity data)
        {
            _dbSet.Add(data);
        }
        public void Delete(long id)
        {
            TEntity dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }
        public TEntity Get(long id)
        {
            return _dbSet.Find(id);
        }
        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
