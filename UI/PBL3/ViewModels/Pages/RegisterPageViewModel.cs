namespace PBL3.ViewModels.Pages;

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

    [RelayCommand]
    private void Register()
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
            MessageBoxService.Error("Register failed: User already exists");
        }
    }

    /*[RelayCommand]
    private void SwitchToLoginPage() => PopupWindowViewModel.SwitchTab(0);*/

    #region Services

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    #endregion
}