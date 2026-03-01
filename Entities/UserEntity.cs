

namespace Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;   
        public decimal Balance { get; set; } = 0;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "user"; 
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? RefreshTokenHash { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }
        public DateTime? RefreshTokenRevokedAt { get; set; }
        public ICollection<TransactionEntity> SentTransactions { get; set; } = new List<TransactionEntity>();
        public ICollection<TransactionEntity> ReceivedTransactions { get; set; } = new List<TransactionEntity>();

    }
}
