namespace PBL3.ViewModels.Dialogs;

public sealed partial class RegisterPageViewModel : ViewModelBase, IRegisterPageViewModel
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

    public ContentDialog Settings => new()
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
    private async Task Register()
    {
        while (!await TryRegister())
        {
            await DialogService.ShowAsync(this);
        }

        await SwitchToLogin();
    }

    private async Task<bool> TryRegister()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return false;
        }

        var user = new User
        {
            Email = Email!,
            Password = Password!,
            UserName = UserName!
        };

        var result = UserService.Register(user);
        if (result)
        {
            return true;
        }

        await MessageBoxService.ErrorAsync("Register failed: User already exists");
        return false;
    }

    [RelayCommand]
    private async Task SwitchToLogin() => await DialogService.ShowAsync(LoginPageViewModel);

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
    public ILoginPageViewModel LoginPageViewModel { get; init; } = null!;

    #endregion
}