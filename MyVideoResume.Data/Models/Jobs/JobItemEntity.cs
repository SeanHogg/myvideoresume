using MyVideoResume.Abstractions.Business;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.Data.Models.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Data.Models.Jobs;

[Table("Jobs")]
public class JobItemEntity : JobItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public CompanyProfileEntity Company { get; set; }


}
