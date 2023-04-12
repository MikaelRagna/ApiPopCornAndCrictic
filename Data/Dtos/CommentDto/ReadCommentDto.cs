using PopCornAndCritics.Data.Dtos.MovieDto;
using PopCornAndCritics.Data.Dtos.UserDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Data.Dtos.CommentDto;

public class ReadCommentDto
{
    public int UserId { get; set; }

    public ReadUserDto Author { get; set; }

    public ReadMovieDto Movie { get; set; }

    public string Content { get; set; }
}
