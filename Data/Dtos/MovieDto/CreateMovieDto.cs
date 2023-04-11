using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Data.Dtos.MovieDto;

public class CreateMovieDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Movie title is required")]
    public string title { get; set; }
    [Required(ErrorMessage = "The film synopsis is required")]
    [MaxLength(250, ErrorMessage = "Synopsis length cannot exceed 250 characters")]
    public string synopsis { get; set; }
    [Required(ErrorMessage = "Film genre is required")]
    [MaxLength(50, ErrorMessage = "Genre length cannot exceed 50 characters")]
    public string Genero { get; set; }
    [Required]
    public string duracao { get; set; }
    [Required(ErrorMessage = "The image is required")]
    public string imageUrl { get; set; }
    public int rating { get; set; }
}
