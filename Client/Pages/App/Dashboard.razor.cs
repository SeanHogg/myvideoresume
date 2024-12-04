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
    protected DashboardService Service { get; set; }

    [Inject]
    protected ILogger<Dashboard> Console { get; set; }

    List<MetaResumeEntity> ResumeList { get; set; } = new List<MetaResumeEntity>();
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
        ResumeList = await Service.GetResumes();
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

            ResumeList = await Service.GetResumes();
            StateHasChanged();
        }
    }

    async Task UploadCompletedHandler(string result)
    {
        ResumeList = await Service.GetResumes();
    }

    void TrackProgress(UploadProgressArgs args)
    {
        showProgress = true;
        showComplete = false;
        progress = args.Progress;

        // cancel upload
        args.Cancel = cancelUpload;

        // reset cancel flag
        cancelUpload = false;
    }

    void CancelUpload()
    {
        cancelUpload = true;
    }

    int customParameter = 1;

    void OnChange(UploadChangeEventArgs args, string name)
    {
        foreach (var file in args.Files)
        {
            Console.LogInformation($"File: {file.Name} / {file.Size} bytes");
        }

        Console.LogInformation($"{name} changed");
    }

    void OnProgress(UploadProgressArgs args, string name)
    {
        Console.LogInformation($"{args.Progress}% '{name}' / {args.Loaded} of {args.Total} bytes.");

        if (args.Progress == 100)
        {
            foreach (var file in args.Files)
            {
                Console.LogInformation($"Uploaded: {file.Name} / {file.Size} bytes");
            }
        }
    }

    void OnComplete(UploadCompleteEventArgs args)
    {
        Console.LogInformation($"Server response: {args.RawResponse}");
    }

    void OnClientChange(UploadChangeEventArgs args)
    {
        Console.LogInformation($"Client-side upload changed");

        foreach (var file in args.Files)
        {
            Console.LogInformation($"File: {file.Name} / {file.Size} bytes");

            try
            {
                long maxFileSize = 10 * 1024 * 1024;
                // read file
                var stream = file.OpenReadStream(maxFileSize);
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.LogInformation($"Client-side file read error: {ex.Message}");
            }
        }
    }
}