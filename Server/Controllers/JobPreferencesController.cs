using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Data.Models;

namespace MyVideoResume.Server.Controllers;

[Route("Account/{userId}/[action]")]
public class JobPreferencesController : Controller
{
    [HttpGet]
    public JobPreferencesEntity Get(string userId)
    {
        return null;
    }

    [HttpPost]
    public JobPreferencesEntity Post(string userId, [FromBody] JobPreferences preferences)
    {
        return null;
    }
}
