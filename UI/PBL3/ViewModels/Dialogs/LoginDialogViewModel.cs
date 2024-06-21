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
    private async Task LoginAsync()
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
            await MessageBoxService.ErrorAsync("Login failed: Invalid username, email or password").ConfigureAwait(false);
            return;
        }

        await MessageBoxService.SuccessAsync("Login successful").ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task SwitchToRegisterAsync() =>
        await DialogService.SwitchDialogAsync(RegisterDialogViewModel, () => UserService.IsRegistered).ConfigureAwait(false);

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