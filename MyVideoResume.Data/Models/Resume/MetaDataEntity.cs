using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.Abstractions.Resume.Formats.MyVideoResumeFormat;

namespace MyVideoResume.Data.Models.Resume;

[Table("MetaData")]
public class MetaDataEntity : MetaData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
