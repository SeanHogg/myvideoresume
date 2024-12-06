using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using MyVideoResume.Client.Services;
using MyVideoResume.Data.Models.Resume;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.App.People.Resumes;

public partial class ResumeViewer
{

    [Parameter]
    public String Slug { get; set; }

    [Inject] ILogger<ResumeViewer> Logger { get; set; }

    public MetaResumeEntity Resume { get; set; } = new MetaResumeEntity();

    [Inject] protected ResumeWebService Service { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Resume = await Service.GetResume(Slug);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
        }

        await base.OnInitializedAsync();
    }
}