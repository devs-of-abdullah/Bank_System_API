

namespace Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;

        public string AccountName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
        public List<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
    }
}
