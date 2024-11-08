﻿using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Layout;

public partial class MainLayout
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    private bool sidebarExpanded = true;

    [Inject]
    protected SecurityService Security { get; set; }

    void SidebarToggleClick()
    {
        sidebarExpanded = !sidebarExpanded;
    }

    protected void ProfileMenuClick(RadzenProfileMenuItem args)
    {
        if (args.Value == "Logout")
        {
            Security.Logout();
        }
    }

    public string Copyright { get { return $"Copyright Ⓒ {DateTime.Now.Year} - MyVideoResu.ME - "; } }
    public string Version { get { return $"v.{VersionNumber}"; } }

    public bool ShowLogin
    {
        get
        {
            return !Security.IsAuthenticated();
        }
    }

    public string VersionNumber
    {
        get
        {
            return typeof(MainLayout).Assembly.GetName().Version.ToString();

        }
    }

    public void NavigateTo(string path)
    {
        NavigationManager.NavigateTo(path);
    }

}
