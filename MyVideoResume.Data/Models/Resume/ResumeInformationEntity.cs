using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.Abstractions.Resume;
using Microsoft.EntityFrameworkCore;

namespace MyVideoResume.Data.Models.Resume;

[Table("ResumeInformation")]
public class ResumeInformationEntity : ResumeInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [InverseProperty("ResumeInformation")]
    public MetaResumeEntity Resume { get; set; }

}
