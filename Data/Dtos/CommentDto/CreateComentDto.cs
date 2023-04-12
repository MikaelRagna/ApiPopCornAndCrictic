﻿using PopCornAndCritics.Data.Dtos.MovieDto;
using PopCornAndCritics.Data.Dtos.UserDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Data.Dtos.CommentDto;

public class CreateComentDto
{

    public int UserId { get; set; }

    public User Author { get; set; }

    public Movie Movie { get; set; }

    public string Content { get; set; }
}
