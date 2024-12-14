using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.Abstractions.Resume.Formats.JSONResumeFormat;
using Riok.Mapperly.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MyVideoResume.Data.Models.Resume;

[Table("MetaResumes")]
public class MetaResumeEntity : JSONResume
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public bool IsPublic { get; set; } = true;

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public List<MetaDataEntity> MetaData { get; set; }

    [ForeignKey("Resume")]
    [DeleteBehavior(DeleteBehavior.Restrict)] 
    public ResumeInformationEntity ResumeInformation { get; set; }
    
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ResumeTemplateEntity? ResumeTemplate { get; set; }

    public DateTime? CreationDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
    public DateTime? DeletedDateTime { get; set; }

}

