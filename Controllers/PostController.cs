using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _service; 

    public PostController(IPostService service)
    {
        _service = service;
    }

    [HttpGet("preview")]
    public ActionResult<List<PostPreview>> GetPreviews()
    {
        return Ok(_service.getAll());
    }
   
    [HttpGet("preview/{guid_category}")]
    public async Task<ActionResult<List<PostPreview>>> GetPreviewsByCategory(Guid guid_category)
    {
        return Ok(await _service.getByCategory(new Category{guid = guid_category}));
    }
   
    [HttpGet("preview/date/{begin}/{end}")]
    public async Task<ActionResult<List<PostPreview>>> GetPreviewByDate(DateTime begin, DateTime end)
    {
        return Ok(_service.getByDate(begin, end));
    }
    [HttpGet("preview/title/{title}")]
    public async Task<ActionResult<List<PostPreview>>> GetPreviewByTitle(string title)
    {
        return Ok(_service.getByTitle(title));
    }

   [HttpGet("preview/user/{user_email}")]
    public async Task<ActionResult<List<PostPreview>>> GetPreviewByUserEmail(string user_email)
    {
        return Ok(await _service.getByUser(new User{email = user_email}));
    }
    
    [HttpGet("{guid}")]
    public async Task<ActionResult<List<Post>>> GetByGuid(Guid guid)
    {
        return Ok(await _service.getByGuid(guid));
    }

    [HttpPut]
    public async Task<ActionResult<Post>> Update([FromBody] Post post)
    {
        return Ok(await _service.update(post));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Post post)
    {
        await _service.add(post);
        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<IActionResult> Delete(Guid guid)
    {
        await _service.delete(new Post{guid = guid});
        return Ok();
    }

}