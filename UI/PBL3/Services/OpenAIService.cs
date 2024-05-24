using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using OpenAI_API;
using PBL3.Contracts;

namespace PBL3.Services;

public sealed class OpenAIService : IOpenAIService
{
    [UsedImplicitly]
    public OpenAIAPI? OpenAIAPI { get; init; }
    
    [UsedImplicitly]
    public ILogger? Logger { get; init; }
}