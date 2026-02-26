using DTOs;
namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(CreateUserDTO userDto);

        Task<ReadUserDTO?> GetByIdAsync(int id);
        Task<ReadUserDTO?> GetByEmailAsync(string email);
        Task<List<ReadUserDTO>> GetAllAsync();
        Task SoftDeleteAsync(int id, SoftUserDeleteDTO dto);

        Task UpdatePasswordAsync(int id, UpdateUserPasswordDTO dto);
        Task UpdateRoleAsync(int id, UpdateUserRoleDTO dto);
        Task UpdateEmailAsync(int id, UpdateUserEmailDTO dto);
    }
}
