using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Data.Cart;
using TheOnlineBookStore.Models;

namespace TheOnlineBookStore.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorsAndBooks>().HasKey(ab => new
            {
                ab.AuthorID,
                ab.BookID
            });

            modelBuilder.Entity<AuthorsAndBooks>().HasOne(a => a.Author).WithMany(ab => ab.Books).HasForeignKey(athb => athb.BookID);
            modelBuilder.Entity<AuthorsAndBooks>().HasOne(a => a.Book).WithMany(ab => ab.Authors).HasForeignKey(athb => athb.AuthorID);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<AuthorsAndBooks> Authors_Books { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
