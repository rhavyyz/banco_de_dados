using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _rep; 

    public CommentController(ICommentRepository rep)
    {
        _rep = rep;
    }

    [HttpGet("post/{guid_post}")]
    public ActionResult<List<Comment>> Get(Guid guid_post)
    {
        return Ok(_rep.getByPost(new Post{guid = guid_post}));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Comment comment)
    {
        await _rep.add(comment);
        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        await _rep.delete(new Comment{guid = guid});
        return Ok();
    }
}