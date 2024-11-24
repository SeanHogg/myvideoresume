﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyVideoResume.Data.Models;

public enum Industry
{

    AccountingFinance,
    Administration,
    ArtDesign,
    BusinessSales,
    Construction,
    Education,
    Engineering,
    FoodProduction,
    HealthCare,
    HumanResources,
    IT,
    Legal,
    Management,
    Manufacturing,
    MarketingPR,
    RetailCustomerService,
    Science,
    SoftwareEngineering,
    TransportationLogistics,
    Hospitality,
    Government
}

public enum ExperienceLevel
{
    Entry,
    Junior,
    Mid,
    Senior,
    LeadExecutive,
    None
}

public enum JobType
{
    FullTime,
    PartTime,
    Freelance,
    Contractor,
    Temporary,
    Internship
}

public enum PaySchedule
{
    Hourly, Weekly, BiWeekly, Monthly, Yearly
}

public class JobPreferences : CommonBase
{
    public Industry Industry { get; set; } = Industry.Management;
    public ExperienceLevel Seniority { get; set; } = ExperienceLevel.Entry;
    public List<JobType> EmploymentType { get; set; } = new List<JobType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public string UserId { get; set; }
}

[Table("JobPreferences")]
public class JobPreferencesEntity : JobPreferences
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
