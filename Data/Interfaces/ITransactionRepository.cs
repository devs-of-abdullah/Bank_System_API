using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Interfaces
{
    public interface ITransactionRepository
    {
        Task<UserEntity?> GetUserByIdAsync(int id);
        Task AddTransactionAsync(TransactionEntity entity);
        Task SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}