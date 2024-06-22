namespace PBL3.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private Frame _contentFrame = new();

    [ObservableProperty]
    private NavigationViewItem _selected = null!;

    [RelayCommand]
    private async Task OpenLoginPage()
    {
        ContentFrame.Navigate(typeof(HomePage));
        await DialogService.ShowAsync(LoginDialogViewModel, () => UserService.IsLoggedIn).ConfigureAwait(false);
    }

    partial void OnSelectedChanged(NavigationViewItem value)
    {
        switch (value.Content)
        {
            case "Home":
                ContentFrame.Navigate(typeof(HomePage));
                break;
            case "Account":
                ContentFrame.Navigate(typeof(AccountPage));
                break;
        }
    }

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public ILoginDialogViewModel LoginDialogViewModel { get; init; } = null!;

    #endregion
}