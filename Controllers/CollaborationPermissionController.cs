using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class CollaborationPermissionController : ControllerBase
{
    private readonly ICollaborationPermissionService _service; 

    public CollaborationPermissionController(ICollaborationPermissionService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<CollaborationPermission> Get()
    {
        return Ok(_service.getAll());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CollaborationPermission collaboration_permission)
    {
        await _service.add(collaboration_permission);
        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult<CollaborationPermission>> Delete(Guid guid)
    {
        await _service.delete(new CollaborationPermission{
            guid = guid
        });
    
        return Ok();
    }

}