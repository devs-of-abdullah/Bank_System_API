using Entities;
namespace Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountEntity?> GetByEmailAsync(string email);
        Task<AccountEntity?> GetByIdAsync(int id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<int> AddAsync(AccountEntity user);
        Task UpdateAsync(AccountEntity user);
        Task DeleteAsync(int id);
        Task<List<AccountEntity>> GetAllAsync();
    }
}
