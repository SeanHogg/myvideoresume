using MyVideoResume.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Job;


public enum JobStatus
{
    Draft,
    Open,
    Closed,
    Hired
}
public class JobItem : CommonBase
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Industry> Industry { get; set; }
    public List<ExperienceLevel> Seniority { get; set; } 
    public List<JobType> EmploymentType { get; set; } = new List<JobType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public float MaximumSalary { get; set; }

    public DateTime GoLiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public JobStatus Status { get; set; }
}