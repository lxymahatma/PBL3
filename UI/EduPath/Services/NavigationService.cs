namespace EduPath.Services;

public sealed class NavigationService : ObservableObject, INavigationService
{
    private readonly Dictionary<Type, int> _pageIndexes = new()
    {
        { typeof(HomePage), 0 },
        { typeof(AccountPage), 1 }
    };

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMainWindowViewModel MainWindowViewModel { get; init; } = null!;

    public Frame ContentFrame { get; } = new();

    public void NavigateTo<T>()
    {
        var pageType = typeof(T);
        MainWindowViewModel.SwitchItem(_pageIndexes[pageType]);
    }

    public void NavigateToNull() => ContentFrame.Content = null;

    public void NavigateToWithoutNotify<T>()
    {
        var pageType = typeof(T);
        ContentFrame.Navigate(pageType);
        Logger.Information("Navigate to {Page}", pageType.Name);
    }
}