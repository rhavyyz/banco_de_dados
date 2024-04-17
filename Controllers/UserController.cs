using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Entities.Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _rep; 

    public UserController(IUserRepository rep)
    {
        _rep = rep;
    }

    [HttpGet]
    public ActionResult<IQueryable<User>> GetAll()
    {
        return Ok(_rep.getAll());
    }

    [HttpGet("{email}")]
    public ActionResult<User> GetByEmail(string email)
    {
        return Ok( _rep.getByEmail(email));
    }
    
    [HttpGet("name/{name}")]
    public ActionResult GetByName(string name)
    {
        return Ok(_rep.getByName(name));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        await _rep.add(user);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] User user)
    {
        return Ok(await _rep.update(user));
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> Delete(string email)
    {
        await _rep.delete(new User{email = email});

        return Ok();
    }

}