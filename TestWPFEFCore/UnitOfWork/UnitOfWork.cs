using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestWPFEFCore.Context;
using TestWPFEFCore.Repository;

namespace TestWPFEFCore.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _dbContext;
        public UnitOfWork(TContext context)
        {
            _dbContext = context;
        }

        public IRespository<TEntity> GetRespository<TEntity>() where TEntity : class
        {
            return _dbContext.GetService<IRespository<TEntity>>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public TDbContext? GetDbContext<TDbContext>() where TDbContext : DbContext
        {
            return _dbContext as TDbContext;
        }
    }
}
