using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.AI;
using MyVideoResume.Data;
using MyVideoResume.Documents;

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
        return new PromptResult { };
    }
}
