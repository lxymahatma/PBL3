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
    private async Task Register()
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

        var result = UserService.Register(user);
        if (!result)
        {
            await MessageBoxService.ErrorAsync("Register failed: User already exists");
            return;
        }

        await SwitchToLogin();
    }

    [RelayCommand]
    private async Task SwitchToLogin()
    {
        DialogService.HideCurrentDialog();
        await DialogService.ShowAsync(LoginDialogViewModel);
    }

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