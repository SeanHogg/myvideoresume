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

public partial class ResumeEmbedded
{

    [Parameter]
    public String Slug { get; set; }

    [Inject] ILogger<ResumeViewer> Logger { get; set; }

    public MetaResumeEntity Resume { get; set; } = new MetaResumeEntity();

    public bool IsResumeDeleted { get; set; }

    public string ResumePageTitle { get; set; }
    public Type ComponentType { get; set; }
    public Dictionary<string, object> ComponentParameters { get; set; }

    [Inject] protected ResumeWebService Service { get; set; }



    protected override async Task OnInitializedAsync()
    {
        try
        {
            Resume = await Service.GetResume(Slug);
            IsResumeDeleted = Resume.DeletedDateTime.HasValue;
            if (IsResumeDeleted)
            {
                ResumePageTitle = $"MyVideoResu.ME - Resume - Not Available";
            }
            else
            {
                if (Resume.ResumeInformation != null)
                {
                    ResumePageTitle = $"MyVideoResu.ME - Resume - {Resume.ResumeInformation?.Name}";
                    if (Resume.ResumeTemplate != null)
                    {
                        ComponentType = ResolveComponent(Resume.ResumeTemplate.TransformerComponentName, Resume.ResumeTemplate.Namespace);
                        ComponentParameters = new Dictionary<string, object>() { { "resume", Resume } };
                    }
                    StateHasChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
        }

        await base.OnInitializedAsync();
    }
}