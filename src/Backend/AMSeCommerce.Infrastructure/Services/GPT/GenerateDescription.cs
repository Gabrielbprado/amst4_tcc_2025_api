using System.Text;
using System.Text.RegularExpressions;
using AMSeCommerce.Communication.Request.GPT;
using AMSeCommerce.Communication.Response.GPT;
using AMSeCommerce.Domain.Services.GPT;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using OllamaSharp;
using ChatMessage = Azure.AI.OpenAI.ChatMessage;
using ChatRole = Azure.AI.OpenAI.ChatRole;

namespace AMSeCommerce.Infrastructure.Services.GPT;

public class GenerateDescriptionAi(OpenAIClient openAiClient,HttpClient client) : IGenerateDescriptionAi
{
    private readonly OpenAIClient _openAiApi = openAiClient;
    private readonly HttpClient _client = client;
    private const string CHAT_MODEL = "gpt-35-turbo";
    public async Task<ResponseGenerateDescription> GenerateDescription(RequestGenerateDescription request)
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
        options.Messages.Add(new ChatMessage(ChatRole.User, request.Title));

        var response = await _openAiApi.GetChatCompletionsAsync(deploymentOrModelName: CHAT_MODEL, options);

        var completions = response.Value;
        var fullResponse = completions.Choices[0].Message.Content;
        
        return new ResponseGenerateDescription()
            {
            Description = fullResponse
        };
    }
    
    public async Task<ResponseGenerateDescription> GenerateDescriptionLocal(RequestGenerateDescription request)
    {
        var uri = new Uri("http://localhost:11434");
        var ollama = new OllamaApiClient(uri);
        ollama.SelectedModel = "llama3.1:8b";
    
        var chat = new Chat(ollama);
        string fullmessage = string.Empty;

        await foreach (var message in chat.SendAsync($"{ResourceOpenAi.DEFAULT_MESSAGE} Titulo Fornecido - {request.Title}"))
        {
            fullmessage += RemoveThinkTag(message);
        }

        return new ResponseGenerateDescription()
        {
            Description = fullmessage
        };
    }

    private string RemoveThinkTag(string input)
    {
        return Regex.Replace(input, @"<think>.*?</think>", string.Empty, RegexOptions.Singleline);
    }
    
    
}