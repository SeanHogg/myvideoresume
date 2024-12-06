using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Data.Models;

namespace MyVideoResume.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPreferencesController : ControllerBase
{
    [HttpGet("{userId}")]
    public JobPreferencesEntity Get(string userId)
    {
        return null;
    }

    [HttpPost("{userId}")]
    public JobPreferencesEntity Post(string userId, [FromBody] JobPreferences preferences)
    {
        return null;
    }
}
