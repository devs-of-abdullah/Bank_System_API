
namespace Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public List<AccountEntity> Accounts { get; set; } = new List<AccountEntity>();
    }
}
