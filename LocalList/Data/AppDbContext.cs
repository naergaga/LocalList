using LocalList.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Project 的 Name 唯一
            modelBuilder.Entity<Project>().HasAlternateKey(t=>t.Name);
        }

        public DbSet<Project> Project { get; set; }
    }
}
