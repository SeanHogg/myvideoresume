using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Data.Models;

namespace MyVideoResume.Server.Controllers;

[Route("Account/{userId}/Resume/[action]")]
public class ResumeController : Controller
{
    [HttpGet]
    public ResumeEntity Get(string userId)
    {
        return null;
    }

    [HttpPost]
    public ResumeEntity Post(string userId, [FromBody] Resume preferences)
    {
        return null;
    }
}
