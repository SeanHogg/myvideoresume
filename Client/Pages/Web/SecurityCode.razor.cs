using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.Web;

public partial class SecurityCode
{
    async Task VerifySecurityCode(string code)
    {
        if (code.Count() == 6)
        {
            await JSRuntime.InvokeVoidAsync("eval", "document.forms[0].submit()");
        }
    }

    string message;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var uri = new Uri(NavigationManager.ToAbsoluteUri(NavigationManager.Uri).ToString());
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        message = $"We sent a verification code to {query.Get("email")}. Enter the code from the email below.";
    }

    RadzenSecurityCode sc;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await sc.FocusAsync();
        }
    }
}
