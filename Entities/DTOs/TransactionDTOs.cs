
namespace Entities.DTOs
{
    public class CreateTransferDTO
    {
       // public int SenderId {  get; set; } replaced with JWT nameIdentifer
        public int ReceiverId {  get; set; }
        public decimal Amount {  get; set; }
        public string Description {  get; set; } = string.Empty;
    }
    public class CreateDepositDTO
    {
        // public int CurrentId { get; set; } replaced with JWT nameIdentifer
        public decimal Amount { get; set; } 
        public string Description { get; set; } = string.Empty;
    }
    public class CreateWithdrawDTO
    {
        // public int CurrentId { get; set; } replaced with JWT nameIdentifer
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
