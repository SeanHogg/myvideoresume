using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using MyVideoResume.Data.Dtos;
using Radzen.Blazor;
using System;
using MyVideoResume.Documents;
using System.Reflection.Metadata;
using System.Net.Http;
using System.Dynamic;
using System.Text.Json;
using MyVideoResume.Data.Models;

namespace MyVideoResume.Client.Shared.ML;

public partial class ResumeToJSONConverterTool
{

    [Inject]
    protected HttpClient Http { get; set; }

    [Inject]
    protected ILogger<ResumeToJSONConverterTool> Logger { get; set; }

    [Inject]
    protected ILocalStorageService localStorage { get; set; }

    [Inject]
    protected IJSRuntime JS { get; set; }


    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    public string Result { get; set; } = "Upload Resume";
    public bool Busy { get; set; }
    public string Resume { get; set; }

    public bool DisableDownload { get; set; } = true;

    int progress;
    bool showProgress;
    bool showComplete;
    string completionMessage;
    bool cancelUpload = false;

    async Task CompleteUpload(UploadCompleteEventArgs args)
    {
        if (!args.Cancelled)
            completionMessage = "Upload Complete!";
        else
            completionMessage = "Upload Cancelled!";

        if (!string.IsNullOrWhiteSpace(args.RawResponse))
        {
            dynamic data = JsonSerializer.Deserialize<ExpandoObject>(args.RawResponse);
            Result = data.result.ToString();
            DisableDownload = false;
        }
        progress = 100;

        showProgress = false;
        showComplete = true;

    }

    private async Task DownloadFile()
    {
        var temp = Result;
        temp = temp.Replace("```json", "").Replace("``` ", "");
        await JS.InvokeVoidAsync("saveTextAsFile", temp, "JsonResume");
    }

    async Task TrackProgress(UploadProgressArgs args)
    {
        showProgress = true;
        showComplete = false;
        progress = args.Progress - 10;

        // cancel upload
        args.Cancel = cancelUpload;

        // reset cancel flag
        cancelUpload = false;
    }

    void CancelUpload()
    {
        cancelUpload = true;
    }
}
