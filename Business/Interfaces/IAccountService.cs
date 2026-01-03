using Entities.DTOs;

namespace Business.Interfaces
{
    public interface IAccountService
    {
        Task<int> RegisterAsync(RegisterUserDto userDto);
        Task<string> LoginAsync(LoginAccountDto userDto);

        Task DeleteAsync(int id);
        Task UpdateAsync(int Id,UpdateAccountDto userDto);
        Task<AccountDto?> GetByIdAsync(int id);
        Task<AccountDto?> GetByEmailAsync(string email);
        Task<List<AccountDto>> GetAllAsync();
    }
}
