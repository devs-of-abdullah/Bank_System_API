
namespace DTOs
{
    public class CreateTransferDTO
    {
        public int ReceiverId {  get; set; }
        public decimal Amount {  get; set; }
        public string Description {  get; set; } = string.Empty;
    }
    public class CreateDepositDTO
    {
        public decimal Amount { get; set; } 
        public string Description { get; set; } = string.Empty;
    }
    public class CreateWithdrawDTO
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
    public record TransactionResult(bool IsSuccess, string Message);

}
