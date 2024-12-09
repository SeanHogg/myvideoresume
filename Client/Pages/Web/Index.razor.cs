using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.Client.Services;
using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;

namespace MyVideoResume.Client.Pages.Web;

public partial class Index
{
    [Inject]
    protected ResumeWebService Service { get; set; }

    [Inject]
    protected ILogger<Index> Console { get; set; }

    List<ResumeSummaryItem> ResumeList { get; set; } = new List<ResumeSummaryItem>();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        ResumeList = await Service.GetPublicResumes();
    }
}