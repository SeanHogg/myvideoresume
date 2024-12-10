using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyVideoResume.Client.Services;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;

namespace MyVideoResume.Client.Shared;

public class BaseComponent : LayoutComponentBase
{
    [Inject] protected MenuService MenuService { get; set; }

    [Inject] protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject] protected HttpClient Http { get; set; }


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
    protected SecurityWebService Security { get; set; }

    public void NavigateTo(string path)
    {
        NavigationManager.NavigateTo(path);
    }
    public void NavigateTo(string path, string parameter)
    {
        NavigationManager.NavigateTo($"{path}/{parameter}");
    }

    protected Type? ResolveComponent(string componentName, string namespacevalue)
    {
        return string.IsNullOrEmpty(componentName) ? null
            : Type.GetType($"{namespacevalue}.{componentName}");
    }


}
