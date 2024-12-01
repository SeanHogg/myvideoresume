using MyVideoResume.Data.Models;

namespace MyVideoResume.Application.Job;

public interface IJobService {

   Task<JobPreferencesEntity> GetJobPreferences(string userId);
}

public partial class JobService : IJobService
{
    public JobService() { }

    public async Task<JobPreferencesEntity> GetJobPreferences(string userId)
    {
        throw new NotImplementedException();
    }
}
