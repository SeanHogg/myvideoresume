using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace MyVideoResume.Client.Pages.Admin;

public partial class ApplicationUsers
{
    protected IEnumerable<MyVideoResume.Data.Models.ApplicationUser> users;
    protected RadzenDataGrid<MyVideoResume.Data.Models.ApplicationUser> grid0;
    protected string error;
    protected bool errorVisible;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        users = await Security.GetUsers();
    }

    protected async Task AddClick()
    {
        await DialogService.OpenAsync<AddApplicationUser>("Add Application User");

        users = await Security.GetUsers();
    }

    protected async Task RowSelect(MyVideoResume.Data.Models.ApplicationUser user)
    {
        await DialogService.OpenAsync<EditApplicationUser>("Edit Application User", new Dictionary<string, object> { { "Id", user.Id } });

        users = await Security.GetUsers();
    }

    protected async Task DeleteClick(MyVideoResume.Data.Models.ApplicationUser user)
    {
        try
        {
            if (await DialogService.Confirm("Are you sure you want to delete this user?") == true)
            {
                await Security.DeleteUser($"{user.Id}");

                users = await Security.GetUsers();
            }
        }
        catch (Exception ex)
        {
            errorVisible = true;
            error = ex.Message;
        }
    }
}