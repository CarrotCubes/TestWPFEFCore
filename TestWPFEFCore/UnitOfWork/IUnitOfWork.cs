using System;
using System.Collections.Generic;
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
        public DbContext GetDbContext();
        public IRespository<TEntity> GetRespository<TEntity>() where TEntity : class;
    }
}
