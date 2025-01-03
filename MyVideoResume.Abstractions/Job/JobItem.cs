﻿using MyVideoResume.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Job;

public enum JobOrigin
{
    JobSeeker,
    Employer,
    Crawler
}


public enum JobStatus
{
    Draft,
    Open,
    Closed,
    Hired
}

public class JobBase : CommonBase
{
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public List<string>? Responsibilities { get; set; }
    [JsonIgnore, NotMapped]
    public string ResponsibilitiesFlattened
    {
        get => String.Join(Environment.NewLine, Responsibilities);
        set
        {
            Responsibilities.Clear();
            string[] val;
            if (value.Contains("\n"))
                val = value.Split("\n");
            else
                val = value.Split(Environment.NewLine);
            Responsibilities.AddRange(val);
        }
    }
    public List<string>? Requirements { get; set; }
    [JsonIgnore, NotMapped]
    public string RequirementsFlattened
    {
        get => String.Join(Environment.NewLine, Requirements);
        set
        {
            Requirements.Clear();
            string[] val;
            if (value.Contains("\n"))
                val = value.Split("\n");
            else
                val = value.Split(Environment.NewLine);
            Requirements.AddRange(val);
        }
    }

    public string? OriginalWebsiteUrl { get; set; }
    public string? ATSApplyUrl { get; set; }
}

public class JobItem : JobBase
{
    public string UserId { get; set; }
    public List<Industry>? Industry { get; set; }
    public List<ExperienceLevel>? Seniority { get; set; }
    public List<JobType>? EmploymentType { get; set; } = new List<JobType>();
    public WorkSetting WorkSetting { get; set; } = WorkSetting.Onsite;
    public DateTime? GoLiveDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public JobStatus? Status { get; set; }
    public int? HiringTarget { get; set; } = null;
}
