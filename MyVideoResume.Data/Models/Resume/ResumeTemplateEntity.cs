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
    public class ResumeTemplateEntity: ResumeTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
