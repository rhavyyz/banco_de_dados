using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Entities.Views;
using Controllers.Constrains;

namespace Controllers;

[ApiController]
[Route("user/[controller]")]
public class AuthController : ControllerBase
{
    
    public IActionResult Get()
    {
    

        return Ok("auau papai");
    }


}