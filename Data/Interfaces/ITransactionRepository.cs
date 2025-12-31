
using Entities;
using Entities.DTOs;

namespace Data.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionResult> DepositAsync(int currentId,CreateDepositDTO dto);
        Task<TransactionResult> WithdrawAsync(int currentId,CreateWithdrawDTO dto);
        Task<TransactionResult> TransferAsync(int currentId,CreateTransferDTO dto);
    }
}
