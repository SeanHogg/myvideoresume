using MyVideoResume.Abstractions;
using MyVideoResume.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Resume;
public enum ResumeType
{
    JSONResumeFormat
}

public class ResumeInformation : CommonBase
{
    public string UserId { get; set; }

    public Industry Industry { get; set; } = Industry.Management;
    public List<JobType> EmploymentType { get; set; } = new List<JobType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public ResumeType ResumeType { get; set; }
    public string ResumeSerialized { get; set; }
}