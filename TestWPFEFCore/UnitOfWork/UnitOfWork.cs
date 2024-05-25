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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(WPFDBContext context)
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

        public DbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}
