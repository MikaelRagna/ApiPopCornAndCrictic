using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCornAndCritics.Model;

public class Comments
{
    public int Id { get; set; }

    [Required]
    public int Id_Author { get; set; }
    [ForeignKey("Id_Author")]
    public User Author { get; set; }
    [Required]
    public int Id_Movie { get; set; }
    [ForeignKey("Id_Movie")]
    public Movie Movie { get; set;}
    [Required]
    public string Content { get; set; }
}
