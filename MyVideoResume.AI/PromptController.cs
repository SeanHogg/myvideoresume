using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Data.Dtos;

namespace MyVideoResume.AI;

[Route("[controller]")]
public class PromptController : Controller
{
    public PromptEngine Engine { get; set; }

    public PromptController(PromptEngine engine)
    {
        // Get the ML Model Engine injected, for scoring
        Engine = engine;
    }

    [HttpPost]
    [Route("summarize")]
    public ActionResult<PromptResult> SummarizeResumePost([FromBody] string resumeText)
    {
        var prompt = "You are an AI Assistant that helps people summarize thier resume by focusing on thier work history and accomplishments. Summarize the content into a paragraph.";
        var result = Engine.Process(prompt, resumeText);
        return result;
    }
}
