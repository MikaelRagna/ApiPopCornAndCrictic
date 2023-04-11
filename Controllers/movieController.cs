using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopCornAndCritics.Data;
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

    [HttpPost("/register/movie")]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return Ok(movie);
    }

    [HttpGet("/movie/all")]
    public IEnumerable<ReadMovieDto> allMovie()
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies);
    }

    [HttpGet("/movie/{genre}")]
    
    public ActionResult<IEnumerable<ReadMovieDto>> movieByGenre(string genre)
    {
        var movie = _context.Movies
            .Where(movie => movie.genre == genre).ToList();
        if (movie == null)return NotFound();
        return Ok(movie);
    }
}
