namespace EduPath.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private NavigationViewItem _selected = null!;

    public NavigationViewItem[] MenuItems { get; } =
    [
        new NavigationViewItem { Content = "Home", IconSource = new SymbolIconSource { Symbol = Symbol.Home } },
        new NavigationViewItem { Content = "Account", IconSource = new SymbolIconSource { Symbol = Symbol.OtherUser } }
    ];

    public Frame ContentFrame => NavigationService.ContentFrame;

    public void SwitchItem(int index) => Selected = MenuItems[index];

    [RelayCommand]
    private Task OpenLoginPageAsync() => DialogService.ShowAsync(LoginDialogViewModel);

    partial void OnSelectedChanged(NavigationViewItem value)
    {
        switch (value.Content)
        {
            case "Home":
                NavigationService.NavigateToWithoutNotify<HomePage>();
                break;
            case "Account":
                NavigationService.NavigateToWithoutNotify<AccountPage>();
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