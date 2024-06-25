namespace PBL3.ViewModels.Dialogs;

public sealed partial class RegisterDialogViewModel : ViewModelBase, IRegisterDialogViewModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    private string? _email;

    [ObservableProperty]
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [MaxLength(20, ErrorMessage = "Password must be at most 20 characters long")]
    private string? _password;

    [ObservableProperty]
    [Required]
    [MinLength(3, ErrorMessage = "UserName must be at least 3 characters long")]
    [MaxLength(15, ErrorMessage = "UserName must be at most 15 characters long")]
    private string? _userName;

    public ContentDialog DialogSettings => new() { Content = this };

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
    private Task SwitchToLoginAsync() => DialogService.SwitchDialogAsync(LoginDialogViewModel, () => UserService.IsLoggedIn);

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