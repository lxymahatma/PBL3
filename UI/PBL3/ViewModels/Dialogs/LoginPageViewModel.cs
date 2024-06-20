namespace PBL3.ViewModels.Dialogs;

public sealed partial class LoginPageViewModel : ViewModelBase, ILoginPageViewModel
{
    [ObservableProperty]
    [Required]
    [MinLength(3)]
    private string? _key;

    [ObservableProperty]
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    private string? _password;

    public ContentDialog Settings => new()
    {
        Content = this,
        Title = "User Login",
        PrimaryButtonText = "Login",
        SecondaryButtonText = "Register",
        DefaultButton = ContentDialogButton.Primary,
        PrimaryButtonCommand = LoginCommand,
        SecondaryButtonCommand = SwitchToRegisterCommand
    };

    [RelayCommand]
    private async Task Login()
    {
        while (!await TryLogin())
        {
            await Settings.ShowAsync();
        }
    }

    private async Task<bool> TryLogin()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return false;
        }

        var result = UserService.Login(Key!, Password!);
        if (!result)
        {
            await MessageBoxService.ErrorAsync("Login failed: Invalid username, email or password");
            return false;
        }

        await MessageBoxService.SuccessAsync("Login successful");
        return true;
    }

    [RelayCommand]
    private async Task SwitchToRegister() => await RegisterPageViewModel.Settings.ShowAsync();

    #region Services

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IRegisterPageViewModel RegisterPageViewModel { get; init; } = null!;

    #endregion
}