using MyVideoResume.Abstractions;
using MyVideoResume.Data.Models.Resume;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Data.Models;

[Table("UserAccounts")]

public class UserAccountEntity: CommonBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public JobPreferencesEntity JobPreferences { get; set; }

    public List<MetaResumeEntity> Resumes { get; set; }
}
