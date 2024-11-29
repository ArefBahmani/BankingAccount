using BankingAccount.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingAccount.Services
{
    public class CardService
    {
        public string Transaction(string sourceCard, string targetCard, float amount, string passWord)
        {
            var context = new BankDbContext();
            if (sourceCard.Length != 16 || targetCard.Length != 16)
            {
                return "Your card number must be 16 number";
            }
            if (amount == 0)
            {
                return "amount cant be zero";
            }
            var sourcCard = context.Cards.SingleOrDefault(c => c.CardNumber == sourceCard);
            var destinationCard = context.Cards.SingleOrDefault(c => c.CardNumber == targetCard);
            if (sourceCard == null || destinationCard == null)
            {
                return "card number is not true";
            }
            if (!sourcCard.IsActive)
            {
                return "source card is block";
            }
            if (sourcCard.Password != passWord)
            {
                sourcCard.FailedCount++;
                if (sourcCard.FailedCount >= 3)
                {
                    sourcCard.IsActive = false;
                    context.SaveChanges();
                    return "Card Is Blocked.";
                }
                context.SaveChanges();
                return "Password is not valid.";
            }
            if (sourcCard.Balance < amount)
            {
                return "Not Have Balance.";
            }
          
            
            sourcCard.Balance -= amount;
            destinationCard.Balance += amount;
           
            Entites.Transaction transaction = new Entites.Transaction();
            {
                
               

            };
            context.Transactions.Add(transaction);
            context.SaveChanges();
            return "transaction is succsessfully.";
        }
        public List<Entites.Transaction> GetTransactions(string cardNumber)
        {
             var context = new BankDbContext();

            return context.Transactions.Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber).ToList();
        }
    }
       

        
    
}


