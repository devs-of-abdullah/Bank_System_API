

using Business.Interfaces;
using Data.Interfaces;
using Entities;
using Entities.DTOs;

namespace Business.Services
{
    public class TransactionService : ITransactionService
    {
        readonly ITransactionRepository _repo;
        public TransactionService(ITransactionRepository repo) 
        { 
            _repo = repo;
        }
        public async Task<TransactionResult> WithdrawAsync(int currentId, CreateWithdrawDTO dto)
        {
            return await _repo.WithdrawAsync(currentId,dto);
        }
        public async Task<TransactionResult> DepositAsync(int currentId,CreateDepositDTO dto)
        {
            return await _repo.DepositAsync(currentId, dto);
        }
        public async Task<TransactionResult> TransferAsync(int currentId, CreateTransferDTO dto)
        {
            return await _repo.TransferAsync(currentId,dto);
        }
      
    }
}
