using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace MyVideoResume.Client.Shared;

public class BaseComponent : LayoutComponentBase
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected IJSRuntime JSRuntime { get; set; }


    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    [Inject]
    protected SecurityService Security { get; set; }

    public void NavigateTo(string path)
    {
        NavigationManager.NavigateTo(path);
    }

}
