using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.ResumeAbstractions;
using MyVideoResume.ResumeAbstractions.Formats.JSONResumeFormat;
using MyVideoResume.Abstractions;
using MyVideoResume.ResumeAbstractions.Formats.MyVideoResumeFormat;

namespace MyVideoResume.Data.Models.Resume;

[Table("MetaResumes")]
public class MetaResumeEntity : JSONResume
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public List<MetaDataEntity> MetaData { get; set; }

    public ResumeInformationEntity ResumeInformation { get; set; }

}

