using MyVideoResume.Abstractions.Core;
using MyVideoResume.Data.Models.Resume;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MyVideoResume.Web.Common;

public static class Paths
{
    public const string Dashboard_View = "/dashboard";
    public const string Resume_View = "/resumes";
    public const string Resume_CreateNew = "resumes/builder/new";
    public const string Resume_Edit = "resumes/builder/";
    public const string Resume_API_CreateFromFile = "api/resume/createFromFile";
    public const string Resume_API_Save = "api/resume/save";
    public const string Resume_API_Parse = "api/resume/parse";
    public const string Jobs = "jobs";
}

public static class Extensions
{
    public static bool HasValue(this string value)
    {
        var result = !string.IsNullOrWhiteSpace(value);

        return result;
    }
}