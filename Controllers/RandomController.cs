// using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApi.Helpers;

namespace banco_de_dados.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }

    private readonly ApplicationContext _context;

    public RandomController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("user/")]
    public async Task<ActionResult<List<UserModel>>> getUsers()
    {
        return Ok(  );
    }
}
