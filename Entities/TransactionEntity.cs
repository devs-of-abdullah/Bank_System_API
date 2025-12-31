
namespace Entities
{
    public class TransactionEntity
    {
          public int Id { get; set; }
          public int SenderID { get; set; } 
          public UserEntity SenderUser { get; set; } = null!;
          public int ReceiverID { get; set; }
          public UserEntity ReceiverUser { get; set; } = null!;
          public decimal Amount { get; set; }
          public string Type {  get; set; } = string.Empty; 
          public string Description { get; set; } = string.Empty;
          public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
          public record TransactionResult(bool IsSuccess, string Message);
      
       
    
}
