using System.ComponentModel.DataAnnotations.Schema;
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

public enum Seniority
{
    Entry,
    Junior,
    Mid,
    Senior,
    LeadExecutive
}

public enum EmploymentType
{
    FullTime,
    PartTime,
    Freelance,
    Internship
}

public enum PaySchedule
{
    Hourly, Weekly, BiWeekly, Monthly, Yearly
}

public class JobPreferences : CommonBase
{
    public Industry Industry { get; set; }
    public Seniority Seniority { get; set; } = Seniority.Entry;
    public List<EmploymentType> EmploymentType { get; set; } = new List<EmploymentType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    [Required]
    public string UserId { get; set; }
}

[Table("JobPreferences")]
public class JobPreferencesEntity : JobPreferences
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
