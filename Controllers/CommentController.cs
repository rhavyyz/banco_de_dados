using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _service; 

    public CommentController(ICommentService service)
    {
        _service = service;
    }

    [HttpGet("post/{guid_post}")]
    public ActionResult<List<Comment>> Get(Guid guid_post)
    {
        return Ok(_service.getByPost(new Post{guid = guid_post}));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Comment comment)
    {
        await _service.add(comment);
        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        await _service.delete(new Comment{guid = guid});
        return Ok();
    }
}