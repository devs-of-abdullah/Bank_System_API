
using Data.Interfaces;
using Entities;
using Entities.DTOs;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly AppDbContext _context;
        readonly IUserRepository _repo;
        public enum enTransactionTypes { Deposit, Transfer, Withdraw}
        public TransactionRepository(AppDbContext context, IUserRepository repo) 
        {
            _context = context;
            _repo = repo;
        }

          
        public async Task<TransactionResult> DepositAsync(int currentId, CreateDepositDTO dto) 
        {

            var CurrentUser = await _repo.GetByIdAsync(currentId);

            if (CurrentUser == null)
                return new TransactionResult(false, "User not found");

            if (dto.Amount < 0)
                return new TransactionResult(false, "Amount must be greater than 0");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only DEPOSIT 100 or less per time");


            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                CurrentUser.Balance += dto.Amount;

                var depositEntity = new TransactionEntity
                {
                    SenderID = currentId,
                    ReceiverID = currentId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = enTransactionTypes.Deposit.ToString(),

                };

                await _context.Transactions.AddAsync(depositEntity);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new TransactionResult(true, "Deposit Completed Successfully");
            }
            catch 
            {
                await transaction.RollbackAsync();

                return new TransactionResult(false, "Deposit failed. Please try later.");
            }
        }
        public async Task<TransactionResult> WithdrawAsync(int currentId, CreateWithdrawDTO dto) 
        {

            var currentUser = await _repo.GetByIdAsync(currentId);

            if (currentUser == null)
                return new TransactionResult(false, "User not found");

            if (dto.Amount < 0)
                return new TransactionResult(false, "Amount must be greater than 0");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only WITHDRAW 100 or less per time");

            if (currentUser.Balance < dto.Amount)
                return new TransactionResult(false, "Insufficent balance");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                currentUser.Balance -= dto.Amount;

                var withdrawEntity = new TransactionEntity
                {
                    SenderID = currentId,
                    ReceiverID = currentId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = enTransactionTypes.Withdraw.ToString(),

                };

                await _context.Transactions.AddAsync(withdrawEntity);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new TransactionResult(true, "Withdraw Completed Successfully");
            }
            catch 
            {
                await transaction.RollbackAsync();

                return new TransactionResult(false, "Withdraw failed. Please try later");
            }
        }
        public async Task<TransactionResult> TransferAsync(int currentId, CreateTransferDTO dto)
        {

            var senderUser = await _repo.GetByIdAsync(currentId);
            var receiverUser = await _repo.GetByIdAsync(dto.ReceiverId);

            if (senderUser == null)
                return new TransactionResult(false, "Sender user not found");

            if (receiverUser == null) 
               return new TransactionResult(false,"Receiver user not found");

            if (dto.Amount < 0)
                return new TransactionResult(false, "Amount must be greater than 0");

            if (senderUser.Balance < dto.Amount)
                return new TransactionResult(false, "Insufficent balance");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only TRANSFER 100 or less per time");
            
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                senderUser.Balance -= dto.Amount;
                receiverUser.Balance += dto.Amount;

                var transferEntity = new TransactionEntity 
                { 
                    SenderID = currentId,
                    ReceiverID = dto.ReceiverId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = enTransactionTypes.Transfer.ToString(),

                };

                await _context.Transactions.AddAsync(transferEntity);
                
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new TransactionResult(true, "Transfer Completed Successfully");
            }
            catch 
            {
                await transaction.RollbackAsync();

                return new TransactionResult(false, "Transfer failed. Pleaese try later");
            }
        }
       

    }
}
 