using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Data.Dtos;

namespace MyVideoResume.AI;

[Route("[controller]")]
public class PromptController : Controller
{
    public IPromptEngine Engine { get; set; }

    public PromptController(IPromptEngine engine)
    {
        // Get the ML Model Engine injected, for scoring
        Engine = engine;
    }

    [HttpPost]
    [Route("summarize")]
    public async Task<ActionResult<PromptResult>> SummarizeResumePost([FromBody] string resumeText)
    {
        var prompt = "You are an AI Assistant that helps people summarize thier resume.";
        var result = await Engine.Process(prompt, resumeText);
        return result;
    }

    [HttpPost]
    [Route("match")]
    public async Task<ActionResult<PromptResult>> JobResumeMatchPost([FromBody] JobMatchRequest request)
    {
        var prompt = "You are an AI Assistant that helps people match thier Resume to a Job Description.";
        var userInput = $"Resume: {request.Resume}";
        var userJobInput = $"Job Description: {request.Job}";
        var result = await Engine.Process(prompt, new[] { userInput, userJobInput });
        return result;
    }
}
