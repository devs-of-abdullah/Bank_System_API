

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
        public async Task<TransactionResult> WithdrawAsync(CreateWithdrawDTO dto)
        {
            return await _repo.WithdrawAsync(dto);
        }
        public async Task<TransactionResult> DepositAsync(CreateDepositDTO dto)
        {
            return await _repo.DepositAsync(dto);
        }
        public async Task<TransactionResult> TransferAsync(CreateTransferDTO dto)
        {
            return await _repo.TransferAsync(dto);
        }
      
    }
}
