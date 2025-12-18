using System.ComponentModel.DataAnnotations;

namespace CrmApp.Domain.Entities;

public class Account
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required")]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [MaxLength(255)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email format (ex: user@domain.com)")]
    public string Email { get; set; } = string.Empty;

    [MaxLength(15, ErrorMessage = "Phone number cannot exceed 15 characters")]
    [RegularExpression(@"^\(\d{2}\)\s?\d{4,5}-\d{4}$", 
        ErrorMessage = "Phone must be (XX) XXXX-XXXX or (XX) XXXXX-XXXX")]
    public string? PhoneNumber { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public string FullName => $"{FirstName} {LastName}";
}

