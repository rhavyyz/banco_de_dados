using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILikeService _service; 

    public LikeController(ILikeService service)
    {
        _service = service;
    }

    [HttpGet("post/{guid_post}")]
    public async Task<ActionResult<PostLikes>> GetByPost(Guid guid_post)
    {
        return Ok(_service.getByPost(new Post{guid = guid_post}));
    }


    [HttpGet("user/{user_email}")]
    public async Task<ActionResult<PostLikes>> GetByUser(string user_email)
    {
        return Ok(_service.getByUser(new User{email = user_email}));
    }

    [HttpPost("{user_email}/{guid_post}")]
    public async Task<ActionResult> Post( string user_email, Guid guid_post)
    {
        await _service.add(guid_post, user_email);
    
        return Ok();
//return CreatedAtAction(null, null);
    }

    [HttpDelete("{user_email}/{guid_post}")]
    public async Task<ActionResult> Delete(string user_email, Guid guid_post)
    {
        await _service.delete(guid_post, user_email);
    
        return Ok();
    }



}