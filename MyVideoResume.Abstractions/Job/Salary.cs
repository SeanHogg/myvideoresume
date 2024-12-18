﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Job;

public enum PaySchedule
{
    Hourly, Daily, Weekly, BiWeekly, Monthly, Quarterly, Yearly
}

public class Salary
{
    public string UserId { get; set; }
    public string Description { get; set; }
    public PaySchedule PaySchedule { get; set; } = PaySchedule.Yearly;
    public float MinimumSalary { get; set; }
    public float MaximumSalary { get; set; }
}
