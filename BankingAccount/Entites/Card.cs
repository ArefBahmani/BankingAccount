using System.ComponentModel.DataAnnotations;

namespace BankingAccount.Entites
{
    public class Card
    {
        public int CardId { get; set; }
        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }  
        public string HolderName { get; set; }
        public float Balance { get; set; } = 1000;
        public bool IsActive { get; set; } = true;
        [Required]
        public string Password { get; set; }  
        public int FailedCount { get; set; } = 0;
        public float TransactionLimit { get; set; } = 250;

        public List<Transaction>? Transactions { get; set; }
    }
}
