using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.ResumeAbstractions;

namespace MyVideoResume.Data.Models.Resume;

[Table("Resumes")]
public class ResumeDocumentEntity : ResumeDocument
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public JSONResumeFormatEntity JSONResumeFormat { get; set; }
}
