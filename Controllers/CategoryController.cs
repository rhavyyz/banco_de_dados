using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Views;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service; 

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet("post/{guid_post}")]
    public async Task<ActionResult<Category>> GetByPost(Guid guid_post)
    {
        return Ok(_service.getByPost(new Post{guid = guid_post}));
    }

    [HttpGet]
    public async Task<ActionResult<Category>> Get(Guid guid_post)
    {
        return Ok(_service.getAll());
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Category category)
    {
        await _service.add(category);
        return Ok();
    }
    
    [HttpDelete("{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        await _service.delete(new Category{guid = guid});
    
        return Ok();
    }

}