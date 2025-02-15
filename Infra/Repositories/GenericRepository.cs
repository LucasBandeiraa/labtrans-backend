﻿ using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Kognit.Infra.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly ApplicationDbContext _context;

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllUsersWallets(int userId)
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
