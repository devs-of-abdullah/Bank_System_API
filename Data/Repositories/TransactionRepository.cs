using Data.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly AppDbContext _context;
        public enum enTransactionTypes { Deposit, Transfer, Withdraw }

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task AddTransactionAsync(TransactionEntity entity)
            => await _context.Transactions.AddAsync(entity);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
            => await _context.Database.BeginTransactionAsync();
    }
}