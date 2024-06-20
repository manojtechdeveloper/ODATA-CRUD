using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.Entities;

namespace ProductManagement.Repository.ProductDbContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts {  get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Transaction>().HasOne(t => t.Account)
            //    .WithMany(a => a.Transactions)
            //    .HasForeignKey(t=> t.TransactionId);
            //base.OnModelCreating(modelBuilder);
        }



    }
}
