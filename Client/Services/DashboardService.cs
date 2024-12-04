using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using MyVideoResume.Data.Models;
using MyVideoResume.Client.Shared.Security.Recaptcha;
using MyVideoResume.Data;
using Microsoft.EntityFrameworkCore;
using MyVideoResume.Data.Models.Resume;
using MyVideoResume.Abstractions.Core;
using static System.Net.WebRequestMethods;

namespace MyVideoResume.Client.Services;

public partial class DashboardService
{
    private readonly DataContext _dataContext;
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly SecurityService _securityService;
    private readonly ILogger<DashboardService> _logger;

    public DashboardService(NavigationManager navigationManager, IHttpClientFactory factory, ILogger<DashboardService> logger, DataContext dataContext, SecurityService securityService)
    {
        this._httpClient = factory.CreateClient("MyVideoResume.Server");
        this._navigationManager = navigationManager;
        this._logger = logger;
        this._dataContext = dataContext;
        this._securityService = securityService;
    }
    public async Task<List<MetaResumeEntity>> GetResumes()
    {
        var userId = _securityService.User.Id;
        var result = await _dataContext.Resumes.Where(x => x.UserId == userId).ToListAsync();

        return result;
    }

    public async Task<ResponseResult> Delete(MetaResumeEntity metaResumeEntity) {

        var uri = new Uri($"{_navigationManager.BaseUri}resume/delete");
        var payload = metaResumeEntity.Id.ToString();
        var user = _securityService.User.Id;
        var content = new FormUrlEncodedContent(new Dictionary<string, string> {
            { "resumeId", payload }
        });

        var response = await _httpClient.PostAsync(uri, content);
        var result = await response.ReadAsync<ResponseResult>();

        return result;
    }
}