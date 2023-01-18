﻿using JWTApp.Core.Application.Interfaces;
using JWTApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWTApp.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext _jwtContext;

        public Repository(JwtContext jwtContext)
        {
            _jwtContext = jwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this._jwtContext.Set<T>().AddAsync(entity);
            await this._jwtContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._jwtContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this._jwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await this._jwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
             this._jwtContext.Set<T>().Remove(entity);
            await this._jwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this._jwtContext.Set<T>().Update(entity);
            await this._jwtContext.SaveChangesAsync();
        }
    }
}
