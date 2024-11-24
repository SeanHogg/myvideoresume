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

public partial class RegisterApplicationUser
{
    protected Data.Models.ApplicationUser user;
    protected bool isBusy;
    protected bool errorVisible;
    protected string error;

    protected override async Task OnInitializedAsync()
    {
        user = new Data.Models.ApplicationUser();
    }

    protected async Task FormSubmit()
    {
        try
        {
            isBusy = true;

            await Security.Register(user.Email, user.Password);

            DialogService.Close(true);
        }
        catch (Exception ex)
        {
            errorVisible = true;
            error = ex.Message;
        }

        isBusy = false;
    }

    protected async Task CancelClick()
    {
        DialogService.Close(false);
    }
}