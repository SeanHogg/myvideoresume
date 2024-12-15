using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.Abstractions.Resume;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace MyVideoResume.Data.Models.Resume;

[Table("ResumeInformation")]
public class ResumeInformationEntity : ResumeInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [JsonIgnore]
    [InverseProperty("ResumeInformation")]
    public MetaResumeEntity MetaResume { get; set; }

    [JsonIgnore]
    public UserProfileEntity UserProfile { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<MetaDataEntity> MetaData { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public ResumeTemplateEntity? ResumeTemplate { get; set; }
}
