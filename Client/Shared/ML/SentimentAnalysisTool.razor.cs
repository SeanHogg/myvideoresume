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
using System.Net.Http.Json;

namespace MyVideoResume.Client.Shared.ML;

public partial class SentimentAnalysisTool
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Parameter]
    public float happiness { get; set; } = 50; // 0=worst, 100=best

    private async Task UpdateScoreAsync(ChangeEventArgs e)
    {
        string targetText = (string)e.Value;
        // Make a real call to Sentiment service
        happiness = await PredictSentimentAsync(targetText);
    }

    private async Task<float> PredictSentimentAsync(string targetText)
    {
        var uri = new Uri($"{NavigationManager.BaseUri}Sentiment/sentimentprediction?sentimentText={targetText}");

        float percentage = await Http.GetFromJsonAsync<float>(uri);

        return percentage;
    }
}
