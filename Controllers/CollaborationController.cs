using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class CollaborationController : ControllerBase
{
    private readonly ICollaborationService _service; 

    public CollaborationController(ICollaborationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Collaboration collaboration)
    {
        await _service.add(collaboration);
        return Ok();
//return CreatedAtAction( nameof(collaboration), collaboration);
    }

    [HttpPut]
    public async Task<ActionResult<Collaboration>> Update([FromBody] Collaboration collaboration)
    {
        return Ok(await _service.update(collaboration));
    }
    
    [HttpDelete("{guid_post}/{user_email}")]
    public async Task<ActionResult<Collaboration>> Delete(Guid guid_post, string user_email)
    {
        await _service.delete(new Collaboration{
            guid_post = guid_post,
            user_email = user_email
        });
    
        return Ok();
    }


    
}