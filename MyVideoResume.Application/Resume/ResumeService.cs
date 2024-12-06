using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyVideoResume.Abstractions.Core;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Abstractions.Resume.Formats.JSONResumeFormat;
using MyVideoResume.AI;
using MyVideoResume.Data;
using MyVideoResume.Data.Models.Resume;
using MyVideoResume.Documents;
using System.Dynamic;
using System.Text.Json;

namespace MyVideoResume.Application.Resume;

public class ResumeService
{
    private readonly ILogger<ResumeService> _logger;
    private readonly DataContext _dataContext;
    private readonly IConfiguration _configuration;

    public ResumeService(ILogger<ResumeService> logger, IConfiguration configuration, DataContext context)
    {
        _dataContext = context;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<MetaResumeEntity> GetResume(string resumeId)
    {
        var result = new MetaResumeEntity();
        try
        {
            //Is it a slug?
            var info = _dataContext.ResumeInformation.FirstOrDefault(x => x.Slug == resumeId);
            if (info != null)
            {
                if (info.Resume.IsPublic == true)
                    result = info.Resume;
            }
            else
            {
                Guid guid;
                if (Guid.TryParse(resumeId, out guid))
                {
                    result = _dataContext.Resumes.FirstOrDefault(x => x.Id == guid && x.IsPublic == true);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }

    public async Task<List<MetaResumeEntity>> GetResumes(string userId)
    {
        var result = new List<MetaResumeEntity>();
        try
        {
            result = await _dataContext.Resumes.Where(x => x.UserId == userId).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }

    public async Task<ResponseResult> DeleteResume(string userId, string resumeId)
    {

        var result = new ResponseResult();
        try
        {
            if (await _dataContext.Resumes.Where(x => x.Id == Guid.Parse(resumeId) && x.UserId == userId).ExecuteDeleteAsync() > 0)
                result.Result = "Operation Successful";
            else
                result.ErrorMessage = "Failed to Delete Resume";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.ErrorMessage = ex.Message;
        }
        return result;
    }

    public async Task<ResponseResult> CreateResume(string userId, string resumeText)
    {
        var result = new ResponseResult() { };

        try
        {
            if (!string.IsNullOrWhiteSpace(userId)) //should validate that its a real user account...
            {
                var profile = _dataContext.UserProfiles.Include(x => x.Resumes).FirstOrDefault(x => x.UserId == userId);
                if (profile != null)
                {
                    if (profile.Resumes == null)
                        profile.Resumes = new List<MetaResumeEntity>();

                    //Save the Resume to get an object to populate into 
                    var tempresume = JsonSerializer.Deserialize<MetaResumeEntity>(resumeText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    var resumeInformation = new ResumeInformationEntity() { UserId = userId, ResumeSerialized = resumeText };
                    tempresume.ResumeInformation = resumeInformation;
                    tempresume.UserId = userId;
                    profile.Resumes.Add(tempresume);
                    _dataContext.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            result.ErrorMessage = ex.Message;
        }
        return result;
    }
}
