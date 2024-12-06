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

public partial class DashboardWebService
{
    private readonly ResumeWebService _resumeService;

    private readonly ILogger<DashboardWebService> _logger;

    public DashboardWebService(NavigationManager navigationManager, IHttpClientFactory factory, ILogger<DashboardWebService> logger, DataContext dataContext, SecurityWebService securityService, ResumeWebService resumeService)
    {
        _logger = logger;
        _resumeService = resumeService;
    }
    public async Task<List<MetaResumeEntity>> GetResumes()
    {
        var result = await _resumeService.GetResumes();
        return result;
    }

    public async Task<ResponseResult> Delete(MetaResumeEntity metaResumeEntity)
    {
        var result = await _resumeService.Delete(metaResumeEntity);
        return result;
    }
}