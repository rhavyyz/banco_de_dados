using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CollaborationPermissionController : ControllerBase
{
    private readonly ICollaborationPermissionRepository _rep; 

    public CollaborationPermissionController(ICollaborationPermissionRepository rep)
    {
        _rep = rep;
    }

    [HttpGet]
    public ActionResult<CollaborationPermission> Get()
    {
        return Ok(_rep.getAll());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CollaborationPermission collaboration_permission)
    {
        await _rep.add(collaboration_permission);
        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult<CollaborationPermission>> Delete(Guid guid)
    {
        await _rep.delete(new CollaborationPermission{
            guid = guid
        });
    
        return Ok();
    }

}