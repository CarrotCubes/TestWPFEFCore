using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;

namespace TestWPFEFCore.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IRespository<TEntity> respository;
        public BaseService(IRespository<TEntity> _respository)
        {
            respository = _respository;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return respository.BeginTransaction();
        }

        public void CommitTransaction()
        {
            respository.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            respository.RollbackTransaction();
        }

        public async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null,
                                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                             bool disableTracking = true,
                                             bool ignoreQueryFilters = false)
        {
            return await respository.GetFirstOrDefaultAsync(predicate: predicate,
                        orderBy: orderBy,
                        include: include,
                        disableTracking: disableTracking,
                        ignoreQueryFilters: ignoreQueryFilters);

        }

        public TEntity? GetFirst(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         bool disableTracking = true,
                                         bool ignoreQueryFilters = false)
        {
            return respository.GetFirstOrDefault(predicate: predicate,
                        orderBy: orderBy,
                        include: include,
                        disableTracking: disableTracking,
                        ignoreQueryFilters: ignoreQueryFilters);

        }

        public async Task<List<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         bool disableTracking = true,
                                         bool ignoreQueryFilters = false)
        {
            return await respository.GetAllAsync(predicate: predicate,
                orderBy: orderBy,
                include: include,
                disableTracking: disableTracking,
                ignoreQueryFilters: ignoreQueryFilters);
        }

        public int Add(TEntity entity) => respository.Add(entity);

        public Task<int> AddAsync(TEntity entity) => respository.AddAsync(entity);

        public int Update(TEntity entity) => respository.Update(entity);

        public Task<int> UpdateAsync(TEntity entity) => respository.UpdateAsync(entity);
    }
}
