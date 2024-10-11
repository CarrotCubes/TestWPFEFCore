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

namespace TestWPFEFCore.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null,
                                     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                     Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                     bool disableTracking = true,
                                     bool ignoreQueryFilters = false);

        TEntity? GetFirst(Expression<Func<TEntity, bool>> predicate = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                bool disableTracking = true,
                                bool ignoreQueryFilters = false);

        Task<List<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                    bool disableTracking = true,
                                    bool ignoreQueryFilters = false);

        int Add(TEntity entity);

        Task<int> AddAsync(TEntity entity);

        int Update(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);
    }
}
