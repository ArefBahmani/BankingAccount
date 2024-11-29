using BankingAccount.DbContexts;
using BankingAccount.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BankingAccount.Entites;

namespace BankingAccount.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankDbContext _context;

        public TransactionRepository(BankDbContext context)
        {
            _context = context;
        }


        public void AddTransaction(Entites.Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public List<Entites.Transaction> GetTransactionsByCardNumber(string cardNumber)
        {
            return _context.Transactions
                .Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber)
                .ToList();
        }

    }
}
