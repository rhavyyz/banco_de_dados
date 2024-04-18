using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _rep; 

    public CategoryController(ICategoryRepository service)
    {
        _rep = service;
    }

    [HttpGet("post/{guid_post}")]
    public ActionResult<List<Category>> GetByPost(Guid guid_post)
    {
        return Ok(_rep.getByPost(new Post{guid = guid_post}));
    }

    [HttpGet]
    public ActionResult<List<Category>> Get()
    {
        return Ok(_rep.getAll());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Category category)
    {
        await _rep.add(category);
        return Ok();
    }
    
    [HttpDelete("{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        await _rep.delete(new Category{guid = guid});
    
        return Ok();
    }

}