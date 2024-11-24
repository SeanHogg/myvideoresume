using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.App;

public partial class Dashboard
{
    [Inject]
    protected ILogger<Dashboard> Console { get; set; }

    RadzenUpload upload;
    RadzenUpload uploadDD;

    int progress;
    bool showProgress;
    bool showComplete;
    string completionMessage;
    bool cancelUpload = false;

    void CompleteUpload(UploadCompleteEventArgs args)
    {
        if (!args.Cancelled)
            completionMessage = "Upload Complete!";
        else
            completionMessage = "Upload Cancelled!";

        showProgress = false;
        showComplete = true;
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