using BankingAccount.ConectionSQL;
using BankingAccount.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount.DbContexts
{
    public class BankDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasKey(c => c.CardId);
            modelBuilder.Entity<Transaction>().HasKey(c => c.TransactionId);
            modelBuilder.Entity<Transaction>().HasOne(x=>x.Card).WithMany(y=>y.Transactions).HasForeignKey(x=>x.TransactionId);
            modelBuilder.Entity<Transaction>().Property(x=>x.SourceCardNumber).IsRequired();
            modelBuilder.Entity<Transaction>().Property(x => x.DestinationCardNumber).IsRequired();



            modelBuilder.Entity<Card>().HasData(new Card
            {
                CardId = 1,
                CardNumber = "5859831062637730",
                HolderName = "Aref",
                Balance = 1000
            ,
                Password = "1111",
                TransactionLimit = 250,
                FailedCount = 0
            });
            modelBuilder.Entity<Card>().HasData(new Card
            {
                CardId = 2,
                CardNumber = "603731727505569",
                HolderName = "ali",
                Balance = 1000
           ,
                Password = "1111",
                TransactionLimit = 250,
                FailedCount = 0
            });

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
