namespace EduPath.Services;

public sealed class OpenAIService : IOpenAIService
{
    [UsedImplicitly]
    public OpenAIClient OpenAIClient { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public async Task RecommendCourseByRequest(string request)
    {
        var client = OpenAIClient.GetChatClient("gpt-3.5-turbo");
        var response = await client.CompleteChatAsync(request);
        Logger.Information(response.Value.ToString());
    }
}