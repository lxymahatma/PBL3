namespace PBL3.ViewModels.Pages;

public sealed partial class LoginPageViewModel : ViewModelBase, ILoginPageViewModel
{
    [ObservableProperty]
    [Required]
    private string? _key;

    [ObservableProperty]
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    private string? _password;

    [RelayCommand]
    private void Login()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return;
        }

        var result = UserService.Login(Key!, Password!);
        if (!result)
        {
            MessageBoxService.Error("Login failed: Invalid username, email or password");
            Key = null;
            Password = null;
        }

        MessageBoxService.Success("Login successful");
        DialogService.Close(PopupWindowViewModel);
    }

    [RelayCommand]
    private void SwitchToRegisterPage() => PopupWindowViewModel.SwitchTab(1);

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public IPopupWindowViewModel PopupWindowViewModel { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    #endregion
}