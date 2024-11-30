using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Data.Models.Resume;
using MyVideoResume.ResumeAbstractions;

namespace MyVideoResume.Server.Controllers;

[Route("Account/{userId}/Resume/[action]")]
public class ResumeController : Controller
{
    [HttpGet]
    public ResumeDocumentEntity Get(string userId)
    {
        return null;
    }

    [HttpPost]
    public ResumeDocumentEntity Post(string userId, [FromBody] ResumeDocument preferences)
    {
        return null;
    }
}
