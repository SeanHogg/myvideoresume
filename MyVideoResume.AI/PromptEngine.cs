using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ML.OnnxRuntimeGenAI;

namespace MyVideoResume.AI;

public interface IPromptEngine
{
    Task<PromptResult> Process(string question);
    Task<PromptResult> Process(string prompt, string[] question);
    Task<PromptResult> Process(string prompt, string question);

}

public class PromptEngine : IPromptEngine
{
    protected readonly ILogger<PromptEngine> _logger;
    protected readonly IConfiguration _configuration;

    private Model model = null;
    private Tokenizer tokenizer = null;

    public PromptEngine(ILogger<PromptEngine> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    public async Task<PromptResult> Process(string question)
    {
        var systemPrompt = "You are an AI assistant that helps people find information. Answer questions using a direct style. Do not share more information that the requested by the users.";
        return await Process(systemPrompt, question);
    }

    public async Task<PromptResult> Process(string prompt, string question)
    {
        return await Process(prompt, new[] { question });
    }

    public async Task<PromptResult> Process(string prompt, string[] questions)
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

            var userQuestions = string.Empty;
            foreach (var question in questions)
            {
                userQuestions += $"<|user|>{question}<|end|>";
            }

            var fullPrompt = $"<|system|>{prompt}<|end|>{userQuestions}<|assistant|>";
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
