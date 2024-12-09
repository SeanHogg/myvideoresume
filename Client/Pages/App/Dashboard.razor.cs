using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MyVideoResume.Abstractions.Core;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.Client.Services;
using MyVideoResume.Client.Shared.Resume;
using MyVideoResume.Data;
using MyVideoResume.Data.Models.Resume;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.App;

public partial class Dashboard
{
    [Inject]
    protected DashboardWebService Service { get; set; }

    [Inject]
    protected ILogger<Dashboard> Console { get; set; }

    List<ResumeSummaryItem> ResumeList { get; set; } = new List<ResumeSummaryItem>();
    ResumeUploadToJsonComponent ResumeUploadToJsonComponent { get; set; }
    RadzenUpload uploadDD;

    int progress;
    bool showProgress;
    bool showComplete;
    string completionMessage;
    bool cancelUpload = false;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (Security.IsAuthenticated())
            ResumeList = await Service.GetResumeSummaries();
    }

    async Task DeleteCompletedHandler(ResponseResult result)
    {
        if (!string.IsNullOrWhiteSpace(result.ErrorMessage))
        {
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error Summary", Detail = result.ErrorMessage, Duration = 4000 });
        }
        else
        {
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Resume Deleted", Detail = result.ErrorMessage, Duration = 4000 });

            ResumeList = await Service.GetResumeSummaries();
            StateHasChanged();
        }
    }

    async Task UploadCompletedHandler(string result)
    {
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Resume Created", Detail = result, Duration = 4000 });

        ResumeList = await Service.GetResumeSummaries();
    }
}