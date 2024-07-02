namespace EduPath.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private NavigationViewItem _selected = null!;

    public Frame ContentFrame => NavigationService.ContentFrame;

    [RelayCommand]
    private Task OpenLoginPageAsync() => DialogService.ShowAsync(LoginDialogViewModel, () => UserService.IsLoggedIn);

    partial void OnSelectedChanged(NavigationViewItem value)
    {
        switch (value.Content)
        {
            case "Home":
                NavigationService.NavigateTo<HomePage>();
                break;
            case "Account":
                NavigationService.NavigateTo<AccountPage>();
                break;
        }
    }

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILoginDialogViewModel LoginDialogViewModel { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public INavigationService NavigationService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    #endregion
}