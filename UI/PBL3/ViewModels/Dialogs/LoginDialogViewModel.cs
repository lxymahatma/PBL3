namespace PBL3.ViewModels.Dialogs;

public sealed partial class LoginDialogViewModel : ViewModelBase, ILoginDialogViewModel
{
    private bool _isSwitch;

    [ObservableProperty]
    [Required]
    [MinLength(3)]
    private string? _key;

    [ObservableProperty]
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    private string? _password;

    public ContentDialog GetDialogSettings()
    {
        var dialog = new ContentDialog
        {
            Content = this,
            Title = "User Login",
            PrimaryButtonText = "Login",
            SecondaryButtonText = "Register",
            DefaultButton = ContentDialogButton.Primary,
            PrimaryButtonCommand = LoginCommand,
            SecondaryButtonCommand = SwitchToRegisterCommand
        };
        dialog.Closing += (_, args) => args.Cancel = !UserService.IsLoggedIn && !_isSwitch;
        return dialog;
    }

    [RelayCommand]
    private async Task Login()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return;
        }

        UserService.Login(Key!, Password!);
        if (!UserService.IsLoggedIn)
        {
            await MessageBoxService.ErrorAsync("Login failed: Invalid username, email or password");
            return;
        }

        await MessageBoxService.SuccessAsync("Login successful");
    }

    [RelayCommand]
    private async Task SwitchToRegister()
    {
        _isSwitch = true;
        DialogService.HideCurrentDialog();
        await DialogService.ShowAsync(RegisterDialogViewModel);
        _isSwitch = false;
    }

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IRegisterDialogViewModel RegisterDialogViewModel { get; init; } = null!;

    #endregion
}