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
using MyVideoResume.Abstractions.Job;

namespace MyVideoResume.Client.Services;

public partial class ResumeWebService
{
    private readonly DataContext _dataContext;
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly SecurityWebService _securityService;
    private readonly ILogger<DashboardWebService> _logger;

    public ResumeWebService(NavigationManager navigationManager, IHttpClientFactory factory, ILogger<DashboardWebService> logger, DataContext dataContext, SecurityWebService securityService)
    {
        this._httpClient = factory.CreateClient("MyVideoResume.Server");
        this._navigationManager = navigationManager;
        this._logger = logger;
        this._dataContext = dataContext;
        this._securityService = securityService;
    }

    public async Task<List<MetaResumeEntity>> GetResumes()
    {
        var result = new List<MetaResumeEntity> { };
        try
        {
            var user = _securityService.User.Id;
            var uri = new Uri($"{_navigationManager.BaseUri}api/resume");
            var response = await _httpClient.GetAsync(uri);
            result = await response.ReadAsync<List<MetaResumeEntity>>();
            result = result.OrderByDescending(x => x.CreationDate).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }

        return result;
    }

    public async Task<MetaResumeEntity> GetResume(string resumeId)
    {
        var result = new MetaResumeEntity();
        try
        {
            var uri = new Uri($"{_navigationManager.BaseUri}api/resume/{resumeId}");
            var response = await _httpClient.GetAsync(uri);
            result = await response.ReadAsync<MetaResumeEntity>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }

        return result;
    }

    public async Task<ResponseResult> Delete(MetaResumeEntity metaResumeEntity)
    {
        var result = new ResponseResult();
        try
        {
            var uri = new Uri($"{_navigationManager.BaseUri}api/resume/delete");
            var payload = metaResumeEntity.Id.ToString();
            var user = _securityService.User.Id;
            var content = new FormUrlEncodedContent(new Dictionary<string, string> {
            { "resumeId", payload }
        });

            var response = await _httpClient.PostAsync(uri, content);
            result = await response.ReadAsync<ResponseResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        return result;
    }

    public async Task<ResponseResult> Match(string jobDescription, string resume)
    {
        var uri = new Uri($"{_navigationManager.BaseUri}api/resume/match");
        _httpClient.Timeout = TimeSpan.FromMinutes(10);
        var request = new JobMatchRequest() { Job = jobDescription, Resume = resume };
        var response = await _httpClient.PostAsJsonAsync<JobMatchRequest>(uri, request);
        var r = await response.ReadAsync<ResponseResult>();
        return r;
    }
    public async Task<ResponseResult> Summarize(string resume)
    {
        var uri = new Uri($"{_navigationManager.BaseUri}api/resume/summarize");
        var response = await _httpClient.PostAsJsonAsync<string>(uri, resume);
        var r = await response.ReadAsync<ResponseResult>();
        return r;
    }
}