using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service1.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public IEnumerable<string> Get()
    {
        List<string> res = new List<string>();
        foreach (var userClaim in HttpContext.User.Claims)
        {
            res.Add(userClaim.Type + " " + userClaim.Value);
        }

        return res;
    }
    [Authorize()]
    [HttpGet]
    public IEnumerable<string> Get2()
    {
        List<string> res = new List<string>();
        foreach (var userClaim in HttpContext.User.Claims)
        {
            res.Add(userClaim.Type + " " + userClaim.Value);
        }

        return res;
    }
}