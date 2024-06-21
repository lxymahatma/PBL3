namespace PBL3.ViewModels.Dialogs;

public sealed partial class RegisterDialogViewModel : ViewModelBase, IRegisterDialogViewModel
{
    [ObservableProperty]
    [Required]
    [EmailAddress]
    private string? _email;

    private bool _isSwitch;

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

    public ContentDialog GetDialogSettings()
    {
        var dialog = new ContentDialog
        {
            Content = this,
            Title = "User Register",
            PrimaryButtonText = "Register",
            SecondaryButtonText = "Login",
            DefaultButton = ContentDialogButton.Primary,
            PrimaryButtonCommand = RegisterCommand,
            SecondaryButtonCommand = SwitchToLoginCommand
        };
        dialog.Closing += (_, args) => args.Cancel = !UserService.IsRegistered && !_isSwitch;
        return dialog;
    }

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

        UserService.Register(user);
        if (!UserService.IsRegistered)
        {
            await MessageBoxService.ErrorAsync("Register failed: User already exists");
            return;
        }

        await SwitchToLogin();
    }

    [RelayCommand]
    private async Task SwitchToLogin()
    {
        _isSwitch = true;
        DialogService.HideCurrentDialog();
        await DialogService.ShowAsync(LoginDialogViewModel);
        _isSwitch = false;
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