using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UserApiControlerAvi.Models;

namespace UserApiControlerAvi.Data
{
    public class UserApiControlerAviContext : DbContext
    {
        public UserApiControlerAviContext (DbContextOptions<UserApiControlerAviContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Group> Groups { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder mb) 
        {
            mb.Entity<User>()
                .HasMany(e => e.Groups)
                .WithMany(e => e.Users);
            

            mb.Entity<Group>()
                .HasMany(t => t.Transactions)
                .WithOne(t => t.Group)
                .HasForeignKey(t => t.GroupId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Transaction>()
                .HasMany(e => e.Payments)
                .WithOne(e => e.Transaction)
                .HasForeignKey(e => e.TransactionId);

            mb.Entity<Payment>()
                .HasOne(e => e.User)
                .WithMany(e => e.Payments);
            

        }
    }
}
