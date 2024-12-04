using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using MyVideoResume.Abstractions.Core;

namespace MyVideoResume.Client.Shared.ML;

public partial class SummarizeResumeTool
{
    [Inject]
    protected ILogger<SummarizeResumeTool> Logger { get; set; }

    [Inject]
    protected ILocalStorageService localStorage { get; set; }

    public string Result { get; set; } = "";
    public bool Busy { get; set; }
    public string Resume { get; set; }

    private async Task SummarizeAsync()
    {
        try
        {
            var uri = new Uri($"{NavigationManager.BaseUri}resume/summarize");
            Http.Timeout = TimeSpan.FromMinutes(10);
            Busy = true;
            var response = await Http.PostAsJsonAsync<string>(uri, Resume);
            var r = await response.ReadAsync<ResponseResult>();
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
