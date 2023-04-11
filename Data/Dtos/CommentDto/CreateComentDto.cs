using PopCornAndCritics.Model;

namespace PopCornAndCritics.Data.Dtos.CommentDto;

public class CreateComentDto
{

    public int Id_Author { get; set; }
    public User Author { get; set; }
    public int Id_Movie { get; set; }
    public Movie Movie { get; set; }
    public string Content { get; set; }
}
