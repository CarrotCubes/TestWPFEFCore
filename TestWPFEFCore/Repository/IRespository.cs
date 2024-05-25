using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace TestWPFEFCore.Repository
{
    public interface IRespository<TEntity> where TEntity : class
    {
        public Task<TEntity?> GetFirstOrDefaultAsync(
                                                    Expression<Func<TEntity, bool>> predicate = null,
                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                    bool disableTracking = true,
                                                    bool ignoreQueryFilters = false);
    }
}
