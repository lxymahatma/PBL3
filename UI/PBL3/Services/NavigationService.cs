namespace PBL3.Services;

public partial class NavigationService : ObservableObject, INavigationService
{
    [ObservableProperty]
    private Frame _contentFrame = new();

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

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