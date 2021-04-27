using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using bookbookiev11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace bookbookiev11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookModel> BookModel { get; set; }
        public DbSet<ShoppingCartItem> cartItems { get; set; }
    }
}
