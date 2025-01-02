using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.Application.Resume;
using MyVideoResume.Data;
using MyVideoResume.Data.Models;

namespace MyVideoResume.Application.Job;

public partial class JobService
{
    private readonly ILogger<JobService> _logger;
    private readonly DataContext _dataContext;
    private readonly IConfiguration _configuration;
    private readonly AccountService _accountService;

    public JobService(ILogger<JobService> logger, IConfiguration configuration, DataContext context, AccountService accountService)
    {
        _dataContext = context;
        _logger = logger;
        _configuration = configuration;
        _accountService = accountService;
    }

    public async Task<JobPreferencesEntity> GetJobPreferences(string userId)
    {
        throw new NotImplementedException();
    }

    //Get All Public Resume Summaries
    public async Task<List<JobSummaryItem>> GetJobSummaryItems(string? userId = null, bool? onlyPublic = null)
    {
        var result = new List<JobSummaryItem>();
        try
        {
            var query = _dataContext.Jobs
                .AsNoTracking()
                .Where(x => x.DeletedDateTime == null);

            if (onlyPublic.HasValue)
            {
                query = query.Where(x => x.Status == JobStatus.Open);
            }

            if (!string.IsNullOrEmpty(userId))
            {
                query = query.Where(x => x.UserId == userId);
            }

            result = query.Select(x => new JobSummaryItem() { UserId = x.UserId, CreationDateTimeFormatted = x.CreationDateTime.Value.ToString("yyyy-MM-dd"), Id = x.Id.ToString(), Responsibilities = x.Responsibilities, Requirements = x.Requirements, Slug = x.Slug, Title = x.Title, Description = x.Description, ATSApplyUrl = x.ATSApplyUrl, OriginalWebsiteUrl = x.OriginalWebsiteUrl }).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }


}
