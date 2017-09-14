using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolishProgramer.Models
{
    public class PostContentDB : DbContext
    {
        public PostContentDB(DbContextOptions<PostContentDB> options) : base(options)
        {
        }

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<BlogPostCategory> CategoryPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().ToTable("Posts");
            modelBuilder.Entity<BlogPostCategory>().ToTable("CategoryOfPosts");
        }
    }
}
