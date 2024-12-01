using MyVideoResume.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Job;

public class JobItem : CommonBase
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}