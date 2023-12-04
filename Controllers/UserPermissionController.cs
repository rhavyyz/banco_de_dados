using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class UserPermissionController : ControllerBase
{
    private readonly IUserPermissionService _service; 

    public UserPermissionController(IUserPermissionService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IQueryable<UserPermission>> Get()
    {
        return Ok( _service.getAll());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserPermission user_permission)
    {
        await _service.add(user_permission);

        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        await _service.delete(new UserPermission{guid = guid});
        return Ok();
    }
}