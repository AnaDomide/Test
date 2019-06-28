using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.Models
{
    public class MoviesDbContext : DbContext

    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();
            });

            builder.Entity<Comment>()
               .HasOne(c => c.Movie)
               .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Comment>()
                .HasOne(c => c.AddedBy)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);

        //    //TODo: daca crapa la stergere in cascada cu User owner
        //    //builder.Entity<Film>()
        //    //   .HasOne(f => f.Owner)
        //    //   .WithMany(u => u.Filme)
        //    //   .OnDelete(DeleteBehavior.Cascade);

         }


         public DbSet<Movie> Movies { get; set; }

         public DbSet<Comment> Comments { get; set; }

          public DbSet<User> Users { get; set; }

          public DbSet<UserRole> UserRoles { get; set; }

          public DbSet<UserUserRole> UserUserRoles { get; set; }



    }
  }

