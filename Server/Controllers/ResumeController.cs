using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVideoResume.Abstractions.Core;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.AI;
using MyVideoResume.Application.Resume;
using MyVideoResume.Client.Services;
using MyVideoResume.Data.Models;
using MyVideoResume.Data.Models.Resume;
using MyVideoResume.Documents;
using MyVideoResume.Services;
using System.Security.Claims;

namespace MyVideoResume.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class ResumeController : ControllerBase
{
    private readonly IResumePromptEngine _engine;
    private readonly ILogger<ResumeController> _logger;
    private readonly ResumeService _resumeService;
    private readonly DocumentProcessor _documentProcessor;

    public ResumeController(IResumePromptEngine engine, ILogger<ResumeController> logger, ResumeService resumeService, DocumentProcessor documentProcessor)
    {
        _logger = logger;
        _engine = engine;
        _resumeService = resumeService;
        _documentProcessor = documentProcessor;
    }

    [HttpGet("{resumeId}")]
    public async Task<ActionResult<MetaResumeEntity>> Get(string resumeId)
    {
        var result = new MetaResumeEntity();
        try
        {
            result = await _resumeService.GetResume(resumeId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<MetaResumeEntity>>> Get()
    {
        var result = new List<MetaResumeEntity>();
        try
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            result = await _resumeService.GetResumes(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }

    [Authorize]
    [HttpPost("{resumeId}")]
    public async Task<ActionResult<ResponseResult>> Delete(string resumeId)
    {
        var result = new ResponseResult();
        try
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            result = await _resumeService.DeleteResume(id, resumeId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.Result = ex.Message;
        }
        return result;
    }

    [HttpPost("Summarize")]
    public async Task<ActionResult<ResponseResult>> Summarize([FromBody] string resumeText)
    {
        var result = new ResponseResult();
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

    [HttpPost("Match")]
    public async Task<ActionResult<ResponseResult>> Match([FromBody] JobMatchRequest request)
    {
        var result = new ResponseResult();
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

    [HttpPost("Parse")]
    public async Task<ActionResult<ResponseResult>> Parse(IFormFile file)
    {
        var result = new ResponseResult();
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

    [Authorize]
    [HttpPost("CreateFromFile")]
    public async Task<ActionResult<ResponseResult>> CreateFromFile(IFormFile file)
    {
        var result = new ResponseResult();
        try
        {
            if (file != null)
            {
                //Lets Verify if the user is logged in.. If so, we'll create a resume.
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

                switch (file.ContentType)
                {
                    case "application/json":
                        {
                            var resumeJson = _documentProcessor.JSONToString(file.OpenReadStream());
                            result = await _resumeService.CreateResume(id, resumeJson);
                            break;
                        }
                    case "application/pdf":
                        {
                            result = await _engine.ResumeParseJSON(file);

                            //Remove the Markdown from the Response
                            var resume = result.Result;
                            result = await _resumeService.CreateResume(id, resume);

                            break;
                        }
                    case "application/msword":
                        break;
                    default:
                        {
                            break;
                        }
                }
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
