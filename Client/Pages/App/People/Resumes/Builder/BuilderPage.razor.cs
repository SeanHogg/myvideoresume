using System.ComponentModel;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using MyVideoResume.Abstractions.Resume;
using MyVideoResume.Abstractions.Resume.Formats.JSONResumeFormat;
using MyVideoResume.Client.Pages.App.People.Resumes.Templates;
using MyVideoResume.Client.Services;
using MyVideoResume.Client.Shared;
using MyVideoResume.Data.Models.Resume;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.App.People.Resumes.Builder;



public partial class BuilderPage
{
    [Parameter] public String ResumeId { get; set; }

    [Inject] ILogger<BuilderPage> Logger { get; set; }

    [Inject] protected ResumeWebService Service { get; set; }

    public ResumeInformationEntity Resume { get; set; } = new ResumeInformationEntity()
    {
        MetaData = new List<MetaDataEntity>(),
        MetaResume = new MetaResumeEntity() { Basics = new() { Location = new() }, Awards = new(), Certificates = new(), Education = new List<Education>(), Interests = new(), Languages = new List<LanguageItem>(), Projects = new List<Project>(), Publications = new List<Publication>(), References = new List<ReferenceItem>(), Skills = new List<Skill>(), Volunteer = new List<Volunteer>(), Work = new List<Work>() }
    };

    public Type ComponentType { get; set; }

    public Dictionary<string, object> ComponentParameters { get; set; }

    public int PercentageComplete { get; set; }

    public string SelectedValue { get; set; } = DisplayPrivacy.ToPublic.ToString();

    public SortedList<string, string> Privacy { get; set; }

    protected int CalculatePercentComplete()
    {
        var result = 0;

        //Resume Name
        if (!string.IsNullOrEmpty(Resume.Name))
            result += 10;
        //Email
        //if()
        //Privacy Settings
        if (!string.IsNullOrEmpty(SelectedValue))
            result += 10;

        //Basic Info
        //SLUG
        //Summary
        //Education
        //Work

        PercentageComplete = result;
        StateHasChanged();

        return result;
    }
    protected async Task Submit(ResumeInformationEntity arg) => await Service.Save(arg);

    protected override async Task OnInitializedAsync()
    {
        Privacy = DisplayPrivacy.ToPublic.ToSortedList();

        if (MenuService.SidebarExpanded)
        {
            MenuService.SidebarToggleClick();
        }

        try
        {

            if (ResumeId.ToLower() != "new")
            {
                var temp = await Service.GetResume(ResumeId);
                if (Security.User.Id == temp.UserId)
                    Resume = temp;
                else
                    Resume = null;

                if (Resume != null)
                {
                    if (Resume.ResumeTemplate != null)
                    {
                        ComponentType = ResolveComponent(Resume.ResumeTemplate.TransformerComponentName, Resume.ResumeTemplate.Namespace);
                        ComponentParameters = new Dictionary<string, object>() { { "resume", Resume }, { "mode", StandardTemplate.DisplayMode.Edit } };
                    }
                    StateHasChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
        }

        CalculatePercentComplete();

        await base.OnInitializedAsync();
    }

}