using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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


    public async Task<PromptResult> CreateResume(string userId, string resumeText)
    {
        var result = new PromptResult() { };

        try
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                var profile = _dataContext.UserProfiles.FirstOrDefault(x => x.UserId == userId);
                if (profile != null)
                {
                    if (profile.Resumes == null)
                        profile.Resumes = new List<MetaResumeEntity>();

                    //Parse the string Resume JSON into Data Structure
                    var resume = JsonSerializer.Deserialize<JSONResume>(resumeText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    resume.UserId = userId;

                    JSONResumeMetaResumeMapper jSONResumeMetaResumeMapper = new JSONResumeMetaResumeMapper();

                    var metaResume = jSONResumeMetaResumeMapper.JSONResumeToMetaResume(resume);

                    profile.Resumes.Add(metaResume);
                    _dataContext.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }
}
