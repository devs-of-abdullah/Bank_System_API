using Entities;
using Entities.DTOs;

namespace Business.Interfaces
{
    public interface ITransactionService
    {
        public Task<TransactionResult> WithdrawAsync(int currentId, CreateWithdrawDTO dto);
        public Task<TransactionResult> DepositAsync(int currentId, CreateDepositDTO dto);
        public Task<TransactionResult> TransferAsync(int currentId, CreateTransferDTO dto);
       
    }
}
