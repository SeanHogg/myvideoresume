using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyVideoResume.Data.Dtos;
using MyVideoResume.Data.Models;
using OpenAI.Chat;

namespace MyVideoResume.AI;

public class OpenAIPromptEngine : IPromptEngine
{
    private readonly ILogger<OpenAIPromptEngine> _logger;
    private readonly IConfiguration _configuration;
    private ChatClient? client = null;

    public OpenAIPromptEngine(ILogger<OpenAIPromptEngine> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<PromptResult> Process(string question)
    {
        var systemPrompt = "You are an AI assistant that helps people summarize work history and resume experience.";
        return await Process(systemPrompt, question);
    }

    public async Task<PromptResult> Process(string prompt, string question)
    {
        if (client == null)
        {
            var key = _configuration.GetValue<string>("AI:OpenAIKey");
            client = new(model: "gpt-4o-mini", apiKey: key);
        }

        var c = ChatMessage.CreateSystemMessage(prompt);

        List<ChatMessage> chatHistory = new()
    {
        c, ChatMessage.CreateUserMessage(question)
    };
        var chatResult = await client.CompleteChatAsync(chatHistory);
        var result = new PromptResult() { Result = chatResult.Value.Content[0].Text };
        return result;
    }
}
