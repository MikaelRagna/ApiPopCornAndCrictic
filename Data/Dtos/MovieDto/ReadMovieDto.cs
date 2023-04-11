using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Data.Dtos.MovieDto;

public class ReadMovieDto
{
    public int Id { get; set; }   
    public string title { get; set; }   
    public string synopsis { get; set; }   
    public string genre { get; set; }
    public string duration { get; set; }
    public string imageUrl { get; set; }
    public int rating { get; set; }
}
