namespace PBL3.ViewModels.Windows;

public sealed partial class PopupWindowViewModel : ViewModelBase, IPopupWindowViewModel
{
    private readonly Tab[] _tabs;

    [ObservableProperty]
    private ViewModelBase _content;

    [ObservableProperty]
    private string _title = "Login Page";

    public PopupWindowViewModel()
    {
        _tabs =
        [
            (new LoginPageViewModel(), "Login Page"),
            (new RegisterPageViewModel(), "Register Page")
        ];
        Content = _tabs[0].Content;
    }

    public bool? DialogResult => null;

    public void SwitchTab(int index)
    {
        Content = _tabs[index].Content;
        Title = _tabs[index].Title;
        Logger.Information("Switched to {Title}", Title);
    }

    [RelayCommand]
    private void OnClose(WindowClosingEventArgs e)
    {
        if (UserService.IsLoggedIn)
        {
            e.Cancel = false;
            return;
        }

        Logger.Warning("User tried to close the window without logging in");
        MessageBoxService.Error("You must login to continue");
        e.Cancel = true;
    }

    [RelayCommand]
    private static void Exit() => Environment.Exit(0);

    #region Services

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    #endregion
}