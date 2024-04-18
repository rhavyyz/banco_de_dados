using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;
using Controllers.Constrains;

namespace Controllers;

[ApiController]
[PathNotPermitedConstraint("/user/auth")]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _rep; 
    // private readonly IAuthRepository _auth_rep; 

    public UserController(IUserRepository rep)
    {
        _rep = rep;
        // _auth_rep = auth_rep;
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

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] User user)
    {
        return Ok(await _rep.update(user));
    }
    
    // Auth   

    // [HttpPost("auth")]
    // public async Task<ActionResult> Post([FromBody] User user)
    // {
    //     await _rep.add(user);
    //     return Ok();
    // }

    // [HttpDelete("auth/{email}")]
    // public async Task<IActionResult> Delete(string email)
    // {
    //     await _rep.delete(new User{email = email});

    //     return Ok();
    // }

    // [HttpPut("auth")]
    // public IActionResult PutPassword()
    // {
    

    //     return Ok();
    // }
}