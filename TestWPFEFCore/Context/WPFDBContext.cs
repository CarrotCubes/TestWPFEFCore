using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShardingCore.Sharding;
using ShardingCore.Sharding.Abstractions;
using TestWPFEFCore.Entity;

namespace TestWPFEFCore.Context
{
    public class WPFDBContext : DbContext
    {
        public WPFDBContext(DbContextOptions<WPFDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //    optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(5, 7, 37)));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CarInfo>().HasNoKey();

            //modelBuilder.Entity<CarInfo>()
            //            .HasMany(c => c.UploadFiles)
            //            .WithOne(u => u.CarInfo)
            //            .HasForeignKey(u => u.CarId)
            //            .HasPrincipalKey(c => c.Id)
            //            .IsRequired();

            //modelBuilder.Entity<UploadFile>()
            //            .HasOne(u => u.CarInfo)
            //            .WithMany(c => c.UploadFiles)
            //            .HasPrincipalKey(c => c.Id)
            //            .HasForeignKey("CarId")
            //            .IsRequired();

            modelBuilder.Entity<CarInfo>()
                       .HasOne(c => c.UploadFile)
                       .WithOne(u => u.CarInfo)
                       .HasForeignKey<UploadFile>("CarId")
                       .IsRequired();
        }

        public DbSet<CarInfo>? CarInfo { get; set; }

        public DbSet<UploadFile> UploadFile { get; set; }
    }
}
