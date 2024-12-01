using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Data.Models.Resume;
using MyVideoResume.ResumeAbstractions;

namespace MyVideoResume.Server.Controllers;

[Route("Account/{userId}/Resume/[action]")]
public class ResumeController : Controller
{
    [HttpGet]
    public MetaResumeEntity Get(string userId)
    {
        return null;
    }

    [HttpPost]
    public MetaResumeEntity Post(string userId, [FromBody] ResumeInformation preferences)
    {
        return null;
    }
}
