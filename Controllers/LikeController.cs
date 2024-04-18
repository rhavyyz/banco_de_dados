using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILikeRepository _rep; 

    public LikeController(ILikeRepository rep)
    {
        _rep = rep;
    }

    [HttpGet("post/{guid_post}")]
    public ActionResult<PostLikes> GetByPost(Guid guid_post)
    {
        return Ok(_rep.getByPost(new Post{guid = guid_post}));
    }


    [HttpGet("user/{user_email}")]
    public ActionResult<PostLikes> GetByUser(string user_email)
    {
        return Ok(_rep.getByUser(new User{email = user_email}));
    }

    [HttpPost("{user_email}/{guid_post}")]
    public async Task<ActionResult> Post( string user_email, Guid guid_post)
    {
        await _rep.add(guid_post, user_email);
    
        return Ok();
//return CreatedAtAction(null, null);
    }

    [HttpDelete("{user_email}/{guid_post}")]
    public async Task<ActionResult> Delete(string user_email, Guid guid_post)
    {
        await _rep.delete(guid_post, user_email);
    
        return Ok();
    }



}