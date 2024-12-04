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

[Route("Resume/[action]")]
public partial class ResumeController : Controller
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

    [Authorize]
    [HttpPost]
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

    [HttpPost]
    public async Task<ActionResult<ResponseResult>> summarize([FromBody] string resumeText)
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

    [HttpPost]
    public async Task<ActionResult<ResponseResult>> match([FromBody] JobMatchRequest request)
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

    [HttpPost]
    public async Task<ActionResult<ResponseResult>> parse(IFormFile file)
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
    [HttpPost]
    public async Task<ActionResult<ResponseResult>> createFromFile(IFormFile file)
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
