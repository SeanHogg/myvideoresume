using Microsoft.Extensions.Logging;
using MyVideoResume.Data;
using MyVideoResume.Data.Models;

namespace MyVideoResume.Application;

public class AccountService
{

    private readonly DataContext _dataContext;

    private readonly ILogger<AccountService> logger;

    public AccountService(DataContext dataContextService, ILogger<AccountService> logger)
    {
        this._dataContext = dataContextService;
        this.logger = logger;
    }

    public async Task<UserProfileEntity> CreateProfile(string userId)
    {
        var profile = new UserProfileEntity();
        try
        {
            profile = _dataContext.UserProfiles.FirstOrDefault(x => x.UserId == userId);
            if (profile == null)
            {
                var jobPreferences = new JobPreferencesEntity() { UserId = userId, CreationDateTime = DateTime.UtcNow, UpdateDateTime = DateTime.UtcNow };
                _dataContext.JobPreferences.Add(jobPreferences);
                profile = new UserProfileEntity() { FirstName = string.Empty, LastName = String.Empty, UserId = userId, CreationDateTime = DateTime.UtcNow, UpdateDateTime = DateTime.UtcNow, JobPreferences = jobPreferences };
                _dataContext.UserProfiles.Add(profile);
                await _dataContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            throw;
        }

        return profile;
    }
}
