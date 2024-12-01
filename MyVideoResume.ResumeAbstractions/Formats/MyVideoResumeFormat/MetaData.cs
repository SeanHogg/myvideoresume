using MyVideoResume.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyVideoResume.ResumeAbstractions.Formats.MyVideoResumeFormat;

public enum MetaType
{
    Hyperlink,
    Video,
    Image,
    Content
}

public class MetaData : CommonBase
{
    public string UserId { get; set; }

    public string ReferenceId { get; set; }
    public string Name { get; set; }
    public MetaType MetaType { get; set; } = MetaType.Content;
    public string Url { get; set; }
    public string Description { get; set; }
}
