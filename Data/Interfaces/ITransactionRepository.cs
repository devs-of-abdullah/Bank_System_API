
using Entities;
using Entities.DTOs;

namespace Data.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionResult> DepositAsync(CreateDepositDTO dto);
        Task<TransactionResult> WithdrawAsync(CreateWithdrawDTO dto);
        Task<TransactionResult> TransferAsync(CreateTransferDTO dto);
    }
}
