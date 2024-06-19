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

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [RelayCommand]
    private void Register()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
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
            MessageBoxService.ErrorMessageBox("Register failed", "User already exists");
        }
    }
}