﻿using MyVideoResume.Abstractions.Core;
using MyVideoResume.Data.Models.Resume;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MyVideoResume.Web.Common;

public static class Paths
{
    public const string FeatureFlags_API = "api/featureflag";
    public const string Dashboard_View = "/dashboard";
    public const string Resume_View = "/resumes";
    public const string Resume_CreateNew = "resumes/builder/new";
    public const string Resume_Edit = "resumes/builder/";
    public const string Resume_API_CreateFromFile = "api/resume/createFromFile";
    public const string Resume_API_Save = "api/resume/save";
    public const string Resume_API_Parse = "api/resume/parse";
    public const string Jobs_View = "/jobs";
    public const string Jobs_API_View = "api/job/GetPublicJobs";
    public const string Jobs_API_SummaryItems = "api/job/GetSummaryItems";
    public const string Jobs_API_ViewById = "api/job/{id}";
    public const string Jobs_API_Save = "api/job/save";
    public const string Jobs_API_Extract = "api/job/extract";
}

public static class Extensions
{
    public static bool HasValue(this string value)
    {
        var result = !string.IsNullOrWhiteSpace(value);

        return result;
    }
}