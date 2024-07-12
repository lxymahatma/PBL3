namespace EduPath.ViewModels.Dialogs;

public sealed partial class LoginDialogViewModel : ViewModelBase, ILoginDialogViewModel
{
    [ObservableProperty]
    private bool _isRevealPassword;

    [ObservableProperty]
    [Required(ErrorMessage = "UserName or Email is required")]
    [MinLength(3, ErrorMessage = "UserName or Email must be at least 3 characters long")]
    private string? _key;

    [ObservableProperty]
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [MaxLength(20, ErrorMessage = "Password must be at most 20 characters long")]
    private string? _password;

    public ContentDialog DialogSettings => new() { Content = this };

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

        DialogService.CloseCurrentDialog();
        await MessageBoxService.SuccessAsync("Login successful").ConfigureAwait(true);
        NavigationService.NavigateTo<HomePage>();
    }

    [RelayCommand]
    private Task SwitchToRegisterAsync() => DialogService.SwitchDialogAsync(RegisterDialogViewModel);

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public INavigationService NavigationService { get; init; } = null!;

    [UsedImplicitly]
    public IRegisterDialogViewModel RegisterDialogViewModel { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    #endregion
}