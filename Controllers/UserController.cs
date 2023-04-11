using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PopCornAndCritics.Data;
using PopCornAndCritics.Data.Dtos.UserDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Controllers;

[ApiController]

public class UserController : ControllerBase
{
    private UserContext _context;
    private IMapper _mapper;

    public UserController(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("/singup")]
    public IActionResult AddUser([FromBody] CreateUserDto userDto)
    {

        User user = _mapper.Map<User>(userDto);
        var verificationEmail = _context.Users.FirstOrDefault(verificadedEmail => verificadedEmail.email == userDto.email);
        if (verificationEmail != null) return BadRequest("Já existe um usuário com esse email");
        _context.Users.Add(user);
        _context.SaveChanges();
        CreatedAtAction(nameof(UserList), new { id = user.Id }, user);
        return Ok();
        
    }

    [HttpPost("/signin")]
    public IActionResult LoginUser([FromBody] LoginUserDto loginModel)
    {
        var login = _context.Users.FirstOrDefault(user => user.email == loginModel.email);
        var resLogin = _mapper.Map<ReadUserDto>(login);

        if (login == null) 
            return NotFound("Usuário com este e-mail não foi encontrado");

        if (login.password != loginModel.password) 
            return Unauthorized("Senha incorreta");

        return Ok(resLogin);
    }

    [HttpGet("/user/all")]
    public IEnumerable<ReadUserDto> UserList()
    {
        return _mapper.Map<List<ReadUserDto>>(_context.Users);
    }

    [HttpGet("/user/{id}")]
    public IActionResult RetrieveUserById(int id)
    {
        var user = _context.Users
            .FirstOrDefault(user => user.Id == id);
        if(user == null) return NotFound();
        var UserDto = _mapper.Map<ReadUserDto>(user);
        return Ok(UserDto);

    }

    [HttpPatch("/user/{id}")]
    public IActionResult UpdateUser(int id, JsonPatchDocument<UpdateUserDto> patch)
    {
        var user = _context.Users
           .FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();

        var userToUpdate = _mapper.Map<UpdateUserDto>(user);

        patch.ApplyTo(userToUpdate, ModelState);

        if (!TryValidateModel(userToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(userToUpdate, user);
        _context.SaveChanges();
        return NoContent();
    }

    
}
