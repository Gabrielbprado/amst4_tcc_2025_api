using AMSeCommerce.Domain.Services.GPT;
using Azure.AI.OpenAI;

namespace AMSeCommerce.Infrastructure.Services.GPT;

public class GenerateDescriptionAi(OpenAIClient openAiClient) : IGenerateDescriptionAi
{
    private readonly OpenAIClient _openAiApi = openAiClient;
    private const string CHAT_MODEL = "gpt-35-turbo";
    public async Task<string> GenerateDescription(string request)
    {
        ChatCompletionsOptions options = new ChatCompletionsOptions()
        {
            Messages = { new ChatMessage(ChatRole.System, ResourceOpenAi.DEFAULT_MESSAGE) },
            Temperature = (float)0.7,
            MaxTokens = 800,
            NucleusSamplingFactor = (float)0.95,
            FrequencyPenalty = 0,
            PresencePenalty = 0,
        };
        options.Messages.Add(new ChatMessage(ChatRole.User, request));

        var response = await _openAiApi.GetChatCompletionsAsync(deploymentOrModelName: CHAT_MODEL, options);

        var completions = response.Value;
        var fullResponse = completions.Choices[0].Message.Content;
        
        return fullResponse;
    }
}