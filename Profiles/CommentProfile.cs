using AutoMapper;
using PopCornAndCritics.Data.Dtos.CommentDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateComentDto, Comments>();
    }
}
