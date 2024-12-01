using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using MyVideoResume.Abstractions;
using Radzen.Blazor;
using System;
using MyVideoResume.Documents;
using System.Reflection.Metadata;
using System.Net.Http;
using System.Dynamic;
using System.Text.Json;
using MyVideoResume.Data.Models;
using MyVideoResume.Client.Shared.Resume;

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

    public bool DisableDownload { get; set; } = true;
    public string Result { get; set; } = "Upload";


    public ResumeUploadToJsonComponent ResumeUploadToJsonComponent { get; set; }


    private async Task DownloadFile()
    {
        var temp = Result;
        temp = temp.Replace("```json", "").Replace("``` ", "");
        await JS.InvokeVoidAsync("saveTextAsFile", temp, "JsonResume");
    }

    private async Task UploadCompletedHandler(string result)
    {
        Result = result;
        DisableDownload = false;
    }

}
