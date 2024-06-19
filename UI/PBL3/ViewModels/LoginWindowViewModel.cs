namespace PBL3.ViewModels;

public partial class LoginWindowViewModel : ViewModelBase, ILoginWindowViewModel
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

        Key = null;
        Password = null;
    }

    [RelayCommand]
    private void Register()
    {
        
    }
}