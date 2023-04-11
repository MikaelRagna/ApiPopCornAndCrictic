using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Data.Dtos.UserDto;

public class UpdateUserDto
{
    [MaxLength(50, ErrorMessage = "Username length cannot exceed 50 characters")]
    public string userName { get; set; }
    [StringLength(24, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 24 characters long")]
    public string password { get; set; }
    public string imageUrl { get; set; }
    public string email { get; set; }
    [MaxLength(250, ErrorMessage = "Description cannot be longer than 250 characters")]
    public string bio { get; set; }
}
