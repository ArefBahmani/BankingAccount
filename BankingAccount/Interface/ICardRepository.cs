using BankingAccount.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount.Interface
{
    public interface ICardRepository
    {
        public Card GetCard(string cardNumber);
        public void UpdateCard(Card card);
    }
}
