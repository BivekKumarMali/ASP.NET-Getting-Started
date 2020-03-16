using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assginment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assginment.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().HasData(new Comment {id=1 ,User = "Raju", comment = "I don't" });
            modelBuilder.Entity<Comment>().HasData(new Comment {id =2, User = "Raju", comment = "I don" });
            modelBuilder.Entity<Comment>().HasData(new Comment {id=3, User = "Raja", comment = "I" });

           
            modelBuilder.Entity<Post>().HasData(new Post
            {id =1, Users = "Raju", Message = "I Love Coding", Like = 5 });

            modelBuilder.Entity<Post>().HasData(new Post
            {id=2, Users = "Raj", Message = "I Coding for Life", Like = 2 });

            
        }
    }
}
