using System.ComponentModel.DataAnnotations;

namespace PBL3.ViewModels;

public partial class LoginWindowViewModel : ViewModelBase, ILoginWindowViewModel
{
    [Required]
    [ObservableProperty]
    private string? _key;

    [Required]
    [ObservableProperty]
    private string? _password;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [RelayCommand]
    private void Login()
    {
        var result = UserService.Login(Key, Password);
        if (result)
        {
            return;
        }

        Key = null;
        Password = null;
    }
}