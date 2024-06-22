using Avalonia.Media;
using FluentAvalonia.UI.Windowing;

namespace PBL3.Models;

public sealed class SplashScreen : IApplicationSplashScreen
{
    public Task RunTasks(CancellationToken cancellationToken) => Task.CompletedTask;

    public string? AppName { get; init; }
    public IImage? AppIcon { get; init; }
    public object? SplashScreenContent { get; init; }
    public int MinimumShowTime { get; init; }
}