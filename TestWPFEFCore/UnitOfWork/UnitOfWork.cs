using System;
using System.Collections.Generic;
using System.Data.Common;
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

        private DbConnection _connection;

        public UnitOfWork(TContext context)
        {
            _dbContext = context;
            _connection = _dbContext.Database.GetDbConnection();
        }

        public IRespository<TEntity> GetRespository<TEntity>() where TEntity : class
        {
            return _dbContext.GetService<IRespository<TEntity>>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext
        {
            return _dbContext as TDbContext;
        }

        public DbConnection GetDbConnection()
        {
            return _dbContext.Database.GetDbConnection();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
