﻿using MyVideoResume.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.ResumeAbstractions;
public enum ResumeType
{
    JSONResumeFormat
}

public class ResumeDocument : CommonBase
{
    public string UserId { get; set; }

    public Industry Industry { get; set; } = Industry.Management;
    public List<JobType> EmploymentType { get; set; } = new List<JobType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public ResumeType ResumeType { get; set; }
    public string ResumeSerialized { get; set; }
}