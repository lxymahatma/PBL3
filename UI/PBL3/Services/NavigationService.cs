namespace PBL3.Services;

public sealed class NavigationService : INavigationService
{
    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public Frame ContentFrame { get; } = new();

    public void NavigateTo<T>()
    {
        var pageType = typeof(T);
        ContentFrame.Navigate(pageType);
        Logger.Information("Navigate to {Page}", pageType.Name);
    }

    public void NavigateTo(Type pageType)
    {
        ContentFrame.Navigate(pageType);
        Logger.Information("Navigate to {Page}", pageType.Name);
    }
}