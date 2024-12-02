using MyVideoResume.Abstractions.Resume.Formats.JSONResumeFormat;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoResume.Data.Models.Resume;

[Mapper]
public partial class JSONResumeMetaResumeMapper
{
    public partial MetaResumeEntity JSONResumeToMetaResume(JSONResume resume);
}