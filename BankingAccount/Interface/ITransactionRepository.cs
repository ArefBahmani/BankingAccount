using BankingAccount.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingAccount.Interface
{
    public interface ITransactionRepository
    {
        public void AddTransaction(Entites.Transaction transaction);

        public List<Entites.Transaction> GetTransactionsByCardNumber(string cardNumber);
    }
}
