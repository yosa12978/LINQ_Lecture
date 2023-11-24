using EntityManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManager.Data
{
    public class ArticleContext : DbContext
    {
        public ArticleContext()
        {

        }

        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=articles.db");
            //=> optionsBuilder.UseInMemoryDatabase("exampledb");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>().HasKey(x => x.Id);
        }

        public DbSet<Article> Articles { get; set; } = default!;
    }
}
