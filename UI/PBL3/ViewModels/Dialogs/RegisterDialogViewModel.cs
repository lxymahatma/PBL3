namespace PBL3.ViewModels.Dialogs;

public sealed partial class RegisterDialogViewModel : ViewModelBase, IRegisterDialogViewModel
{
    [ObservableProperty]
    [Required]
    [EmailAddress]
    private string? _email;

    [ObservableProperty]
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    private string? _password;

    [ObservableProperty]
    [Required]
    [MinLength(3)]
    [MaxLength(15)]
    private string? _userName;

    public ContentDialog DialogSettings => new()
    {
        Content = this,
        Title = "User Register",
        PrimaryButtonText = "Register",
        SecondaryButtonText = "Login",
        DefaultButton = ContentDialogButton.Primary,
        PrimaryButtonCommand = RegisterCommand,
        SecondaryButtonCommand = SwitchToLoginCommand
    };

    [RelayCommand]
    private async Task RegisterAsync()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return;
        }

        var user = new User
        {
            Email = Email!,
            Password = Password!,
            UserName = UserName!
        };

        UserService.Register(user);
        if (!UserService.IsRegistered)
        {
            await MessageBoxService.ErrorAsync("Register failed: User already exists").ConfigureAwait(false);
            return;
        }

        await SwitchToLoginAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task SwitchToLoginAsync() =>
        await DialogService.SwitchDialogAsync(LoginDialogViewModel, () => UserService.IsLoggedIn).ConfigureAwait(false);

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public ILoginDialogViewModel LoginDialogViewModel { get; init; } = null!;

    #endregion
}