using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using Radzen;
using Radzen.Blazor;
using System.ComponentModel;
using System.Net.Http.Json;

namespace MyVideoResume.Client.Pages.Web;

public partial class SearchResults
{
    [SupplyParameterFromQuery(Name = "Query")]
    private string? Query { get; set; }

    [SupplyParameterFromQuery(Name = "Filter")]
    private string? Filter { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync("BlazorSetTitle", Query, Filter);
    }

}