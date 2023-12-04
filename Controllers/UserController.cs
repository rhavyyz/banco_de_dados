using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service; 

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IQueryable<User>>> GetAll()
    {
        return Ok(_service.getAll());
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<User>> GetByEmail(string email)
    {
        return Ok( _service.getByEmail(email));
    }
    
    [HttpGet("name/{name}")]
    public async Task<ActionResult> GetByName(string name)
    {
        return Ok(_service.getByName(name));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        await _service.add(user);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] User user)
    {
        return Ok(await _service.update(user));
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> Delete(string email)
    {
        await _service.delete(new User{email = email});

        return Ok();
    }

}