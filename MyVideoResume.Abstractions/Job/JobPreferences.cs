using MyVideoResume.Abstractions.Core;
using System.ComponentModel;

namespace MyVideoResume.Abstractions.Job;

public enum Industry
{
    [Description("Accounting Finance")]
    AccountingFinance = 0,
    [Description("Administration")]
    Administration = 1,
    [Description("Art Design")]
    ArtDesign = 2,
    [Description("Business Sales")]
    BusinessSales = 3,
    [Description("Construction")]
    Construction = 4,
    [Description("Education")]
    Education = 5,
    [Description("Engineering")]
    Engineering = 6,
    [Description("Food Production")]
    FoodProduction = 7,
    [Description("Healthcare")]
    Healthcare = 8,
    [Description("Human Resources")]
    HumanResources = 9,
    [Description("IT")]
    IT = 10,
    [Description("Legal")]
    Legal = 11,
    [Description("Management")]
    Management = 12,
    [Description("Manufacturing")]
    Manufacturing = 13,
    [Description("Marketing / Public Relations (PR)")]
    MarketingPR = 14,
    [Description("Retail Customer Service")]
    RetailCustomerService = 15,
    [Description("Science")]
    Science = 16,
    [Description("Software Engineering")]
    SoftwareEngineering = 17,
    [Description("Transportation Logistics")]
    TransportationLogistics = 18,
    [Description("Hospitality")]
    Hospitality = 19,
    [Description("Government")]
    Government = 20
}

public enum ExperienceLevel
{
    [Description("Entry")]
    Entry = 0,
    [Description("Junior")]
    Junior = 1,
    [Description("Mid-Career")]
    Mid = 2,
    [Description("Senior")]
    Senior = 3,
    [Description("Executive")]
    LeadExecutive = 4,
    [Description("None")]
    None = 5
}

public enum JobType
{
    [Description("Full-Time")]
    FullTime = 0,
    [Description("Part-Time")]
    PartTime = 1,
    [Description("Freelance")]
    Freelance = 2,
    [Description("Contractor")]
    Contractor = 3,
    [Description("Contract-To-Hire")]
    ContractToHire = 4,
    [Description("Temporary")]
    Temporary = 5,
    [Description("Internship")]
    Internship = 6
}

public enum WorkSetting
{
    [Description("Onsite")]
    Onsite = 0,
    [Description("Remote")]
    Remote = 1,
    [Description("Hybrid")]
    Hybrid = 2
}



public class JobPreferences : CommonBase
{
    public string? UserHandle { get; set; }
    public Industry Industry { get; set; } = Industry.Management;
    public ExperienceLevel Seniority { get; set; } = ExperienceLevel.Entry;
    public List<JobType> EmploymentType { get; set; } = new List<JobType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public string UserId { get; set; }
    public List<WorkSetting> WorkSetting { get; set; } = new List<WorkSetting>();
}
