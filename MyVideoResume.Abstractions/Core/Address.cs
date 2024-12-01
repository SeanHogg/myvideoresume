using MyVideoResume.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Abstractions.Core;

public class Address : Location
{
    public string City { get; set; }

    public string Country { get; set; }

    public string Line1 { get; set; }

    public string Line2 { get; set; }

    public string PostalCode { get; set; }

    public string State { get; set; }
}
public class Location : CommonBase
{
    public int? Latitude { get; set; }
    public int? Longitude { get; set; }
    public string? Name { get; set; }
}