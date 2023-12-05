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

    [HttpGet]
    public ActionResult<IQueryable<Collaboration>> Get()
    {
        return Ok(_service.getAll());
    }



    [HttpGet("user/{user_email}")]
    public  ActionResult<List<Collaboration>> GetByUser(string user_email)
    {
        return Ok(_service.getByUser(new User{email = user_email}));
    }


    [HttpGet("post/{guid_post}")]
    public  ActionResult<List<Collaboration>> GetByPost(Guid guid_post)
    {
        return Ok(_service.getByPost(new Post{guid = guid_post}));
    }

    
}