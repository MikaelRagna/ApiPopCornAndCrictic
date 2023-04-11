using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Model;

public class User
{
    
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Username length cannot exceed 50 characters")]
    public string userName { get; set; }
    [Required]
    [StringLength(24, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 24 characters long")]
    public string password { get; set; }
    [Required]
    public string imageUrl { get; set; }
    [Required]
    [EmailAddress]
    public string email { get; set; }
    [MaxLength(250, ErrorMessage = "Description cannot be longer than 250 characters")]
    public string bio { get; set; }
    public int evalr { get; set; }
}
