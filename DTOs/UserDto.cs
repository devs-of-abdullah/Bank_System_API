using System.ComponentModel.DataAnnotations;

namespace DTOs
{   
    public class ReadUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public decimal Balance { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; init; } = null!; // costumer , admin , superAdmin
        public DateTime? UpdatedAt { get; init; }
        public DateTime CreatedAt { get; set; }
    }
    public class UpdateUserFirstLastNameDTO
    {
        [Required, MaxLength(20)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(20)]
        public string LastName { get; set; } = null!;

    }
    public record UpdateUserRoleDTO
    {
        [Required, MaxLength(10)]
        public string NewRole { get; init; } = null!;
    }
    public record UpdateUserPasswordDTO
    {
        [Required]
        public string CurrentPassword { get; init; } = null!;
        [Required, MinLength(6)]
        public string NewPassword { get; init; } = null!;
    }
    public record UpdateUserEmailDTO
    {
        [Required]
        public int Id { get; init; }
        [Required, EmailAddress, MaxLength(256)]
        public string NewEmail { get; init; } = null!;
        [Required, MinLength(6)]
        public string CurrentPassword { get; init; } = null!;
    }
    public class CreateUserDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; } = null!;

        [Required, MinLength(6)]
        public string Password { get; set; } = null!;

        public string Role { get; init; } = null!;
    }
    public record SoftUserDeleteDTO
    {
        [Required, MinLength(6)]
        public string CurrentPassword { get; init; } = null!;
    }
}
