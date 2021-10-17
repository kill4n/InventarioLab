using InventarioAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task Add(TEntity data)
        {
            await _dbSet.AddAsync(data);
        }
        public void Delete(long id)
        {
            TEntity dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }
        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> Get(long id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
