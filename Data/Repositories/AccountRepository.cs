using Data.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AccountRepository : IAccountRepository
    {
        readonly AppDbContext _context;
        public AccountRepository(AppDbContext context) => _context = context;
        public async Task<AccountEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<AccountEntity?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);

        }
        public async Task<int> AddAsync(AccountEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task UpdateAsync(AccountEntity user) 
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id)
                ?? throw new KeyNotFoundException("Uder not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
           
        }
        public async Task<List<AccountEntity>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
