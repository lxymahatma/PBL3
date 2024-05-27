using OpenAI_API;

namespace PBL3.Services;

public sealed class OpenAIService : IOpenAIService
{
    [UsedImplicitly]
    public OpenAIAPI OpenAIAPI { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;
}