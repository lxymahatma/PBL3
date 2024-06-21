namespace PBL3.ViewModels.Dialogs;

public sealed partial class LoginDialogViewModel : ViewModelBase, ILoginDialogViewModel
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

    public ContentDialog DialogSettings => new()
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
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return;
        }

        var result = UserService.Login(Key!, Password!);
        if (!result)
        {
            await MessageBoxService.ErrorAsync("Login failed: Invalid username, email or password");
            return;
        }

        await MessageBoxService.SuccessAsync("Login successful");
    }

    [RelayCommand]
    private async Task SwitchToRegister()
    {
        DialogService.HideCurrentDialog();
        await DialogService.ShowAsync(RegisterDialogViewModel);
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