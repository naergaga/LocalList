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
            modelBuilder.Entity<Project>().HasIndex(t=>t.Name).IsUnique();
            //ProjectTag key
            modelBuilder.Entity<ProjectTag>().HasKey(t => new { t.ProjectId, t.TagId });
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ProjectTag> ProjectTag { get; set; }
    }
}
