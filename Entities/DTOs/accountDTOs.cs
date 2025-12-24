namespace Entities.DTOs
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountNumber { get; set; } = null!;
        public decimal Balance { get; set; }
    }
    public class RegisterAccountRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
    }

    public class UpdateAccountNameRequest
    {
        public int AccountId { get; set; }
        public string NewName { get; set; } = null!;
    }
}
