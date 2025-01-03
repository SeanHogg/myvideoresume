﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace MyVideoResume.Client.Shared.ML;

public partial class SentimentAnalysisTool
{
    [Inject]
    protected ILogger<SentimentAnalysisTool> Logger { get; set; }

    [Inject]
    protected ILocalStorageService localStorage { get; set; }

    [Parameter]
    public float happiness { get; set; } = 50; // 0=worst, 100=best

    public string resume { get; set; }

    private async Task UpdateScoreAsync(ChangeEventArgs e)
    {
        string targetText = (string)e.Value;
        // Make a real call to Sentiment service
        happiness = await PredictSentimentAsync(targetText);
    }

    private async Task<float> PredictSentimentAsync(string targetText)
    {
        var textResume = await localStorage.GetItemAsync<string>("textresume");
        if (string.IsNullOrEmpty(targetText) && !string.IsNullOrWhiteSpace(textResume))
        {
            resume = textResume;
            StateHasChanged();
        }
        else
        {
            resume = targetText;
        }

        float percentage = 0;
        try
        {
            var uri = new Uri($"{NavigationManager.BaseUri}sentiment/sentimentprediction");
            var response = await Http.PostAsJsonAsync<string>(uri, resume);
            percentage = await response.ReadAsync<float>();
            await localStorage.SetItemAsync("textresume", resume);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
        }
        return percentage;
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        try
        {
            resume = await localStorage.GetItemAsync<string>("textresume");
            if (!string.IsNullOrEmpty(resume))
            {
                happiness = await PredictSentimentAsync(resume);
            }
        }
        catch (InvalidOperationException ex)
        {
            Logger.LogError(ex.Message, ex);
        }
    }
}
