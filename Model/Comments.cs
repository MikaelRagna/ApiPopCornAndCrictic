using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCornAndCritics.Model;

public class Comments
{
    public int Id { get; set; }

    [Required]
    [ForeignKey("UserId")]
    public int UserId { get; set; }    

    public User Author { get; set; }
    
    public Movie Movie { get; set;}
    [Required]
    public string Content { get; set; }
}
