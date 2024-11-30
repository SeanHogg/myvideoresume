using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.ResumeAbstractions;
using MyVideoResume.ResumeAbstractions.Formats.JSONResumeFormat;
using MyVideoResume.Abstractions;

namespace MyVideoResume.Data.Models.Resume;

[Table("JSONResumes")]
public class JSONResumeFormatEntity : ResumeFormatEntity<JSONResume> { }

public class ResumeFormatEntity<T>: CommonBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public T ResumeStructure { get; set; }
}
