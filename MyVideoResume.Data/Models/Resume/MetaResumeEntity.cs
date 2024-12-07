using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.Abstractions.Resume.Formats.JSONResumeFormat;
using Riok.Mapperly.Abstractions;

namespace MyVideoResume.Data.Models.Resume;

[Table("MetaResumes")]
public class MetaResumeEntity : JSONResume
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public bool? IsPublic { get; set; } = true;

    public List<MetaDataEntity> MetaData { get; set; }

    [ForeignKey("Resume")]
    public ResumeInformationEntity ResumeInformation { get; set; }
    public ResumeTemplateEntity? ResumeTemplate { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? UpdateTime { get; set; }
    public DateTime? DeletedTime { get; set; }

}

