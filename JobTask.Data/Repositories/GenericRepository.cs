﻿using JobTask.Data.DbContexts;
using JobTask.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Data.Repositories
{
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : class
    {
        protected readonly JobTaskDbContext dbContext;
        protected readonly DbSet<TSource> dbSet;

        public GenericRepository(JobTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TSource>();
        }

        public async ValueTask<TSource> AddAsync(TSource entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public void Delete(TSource entity)
            => dbSet.Remove(entity);

        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            IQueryable<TSource> query = expression is null ? dbSet : dbSet.Where(expression);

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public async ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string[] includes = null)
            => await GetAll(expression, includes).FirstOrDefaultAsync();

        public TSource Update(TSource entity)
            => dbSet.Update(entity).Entity;

        public async ValueTask SaveChangesAsync()
            => await dbContext.SaveChangesAsync();
    }
}