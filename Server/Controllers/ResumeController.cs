using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.AI;
using MyVideoResume.Application.Resume;
using MyVideoResume.Data.Models;
using MyVideoResume.Data.Models.Resume;
using MyVideoResume.Services;
using System.Security.Claims;

namespace MyVideoResume.Server.Controllers;

[Route("[controller]")]
public class ResumeController : Controller
{

    private readonly IResumePromptEngine _engine;
    private readonly ILogger<ResumeController> _logger;
    private readonly ResumeService _resumeService;

    public ResumeController(IResumePromptEngine engine, ILogger<ResumeController> logger, ResumeService resumeService)
    {
        _logger = logger;
        _engine = engine;
        _resumeService = resumeService;
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
                result = await _engine.ResumeParseJSON(file);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Result = ex.Message;
        }
        return result;
    }

    [HttpPost]
    [Route("createFromFile")]
    public async Task<ActionResult<PromptResult>> ParseToJsonCreate(IFormFile file)
    {
        var result = new PromptResult();
        try
        {
            if (file != null)
            {
                result = await _engine.ResumeParseJSON(file);

                //Lets Verify if the user is logged in.. If so, we'll create a resume.
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //Remove the Markdown from the Response
                var resume = result.Result;
                result = await _resumeService.CreateResume(id, resume);
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
