


namespace Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int AccountId { get; set; }
        public AccountEntity Account { get; set; } = null!;
    }
}
