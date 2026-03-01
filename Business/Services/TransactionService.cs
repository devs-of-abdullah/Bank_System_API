using Business.Interfaces;
using Data.Interfaces;
using DTOs;
using Entities;
using static Data.TransactionRepository;

namespace Business.Services
{
    public class TransactionService : ITransactionService
    {
        readonly ITransactionRepository _transactionRepo;

        public TransactionService(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<TransactionResult> DepositAsync(int currentId, CreateDepositDTO dto)
        {
            var currentUser = await _transactionRepo.GetUserByIdAsync(currentId);

            if (currentUser == null)
                return new TransactionResult(false, "Account not found");

            if (dto.Amount <= 0)
                return new TransactionResult(false, "Amount must be greater than 0");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only DEPOSIT 100 or less per time");

            using var transaction = await _transactionRepo.BeginTransactionAsync();

            try
            {
                currentUser.Balance += dto.Amount;

                await _transactionRepo.AddTransactionAsync(new TransactionEntity
                {
                    SenderID = currentId,
                    ReceiverID = currentId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = enTransactionTypes.Deposit.ToString(),
                });

                await _transactionRepo.SaveChangesAsync();
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
            var currentUser = await _transactionRepo.GetUserByIdAsync(currentId);

            if (currentUser == null)
                return new TransactionResult(false, "Account not found");

            if (dto.Amount <= 0)
                return new TransactionResult(false, "Amount must be greater than 0");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only WITHDRAW 100 or less per time");

            if (currentUser.Balance < dto.Amount)
                return new TransactionResult(false, "Insufficient balance");

            using var transaction = await _transactionRepo.BeginTransactionAsync();

            try
            {
                currentUser.Balance -= dto.Amount;

                await _transactionRepo.AddTransactionAsync(new TransactionEntity
                {
                    SenderID = currentId,
                    ReceiverID = currentId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = enTransactionTypes.Withdraw.ToString(),
                });

                await _transactionRepo.SaveChangesAsync();
                await transaction.CommitAsync();

                return new TransactionResult(true, "Withdraw Completed Successfully");
            }
            catch
            {
                await transaction.RollbackAsync();
                return new TransactionResult(false, "Withdraw failed. Please try later.");
            }
        }

        public async Task<TransactionResult> TransferAsync(int currentId, CreateTransferDTO dto)
        {
            if (currentId == dto.ReceiverId)
                return new TransactionResult(false, "Cannot transfer to yourself");

            var senderUser = await _transactionRepo.GetUserByIdAsync(currentId);
            var receiverUser = await _transactionRepo.GetUserByIdAsync(dto.ReceiverId);

            if (senderUser == null)
                return new TransactionResult(false, "Sender account not found");

            if (receiverUser == null)
                return new TransactionResult(false, "Receiver account not found");

            if (dto.Amount <= 0)
                return new TransactionResult(false, "Amount must be greater than 0");

            if (dto.Amount > 100)
                return new TransactionResult(false, "Can only TRANSFER 100 or less per time");

            if (senderUser.Balance < dto.Amount)
                return new TransactionResult(false, "Insufficient balance");

            using var transaction = await _transactionRepo.BeginTransactionAsync();

            try
            {
                senderUser.Balance -= dto.Amount;
                receiverUser.Balance += dto.Amount;

                await _transactionRepo.AddTransactionAsync(new TransactionEntity
                {
                    SenderID = currentId,
                    ReceiverID = dto.ReceiverId,
                    Amount = dto.Amount,
                    Description = dto.Description,
                    Type = enTransactionTypes.Transfer.ToString(),
                });

                await _transactionRepo.SaveChangesAsync();
                await transaction.CommitAsync();

                return new TransactionResult(true, "Transfer Completed Successfully");
            }
            catch
            {
                await transaction.RollbackAsync();
                return new TransactionResult(false, "Transfer failed. Please try later.");
            }
        }
    }
}