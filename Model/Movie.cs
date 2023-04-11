using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Model
{
    public class Movie
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
        public string genre { get; set; }
        [Required]
        public string duration { get; set; }
        [Required(ErrorMessage = "The image is required")]
        public string imageUrl { get; set; }
        public int rating { get; set; }
    }
}
