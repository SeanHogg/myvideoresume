using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVideoResume.Abstractions.Resume;

namespace MyVideoResume.Data.Models.Resume
{
    [Table("ResumeTemplates")]
    public class ResumeTemplateEntity : ResumeTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public static ResumeTemplateEntity CreateStandardResumeTemplate()
        {
            return new ResumeTemplateEntity { Id = Guid.NewGuid(), Name = "Standard Template", Description = "Standard Template that displays the resume in chronological order", TransformerComponentName = "StandardTemplate", Namespace = "MyVideoResume.Client.Pages.App.People.Resumes.Templates", CreationDateTime = DateTime.UtcNow };
        }
    }
}
