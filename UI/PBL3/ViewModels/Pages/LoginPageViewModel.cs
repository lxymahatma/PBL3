namespace PBL3.ViewModels.Pages;

public sealed partial class LoginPageViewModel : ViewModelBase, ILoginPageViewModel
{
    [ObservableProperty]
    [Required]
    private string? _key;

    [ObservableProperty]
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    private string? _password;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [RelayCommand]
    private void Login()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return;
        }

        var result = UserService.Login(Key!, Password!);
        if (result)
        {
            MessageBoxService.SuccessMessageBox("Success", "Login successful");
            return;
        }

        MessageBoxService.ErrorMessageBox("Error", "Login failed: Invalid key or password");

        Key = null;
        Password = null;
    }

    [RelayCommand]
    private void Register()
    {
        ValidateAllProperties();
    }
}