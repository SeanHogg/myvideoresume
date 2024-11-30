using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyVideoResume.Abstractions;

namespace MyVideoResume.Data.Models;

[Table("JobPreferences")]
public class JobPreferencesEntity : JobPreferences
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
