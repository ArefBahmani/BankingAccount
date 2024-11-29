using BankingAccount.DbContexts;
using BankingAccount.Entites;
using BankingAccount.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly BankDbContext _context;

        public CardRepository(BankDbContext context)
        {
            _context = context;
        }

        public Card GetCard(string cardNumber)
        {
            return _context.Cards
                .FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public void UpdateCard(Card card)
        {
            _context.Cards.Update(card);
            _context.SaveChanges();
        }
    }
}

