using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWPFEFCore.Entity;

namespace TestWPFEFCore.Context
{
    public class WPFDBContext : DbContext
    {
        //public WPFDBContext(DbContextOptions<WPFDBContext> dbContextOptions) : base(dbContextOptions)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=localhost;port=3306;Initial Catalog=yqyc;User=root;Password=root;sslMode=None";
            optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(5, 7, 37)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CarInfo>().HasNoKey();
        }

        public DbSet<CarInfo> CarInfo { get; set; }
    }
}
