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
using MyVideoResume.Web.Common;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.App.People.Resumes.Builder;

public partial class BuilderPageV2
{
    [Parameter] public String ResumeId { get; set; }

    [Inject] ILogger<BuilderPageV2> Logger { get; set; }

    public ResumeInformationEntity Resume { get; set; } = new ResumeInformationEntity()
    {
        MetaData = new List<MetaDataEntity>(),
        MetaResume = new MetaResumeEntity() { Basics = new() { Location = new() }, Awards = new(), Certificates = new(), Education = new List<Education>(), Interests = new(), Languages = new List<LanguageItem>(), Projects = new List<Project>(), Publications = new List<Publication>(), References = new List<ReferenceItem>(), Skills = new List<Skill>(), Volunteer = new List<Volunteer>(), Work = new List<Work>() }
    };

    public Type ComponentType { get; set; }

    public Dictionary<string, object> ComponentParameters { get; set; }

    public int PercentageComplete { get; set; }

    public string Privacy_ShowContactDetails { get; set; } = DisplayPrivacy.ToPublic.ToString();
    public string Privacy_ShowResume { get; set; } = DisplayPrivacy.ToPublic.ToString();

    public SortedList<string, string> Privacy { get; set; } = DisplayPrivacy.ToPublic.ToSortedList();

    protected int CalculatePercentComplete()
    {
        var result = 0;
        if (Resume != null)
        {
            //Resume Name
            if (!string.IsNullOrEmpty(Resume.Name))
                result += 10;
            //Email
            //if()
            //Privacy Settings
            if (!string.IsNullOrEmpty(Privacy_ShowResume))
                result += 10;
            if (!string.IsNullOrEmpty(Privacy_ShowContactDetails))
                result += 10;

            //Basic Info
            //SLUG
            //Summary
            if (Resume.MetaResume != null)
            {
                //Education
                //Work
                if (Resume.MetaResume.Work != null && Resume.MetaResume.Work.Count > 0)
                    result += 10;
            }
            PercentageComplete = result;
            StateHasChanged();
        }
        return result;
    }

    protected async Task ChangePrivacy()
    {
        //Update the Privacy
        if (!string.IsNullOrEmpty(Privacy_ShowResume))
            Resume.Privacy_ShowResume = Enum.Parse<DisplayPrivacy>(Privacy_ShowResume);
        if (!string.IsNullOrEmpty(Privacy_ShowContactDetails))
            Resume.Privacy_ShowContactDetails = Enum.Parse<DisplayPrivacy>(Privacy_ShowContactDetails);
    }

    protected async Task WorkItemCreated(Work workItem)
    {
        Logger.LogInformation(workItem.Id);
    }

    protected async Task WorkItemDeleted(Work workItem)
    {
        Logger.LogInformation(workItem.Id);
    }

    protected async Task Save()
    {
        var result = await Service.Save(Resume);
        if (result.ErrorMessage.HasValue())
            ShowSuccessNotification("Resume Saved", string.Empty);
        else
            ShowErrorNotification("Resume Failed", result.ErrorMessage);
    }

    List<Work> GetWorkItems()
    {

        Resume.MetaResume.Work = Resume.MetaResume.Work.OrderByDescending(x => x.EndDate).ToList();

        return Resume.MetaResume.Work;
    }

    async Task CreateItem()
    {
        var workItem = new Work()
        {
            Id = Guid.NewGuid().ToString(),
        };

        Resume.MetaResume.Work.Insert(0, workItem);

        StateHasChanged();
        await JSRuntime.InvokeVoidAsync("scrollToWork");
    }

    async Task CreateWorkHighlightItem(Work item)
    {
        if (item.Highlights == null) { item.Highlights = new List<string>(); }
        item.Highlights.Add(string.Empty);
    }

    async Task DeleteWorkHighlightItem(Work item, string value)
    {
        item.Highlights.Remove(value);
    }


    async Task Delete(Work workItem)
    {
        Resume.MetaResume.Work.Remove(workItem);
    }

    async Task Save(Work workItem)
    {
        var item = Resume.MetaResume.Work.FirstOrDefault(x => x.Id == workItem.Id);
        item = workItem;
    }

    async Task SaveWorkHighlightItem(string originalItem, Work item)
    {
        //args.
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (MenuService.SidebarExpanded)
        {
            MenuService.SidebarToggleClick();
        }

        try
        {
            if (ResumeId.ToLower() != "new")
            {
                var temp = await Service.GetResume(ResumeId);
                if (temp != null && Security.User.Id == temp.UserId)
                {
                    Resume = temp;
                    Privacy_ShowResume = Resume.Privacy_ShowResume.ToString();
                    Privacy_ShowContactDetails = Resume.Privacy_ShowContactDetails.ToString();
                }
                else
                    Resume = null;

                if (Resume != null)
                {
                    if (Resume.ResumeTemplate != null)
                    {
                        ComponentType = ResolveComponent(Resume.ResumeTemplate.TransformerComponentName, Resume.ResumeTemplate.Namespace);
                        ComponentParameters = new Dictionary<string, object>() { { "resume", Resume }, { "mode", StandardTemplate.DisplayMode.Edit } };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
        }

        CalculatePercentComplete();

    }

}