using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CollaborationController : ControllerBase
{
    private readonly ICollaborationRepository _rep; 

    public CollaborationController(ICollaborationRepository rep)
    {
        _rep = rep;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Collaboration collaboration)
    {
        await _rep.add(collaboration);
        return Ok();
//return CreatedAtAction( nameof(collaboration), collaboration);
    }

    [HttpPut]
    public async Task<ActionResult<Collaboration>> Update([FromBody] Collaboration collaboration)
    {
        return Ok(await _rep.update(collaboration));
    }
    
    [HttpDelete("{guid_post}/{user_email}")]
    public async Task<ActionResult<Collaboration>> Delete(Guid guid_post, string user_email)
    {
        await _rep.delete(new Collaboration{
            guid_post = guid_post,
            user_email = user_email
        });
    
        return Ok();
    }

    [HttpGet]
    public ActionResult<IQueryable<Collaboration>> Get()
    {
        return Ok(_rep.getAll());
    }



    [HttpGet("user/{user_email}")]
    public  ActionResult<List<Collaboration>> GetByUser(string user_email)
    {
        return Ok(_rep.getByUser(new User{email = user_email}));
    }


    [HttpGet("post/{guid_post}")]
    public  ActionResult<List<Collaboration>> GetByPost(Guid guid_post)
    {
        return Ok(_rep.getByPost(new Post{guid = guid_post}));
    }

    
}