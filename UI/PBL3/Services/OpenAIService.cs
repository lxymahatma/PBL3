using OpenAI;

namespace PBL3.Services;

public sealed class OpenAIService : IOpenAIService
{
    [UsedImplicitly]
    public OpenAIClient OpenAIClient { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;
}