
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public record CreateWithdrawDTO(

          [Range(0.01, 100, ErrorMessage = "Amount must be between 0.01 and 100")]
           decimal Amount,

          [MaxLength(256)] 
          string Description = ""
      );

    public record CreateTransferDTO(
        [Required]
        int ReceiverId,

        [Range(0.01, 100, ErrorMessage = "Amount must be between 0.01 and 100")]
        decimal Amount,

        [MaxLength(256)]
        string Description = ""
    );
    public record CreateDepositDTO(

           [Range(0.01, 100, ErrorMessage = "Amount must be between 0.01 and 100")]
           decimal Amount,

           [MaxLength(256)] 
           string Description = ""
       );
 
    public record TransactionResult(bool IsSuccess, string Message);

}
