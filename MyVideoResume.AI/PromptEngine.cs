using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ML.OnnxRuntimeGenAI;
using MyVideoResume.Data.Dtos;

namespace MyVideoResume.AI;

public interface IPromptEngine {
    PromptResult Process(string question);
    PromptResult Process(string prompt, string question);
}

public class OpenAIPromptEngine : IPromptEngine
{
    public PromptResult Process(string question)
    {
        throw new NotImplementedException();
    }

    public PromptResult Process(string prompt, string question)
    {
        throw new NotImplementedException();
    }
}

public class PromptEngine : IPromptEngine
{
    private readonly ILogger<PromptEngine> _logger;

    private Model model = null;
    private Tokenizer tokenizer = null;

    private readonly IConfiguration _configuration;

    public PromptEngine(ILogger<PromptEngine> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    public PromptResult Process(string question)
    {
        var systemPrompt = "You are an AI assistant that helps people find information. Answer questions using a direct style. Do not share more information that the requested by the users.";
        return Process(systemPrompt, question);
    }

    public PromptResult Process(string prompt, string question)
    {
        var result = new PromptResult();
        var workingDirectory = string.Empty;

        try
        {
#if DEBUG
            workingDirectory = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(typeof(PromptEngine).Assembly.Location), "..\\..\\..\\..\\MyVideoResume.AI\\models\\", _configuration.GetValue<string>("AI:SLMModelFilePath"))); 
#else
            workingDirectory = _configuration.GetValue<string>("AI:SLMModelFilePath");
#endif
            var modelPath = workingDirectory;
            if (model == null)
            {
                model = new Model(modelPath);
                tokenizer = new Tokenizer(model);
            }

            var fullPrompt = $"<|system|>{prompt}<|end|><|user|>{question}<|end|><|assistant|>";
            var tokens = tokenizer.Encode(fullPrompt);

            var generatorParams = new GeneratorParams(model);
            generatorParams.SetSearchOption("max_length", 2500);
            generatorParams.SetSearchOption("past_present_share_buffer", false);
            generatorParams.SetInputSequences(tokens);

            var generator = new Generator(model, generatorParams);
            while (!generator.IsDone())
            {
                generator.ComputeLogits();
                generator.GenerateNextToken();
                var outputTokens = generator.GetSequence(0);
                var newToken = outputTokens.Slice(outputTokens.Length - 1, 1);
                var output = tokenizer.Decode(newToken);
                result.Result += output;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex.Message} - working dir: {workingDirectory}", ex);
        }

        return result;
    }
}
