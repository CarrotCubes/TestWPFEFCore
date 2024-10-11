using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWPFEFCore.Context;
using TestWPFEFCore.Repository;

namespace TestWPFEFCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public TContext GetDbContext<TContext>() where TContext : DbContext;

        public IRespository<TEntity> GetRespository<TEntity>() where TEntity : class;

        DbConnection GetDbConnection();

        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}
