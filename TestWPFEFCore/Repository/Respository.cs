using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using TestWPFEFCore.Context;
using TestWPFEFCore.UnitOfWork;

namespace TestWPFEFCore.Repository
{
    public class Respository<TEntity> : IRespository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        private readonly DbSet<TEntity> _entities;

        private readonly IUnitOfWork _unitOfWork;

        private DbConnection _connection;

        public Respository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbContext = unitOfWork.GetDbContext<DbContext>();
            _connection = unitOfWork.GetDbConnection();
            _entities = _dbContext?.Set<TEntity>();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(
                                            Expression<Func<TEntity, bool>> predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                            bool disableTracking = true,
                                            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

        public TEntity? GetFirstOrDefault(
                                            Expression<Func<TEntity, bool>> predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                            bool disableTracking = true,
                                            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public async Task<List<TEntity>?> GetAllAsync(
                                          Expression<Func<TEntity, bool>> predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool disableTracking = true,
                                          bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public int Add(TEntity entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(TEntity entity)
        {
            _dbContext.AddAsync(entity);
            return _dbContext.SaveChangesAsync();
        }

        public int Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
