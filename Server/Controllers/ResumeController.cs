using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.AI;
using MyVideoResume.Application.Resume;
using MyVideoResume.Data.Models.Resume;

namespace MyVideoResume.Server.Controllers;

[Route("[controller]")]
public class ResumeController : Controller
{

    private readonly IResumePromptEngine _engine;
    private readonly ILogger<ResumeController> _logger;

    public ResumeController(IResumePromptEngine engine, ILogger<ResumeController> logger)
    {
        _logger = logger;
        _engine = engine;
    }

    [HttpPost]
    [Route("summarize")]
    public async Task<ActionResult<PromptResult>> SummarizeResume([FromBody] string resumeText)
    {
        var result = new PromptResult();
        try
        {
            result = await _engine.SummarizeResume(resumeText);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Result = ex.Message;
        }
        return result;
    }

    [HttpPost]
    [Route("match")]
    public async Task<ActionResult<PromptResult>> JobResumeMatchPost([FromBody] JobMatchRequest request)
    {
        var result = new PromptResult();
        try
        {
            result = await _engine.JobResumeMatch(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Result = ex.Message;
        }
        return result;
    }
    [HttpPost]
    [Route("parse")]
    public async Task<ActionResult<PromptResult>> ParseToJson(IFormFile file)
    {
        var result = new PromptResult();
        try
        {
            if (file != null)
            {
                var conversion = await _engine.ResumeParseJSON(file);
                result = conversion;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Result = ex.Message;
        }
        return result;
    }
}
