using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _rep; 

    public PostController(IPostRepository rep)
    {
        _rep = rep;
    }

    [HttpGet("preview")]
    public ActionResult<List<PostPreview>> GetPreviews()
    {
        return Ok(_rep.getAll());
    }
   
    [HttpGet("preview/{guid_category}")]
    public ActionResult<IQueryable<PostPreview>> GetPreviewsByCategory(Guid guid_category)
    {
        return Ok(_rep.getByCategory(new Category{guid = guid_category}));
    }
   
    [HttpGet("preview/date/{begin}/{end}")]
    public  ActionResult<List<PostPreview>> GetPreviewByDate(DateTime begin, DateTime end)
    {
        return Ok(_rep.getByDate(begin, end));
    }
    [HttpGet("preview/title/{title}")]
    public ActionResult<List<PostPreview>> GetPreviewByTitle(string title)
    {
        return Ok(_rep.getByTitle(title));
    }

   [HttpGet("preview/user/{user_email}")]
    public ActionResult<List<PostPreview>> GetPreviewByUserEmail(string user_email)
    {
        return Ok( _rep.getByUser(new User{email = user_email}));
    }
    
    [HttpGet("{guid}")]
    public async Task<ActionResult<List<Post>>> GetByGuid(Guid guid)
    {
        return Ok(await _rep.getByGuid(guid));
    }

    [HttpPut]
    public async Task<ActionResult<Post>> Update([FromBody] Post post)
    {
        return Ok(await _rep.update(post));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Post post)
    {
        await _rep.add(post);
        return Ok();
    }

    [HttpDelete("{guid}")]
    public async Task<IActionResult> Delete(Guid guid)
    {
        await _rep.delete(new Post{guid = guid});
        return Ok();
    }

}