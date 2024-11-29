using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyVideoResume.Data.Dtos;
using MyVideoResume.Documents;

namespace MyVideoResume.AI;

[Route("[controller]")]
public class PromptController : Controller
{
    public IPromptEngine Engine { get; set; }

    private readonly DocumentProcessor _documentProcessor;
    public PromptController(IPromptEngine engine, DocumentProcessor processor)
    {
        // Get the ML Model Engine injected, for scoring
        Engine = engine;
        _documentProcessor = processor;
    }

    [HttpPost]
    [Route("summarize")]
    public async Task<ActionResult<PromptResult>> SummarizeResumePost([FromBody] string resumeText)
    {
        var prompt = "You are an AI Assistant that helps people summarize thier resume.";
        var result = await Engine.Process(prompt, resumeText);
        return result;
    }

    [HttpPost]
    [Route("match")]
    public async Task<ActionResult<PromptResult>> JobResumeMatchPost([FromBody] JobMatchRequest request)
    {
        var prompt = "You are an AI Assistant that helps people match thier Resume to a Job Description.";
        var userInput = $"Resume: {request.Resume}";
        var userJobInput = $"Job Description: {request.Job}";
        var result = await Engine.Process(prompt, new[] { userInput, userJobInput });
        return result;
    }

    [HttpPost]
    [Route("parse")]
    public async Task<ActionResult<PromptResult>> ResumeParseJSON(IFormFile file)
    {
        var prompt = @"you are a resume parser assistant. 

I need you to parse the resume into the following JSON format:

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
    ""summary"": ""There is no spoon.""
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

        var result = new PromptResult();
        try
        {
            if (file != null )
            {
                var content = _documentProcessor.PdfToString(file.OpenReadStream());
                var conversion = await Engine.Process(prompt, content);
                result = conversion;
            }
        }
        catch (Exception ex)
        {
            result.Result = ex.Message;
        }
        return result;

    }
}
