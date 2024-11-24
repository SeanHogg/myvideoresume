using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyVideoResume.Data.Models;



public class Resume : CommonBase
{
    public Industry Industry { get; set; } = Industry.Management;
    public List<JobType> EmploymentType { get; set; } = new List<JobType>();
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public string UserId { get; set; }
    public string ResumeSerialized { get; set; }
}

[Table("Resumes")]
public class ResumeEntity : Resume
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
