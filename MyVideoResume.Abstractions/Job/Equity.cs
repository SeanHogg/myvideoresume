using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Job;

public enum EquityType
{
    RSUs,
    Percentage
}

public class Equity
{
    public string UserId { get; set; }
    public string Description { get; set; }
    public EquityType EquityType { get; set; }
}
