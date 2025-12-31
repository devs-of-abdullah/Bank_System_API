
using Data.Interfaces;
using Entities;
using Entities.DTOs;
using System.Transactions;

namespace Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly AppDbContext _context;
        readonly IUserRepository _repo;
        public TransactionRepository(AppDbContext context, IUserRepository repo) 
        {
            _context = context;
            _repo = repo;
        }
       
        public async Task<TransactionResult> DepositAsync(CreateDepositDTO dto) 
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var CurrentUser = await _repo.GetByIdAsync(dto.CurrentId);

            if (CurrentUser == null)
                return new TransactionResult(false, "User not found");
          
            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only DEPOSIT 100 or less per time");


            try
            {
                CurrentUser.Balance += dto.Amount;

                var Deposit = new TransactionEntity
                {
                    SenderID = dto.CurrentId,
                    ReceiverID = dto.CurrentId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = "Deposit",

                };

                await _context.Transactions.AddAsync(Deposit);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new TransactionResult(true, "Deposit Completed Successfully");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return new TransactionResult(false, ex.Message);
            }
        }
        public async Task<TransactionResult> WithdrawAsync(CreateWithdrawDTO dto) 
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var CurrentUser = await _repo.GetByIdAsync(dto.CurrentId);

            if (CurrentUser == null)
                return new TransactionResult(false, "User not found");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only WITHDRAW 100 or less per time");


            try
            {
                CurrentUser.Balance -= dto.Amount;

                var Withdraw = new TransactionEntity
                {
                    SenderID = dto.CurrentId,
                    ReceiverID = dto.CurrentId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = "Withdraw",

                };

                await _context.Transactions.AddAsync(Withdraw);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new TransactionResult(true, "Withdraw Completed Successfully");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return new TransactionResult(false, ex.Message);
            }
        }
        public async Task<TransactionResult> TransferAsync(CreateTransferDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var senderUser = await _repo.GetByIdAsync(dto.SenderId);
            var receiverUser = await _repo.GetByIdAsync(dto.ReceiverId);

            if (senderUser == null)
                return new TransactionResult(false, "Sender user not found");

            if (receiverUser == null) 
               return new TransactionResult(false,"Receiver user not found");
            
            if (senderUser.Balance < dto.Amount)
                return new TransactionResult(false, "Insufficent balance");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only TRANSFER 100 or less per time");
            
            
            try
            {
                senderUser.Balance -= dto.Amount;
                receiverUser.Balance += dto.Amount;

                var Transfer = new TransactionEntity 
                { 
                    SenderID = dto.SenderId,
                    ReceiverID = dto.ReceiverId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = "Transfer",

                };

                await _context.Transactions.AddAsync(Transfer);
                
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new TransactionResult(true, "Transfer Completed Successfully");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return new TransactionResult(false, ex.Message);
            }
        }
       

    }
}
 