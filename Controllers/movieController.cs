using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopCornAndCritics.Data;
using PopCornAndCritics.Data.Dtos.CommentDto;
using PopCornAndCritics.Data.Dtos.MovieDto;
using PopCornAndCritics.Data.Dtos.UserDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Controllers;

[ApiController]

public class movieController : ControllerBase
{
    private UserContext _context;
    private IMapper _mapper;

    public movieController(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="movieDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost("/register/movie")]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(movieById), new { id = movie.Id }, movie);
    }

    [HttpGet("/movie/all")]
    public IEnumerable<ReadMovieDto> allMovie()
    {

        return _mapper.Map<List<ReadMovieDto>>(_context.Movies);
    }

    [HttpGet("/movie/genre/{genre}")]
    
    public ActionResult<IEnumerable<ReadMovieDto>> movieByGenre(string genre)
    {
        var movie = _context.Movies
            .Where(movie => movie.genre == genre).ToList();
        if (movie == null)return NotFound();
        return Ok(movie);
    }

    [HttpGet("/movie/{idMovie}")]

    public IActionResult movieById(int idMovie)
    {
        var movie = _context.Movies
            .FirstOrDefault(movie => movie.Id == idMovie);
        if (movie == null) return NotFound();
        var commenterMovie = _context.Comments.Where(id => id.Movie.Id == idMovie).ToList();

        if (commenterMovie == null) return NotFound("Filme não existe");

        List<User> useLIst = new List<User>();

        foreach (var comments in commenterMovie)
        {
            useLIst = _context.Users.Where(x => x.Id == comments.UserId).ToList();
        }

        _context.Movies.FirstOrDefault(id => id.Id == idMovie);
        var resComment = _mapper.Map<List<ReadCommentDto>>(commenterMovie);
        return Ok(new {
            movie,
            resComment
        });
    }
}
