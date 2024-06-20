using FluentAvalonia.UI.Controls;

namespace PBL3.ViewModels.Pages;

public sealed partial class LoginPageViewModel : ViewModelBase, ILoginPageViewModel
{
    [ObservableProperty]
    [Required]
    [MinLength(3)]
    private string? _key;

    [ObservableProperty]
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    private string? _password;

    public ContentDialogSettings Settings => new()
    {
        Content = this,
        Title = "User Login",
        PrimaryButtonText = "Login",
        SecondaryButtonText = "Register",
        DefaultButton = ContentDialogButton.Primary
    };

    public async Task<bool> Login()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Logger.Error("Entered invalid information");
            return false;
        }

        var result = UserService.Login(Key!, Password!);
        if (!result)
        {
            await MessageBoxService.ErrorAsync("Login failed: Invalid username, email or password");
            Key = null;
            Password = null;
            return false;
        }

        await MessageBoxService.SuccessAsync("Login successful");
        return true;
    }

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    #endregion
}