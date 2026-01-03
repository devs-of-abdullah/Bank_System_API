

namespace Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;   
        public decimal Balance { get; set; } = 0;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<TransactionEntity> SentTransactions { get; set; } = new List<TransactionEntity>();
        public ICollection<TransactionEntity> ReceivedTransactions { get; set; } = new List<TransactionEntity>();

    }
}
