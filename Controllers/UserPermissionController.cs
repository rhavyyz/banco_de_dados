using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class UserPermissionController : ControllerBase
{
    private readonly IUserPermissionRepository _rep; 

    public UserPermissionController(IUserPermissionRepository rep)
    {
        _rep = rep;
    }

    [HttpGet]
    public ActionResult<IQueryable<UserPermission>> Get()
    {
        return Ok( _rep.getAll());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserPermission user_permission)
    {
        await _rep.add(user_permission);

        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        await _rep.delete(new UserPermission{guid = guid});
        return Ok();
    }
}