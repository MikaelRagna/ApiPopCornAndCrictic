using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PopCornAndCritics.Data;
using PopCornAndCritics.Data.Dtos.CommentDto;
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
    public IActionResult MovieComment(int idMovie, int idAuthor, [FromBody] string content)
    {
        var movie = _context.Movies.FirstOrDefault(id => id.Id == idMovie);
        var user = _context.Users.FirstOrDefault(u => u.Id == idAuthor);
        if (movie == null) return NotFound("Usuário não existe");
        if (movie == null) return NotFound("Filme Não Existe");

        CreateComentDto comment = new CreateComentDto();

        comment.Movie = movie;
        comment.Author = user;
        comment.Id_Movie = idMovie;
        comment.Content = content;

        var resComment = _mapper.Map<Comments>(comment);

        _context.Comments.Add(resComment);
        _context.SaveChanges();
        return Ok(resComment);
    }
}
