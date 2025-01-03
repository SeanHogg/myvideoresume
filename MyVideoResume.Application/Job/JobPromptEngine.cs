using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyVideoResume.Abstractions.Core;
using MyVideoResume.Abstractions.Job;
using MyVideoResume.AI;
using MyVideoResume.Documents;
using System.Text.Json;

namespace MyVideoResume.Application.Job;

public interface IJobPromptEngine : IPromptEngine
{
    Task<ResponseResult<JobSummaryItem>> ExtractJobDescription(string url);
    Task<ResponseResult<string>> JobParseJSON(IFormFile file);
}

public class JobPromptEngine : OpenAIPromptEngine, IJobPromptEngine
{
    private readonly DocumentProcessor _documentProcessor;
    private readonly string jsonFormat = @"
{
  ""basics"": {
    ""name"": ""John Doe"",
    ""label"": ""Programmer"",
    ""image"": """",
    ""email"": ""john@gmail.com"",
    ""phone"": ""(912) 555-4321"",
    ""url"": ""https://johndoe.com"",
    ""summary"": ""A summary of John Doe…"",
    ""location"": {
      ""address"": ""2712 Broadway St"",
      ""postalCode"": ""CA 94115"",
      ""city"": ""San Francisco"",
      ""countryCode"": ""US"",
      ""region"": ""California""
    },
    ""profiles"": [{
      ""network"": ""Twitter"",
      ""username"": ""john"",
      ""url"": ""https://twitter.com/john""
    }]
  },
  ""work"": [{
    ""name"": ""Company"",
    ""position"": ""President"",
    ""url"": ""https://company.com"",
    ""startDate"": ""2013-01-01"",
    ""endDate"": ""2014-01-01"",
    ""summary"": ""Description…"",
    ""highlights"": [
      ""Started the company""
    ]
  }],
  ""volunteer"": [{
    ""organization"": ""Organization"",
    ""position"": ""Volunteer"",
    ""url"": ""https://organization.com/"",
    ""startDate"": ""2012-01-01"",
    ""endDate"": ""2013-01-01"",
    ""summary"": ""Description…"",
    ""highlights"": [
      ""Awarded 'Volunteer of the Month'""
    ]
  }],
  ""education"": [{
    ""institution"": ""University"",
    ""url"": ""https://institution.com/"",
    ""area"": ""Software Development"",
    ""studyType"": ""Bachelor"",
    ""startDate"": ""2011-01-01"",
    ""endDate"": ""2013-01-01"",
    ""score"": ""4.0"",
    ""courses"": [
      ""DB1101 - Basic SQL""
    ]
  }],
  ""awards"": [{
    ""title"": ""Award"",
    ""date"": ""2014-11-01"",
    ""awarder"": ""Company"",
    ""summary"": ""Description…""
  }],
  ""certificates"": [{
    ""name"": ""Certificate"",
    ""date"": ""2021-11-07"",
    ""issuer"": ""Company"",
    ""url"": ""https://certificate.com""
  }],
  ""publications"": [{
    ""name"": ""Publication"",
    ""publisher"": ""Company"",
    ""releaseDate"": ""2014-10-01"",
    ""url"": ""https://publication.com"",
    ""summary"": ""Description…""
  }],
  ""skills"": [{
    ""name"": ""Web Development"",
    ""level"": ""Master"",
    ""keywords"": [
      ""HTML"",
      ""CSS"",
      ""JavaScript""
    ]
  }],
  ""languages"": [{
    ""language"": ""English"",
    ""fluency"": ""Native speaker""
  }],
  ""interests"": [{
    ""name"": ""Wildlife"",
    ""keywords"": [
      ""Ferrets"",
      ""Unicorns""
    ]
  }],
  ""references"": [{
    ""name"": ""Jane Doe"",
    ""reference"": ""Reference…""
  }],
  ""projects"": [{
    ""name"": ""Project"",
    ""startDate"": ""2019-01-01"",
    ""endDate"": ""2021-01-01"",
    ""description"": ""Description..."",
    ""highlights"": [
      ""Won award at AIHacks 2016""
    ],
    ""url"": ""https://project.com/""
  }]
}";

    public JobPromptEngine(ILogger<JobPromptEngine> logger, IConfiguration configuration, DocumentProcessor processor) : base(logger, configuration)
    {
        _documentProcessor = processor;
    }

    public async Task<ResponseResult<string>> JobParseJSON(IFormFile file)
    {

        var prompt = @"Given a job description extract it into JSON format. Do not summarize the content of the job description. Respond with no formatting.";

        var result = new ResponseResult<string>();
        try
        {
            if (file != null)
            {
                var content = _documentProcessor.PdfToString(file.OpenReadStream());
                var userInput = $"JSON: {jsonFormat}";
                var userJobInput = $"Job Description: {content}";
                var conversion = await this.Process(prompt, new[] { userInput, userJobInput });
                result = new ResponseResult<string>() { Result = conversion.Result };
            }
        }
        catch (Exception ex)
        {
            result.ErrorMessage = ex.Message;
        }
        return result;

    }

    public async Task<ResponseResult<JobSummaryItem>> ExtractJobDescription(string url)
    {
        var prompt = @"Navigate to the URL and extract the job description into JSON format. Do not summarize the content of the job description. Respond with no formatting.";

        var result = new ResponseResult<JobSummaryItem>();
        try
        {
            var userInput = $"JSON: {jsonFormat}";
            var userJobInput = $"Url: {url}";
            var conversion = await this.Process(prompt, new[] { userInput, userJobInput });
            var temp = JsonSerializer.Deserialize<JobSummaryItem>(conversion.Result);
            result = new ResponseResult<JobSummaryItem>() { Result = temp };
        }
        catch (Exception ex)
        {
            result.ErrorMessage = ex.Message;
        }
        return result;

    }
}
