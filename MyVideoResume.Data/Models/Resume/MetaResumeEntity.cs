using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyVideoResume.Data.Models.Resume;

[Table("MetaResumes")]
public class MetaResumeEntity : Abstractions.Resume.Formats.JSONResumeFormat.JSONResume
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public List<MetaDataEntity> MetaData { get; set; }

    public ResumeInformationEntity ResumeInformation { get; set; }
    public ResumeTemplateEntity? ResumeTemplate { get; set; }

}

