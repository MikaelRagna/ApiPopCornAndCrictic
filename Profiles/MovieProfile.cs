using AutoMapper;
using PopCornAndCritics.Data.Dtos.MovieDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<Movie, ReadMovieDto>();
    }
}
