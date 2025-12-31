using Entities;
using Entities.DTOs;

namespace Business.Interfaces
{
    public interface ITransactionService
    {
        public Task<TransactionResult> WithdrawAsync(CreateWithdrawDTO dto);
        public Task<TransactionResult> DepositAsync(CreateDepositDTO dto);
        public Task<TransactionResult> TransferAsync(CreateTransferDTO dto);
       
    }
}
