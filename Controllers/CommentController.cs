using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PopCornAndCritics.Data;
using PopCornAndCritics.Data.Dtos.CommentDto;
using PopCornAndCritics.Data.Dtos.MovieDto;
using PopCornAndCritics.Data.Dtos.UserDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Controllers;

public class CommentController : ControllerBase
{
    private UserContext _context;
    private IMapper _mapper;

    public CommentController(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost("/comment/{idMovie}")]
    public IActionResult MovieComment(int idMovie,[FromBody] CreateComentDto newComment )
    {
        var movieL = _context.Movies.FirstOrDefault(id => id.Id == idMovie);
        var userL = _context.Users.FirstOrDefault(u => u.Id == newComment.UserId);
        if (userL == null) return NotFound("Usuário não existe");
        if (movieL == null) return NotFound("Filme Não Existe");

        Comments comment = new Comments();

        comment.Movie = movieL;
        comment.Author = userL;
        comment.Content = newComment.Content;

        

        _context.Comments.Add(comment);
        _context.SaveChanges();
        return Ok(_mapper.Map<ReadCommentDto>(comment));
    }

    [HttpGet("/comment/{idMovie}")]
    public ActionResult<IEnumerable<ReadCommentDto>> GetComment(int idMovie)
    {
        
        var commenterMovie = _context.Comments.Where(id => id.Movie.Id == idMovie).ToList();
       
        if (commenterMovie == null) return NotFound("Filme não existe");
        
        List<User> useLIst = new List<User>(); 

        foreach (var comments in commenterMovie)
        {
            useLIst = _context.Users.Where(x => x.Id == comments.UserId).ToList();
        }
        
        _context.Movies.FirstOrDefault(id => id.Id == idMovie);
        
        return Ok(_mapper.Map<List<ReadCommentDto>>(commenterMovie)) ;
     }
}
