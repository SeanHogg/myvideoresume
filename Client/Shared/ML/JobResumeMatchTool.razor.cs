using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using MyVideoResume.Abstractions;
using Microsoft.Identity.Client;

namespace MyVideoResume.Client.Shared.ML;

public partial class JobResumeMatchTool
{

    [Inject]
    protected HttpClient Http { get; set; }

    [Inject]
    protected ILogger<SummarizeResumeTool> Logger { get; set; }

    [Inject]
    protected ILocalStorageService localStorage { get; set; }

    [Inject]
    protected IJSRuntime JS { get; set; }


    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    public string Result { get; set; } = "";
    public bool Busy { get; set; }
    public string Resume { get; set; }
    public string JobDescription { get; set; }

    private async Task JobResumeMatchAsync()
    {
        try
        {
            var uri = new Uri($"{NavigationManager.BaseUri}prompt/match");
            Http.Timeout = TimeSpan.FromMinutes(10);
            Busy = true;
            var request = new JobMatchRequest() { Job = JobDescription, Resume = Resume };
            var response = await Http.PostAsJsonAsync<JobMatchRequest>(uri, request);
            var r = await response.ReadAsync<PromptResult>();
            Result = r.Result;
            Busy = false;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            Result = "Coming Soon";
        }
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Resume = await localStorage.GetItemAsync<string>("textresume");
        }
        catch (InvalidOperationException ex)
        {
            Logger.LogError(ex.Message, ex);
        }
        await base.OnInitializedAsync();
    }
}
