using FluentAvalonia.UI.Controls;

namespace PBL3.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private string _searchText = string.Empty;

    [RelayCommand]
    private async Task OpenLoginPage()
    {
        do
        {
            var loginPageButtonResult = await DialogService.ShowContentDialogAsync(this, LoginPageViewModel.Settings);
            await LoginPageButtonResult(loginPageButtonResult);
        } while (!UserService.IsLoggedIn);
    }

    private async Task<bool> LoginPageButtonResult(ContentDialogResult result)
    {
        switch (result)
        {
            case ContentDialogResult.Primary:
                return await LoginPageViewModel.Login();
            case ContentDialogResult.Secondary:
                var registerPageButtonResult = await DialogService.ShowContentDialogAsync(this, RegisterPageViewModel.Settings);
                return await RegisterPageButtonResult(registerPageButtonResult);
            case ContentDialogResult.None:
                return false;
            default:
                return false;
        }
    }

    private async Task<bool> RegisterPageButtonResult(ContentDialogResult result)
    {
        switch (result)
        {
            case ContentDialogResult.Primary:
                var registerResult = await RegisterPageViewModel.Register();
                if (registerResult)
                {
                    return true;
                }

                var registerPageButtonResult = await DialogService.ShowContentDialogAsync(this, RegisterPageViewModel.Settings);
                return await RegisterPageButtonResult(registerPageButtonResult);

            case ContentDialogResult.Secondary:
                var loginPageButtonResult = await DialogService.ShowContentDialogAsync(this, LoginPageViewModel.Settings);
                return await LoginPageButtonResult(loginPageButtonResult);
            case ContentDialogResult.None:
                return false;
            default:
                return false;
        }
    }

    [RelayCommand]
    private void Search()
    {
        Logger.Information("Searching for {SearchText}", SearchText);
    }

    #region Services

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILoginPageViewModel LoginPageViewModel { get; init; } = null!;

    [UsedImplicitly]
    public IRegisterPageViewModel RegisterPageViewModel { get; init; } = null!;

    #endregion
}