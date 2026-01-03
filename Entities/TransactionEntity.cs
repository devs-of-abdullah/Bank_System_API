
namespace Entities
{
    public class TransactionEntity
    {
          public int Id { get; set; }
          public int SenderID { get; set; } 
          public AccountEntity SenderUser { get; set; } = null!;
          public int ReceiverID { get; set; }
          public AccountEntity ReceiverUser { get; set; } = null!;
          public decimal Amount { get; set; }
          public string Type {  get; set; } = string.Empty; 
          public string Description { get; set; } = string.Empty;
          public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
          public record TransactionResult(bool IsSuccess, string Message);
      
       
    
}
