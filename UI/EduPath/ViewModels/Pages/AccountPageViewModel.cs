namespace EduPath.ViewModels.Pages;

public sealed partial class AccountPageViewModel : ViewModelBase, IAccountPageViewModel
{
    [RelayCommand]
    private async Task DeleteAccountAsync()
    {
        Logger.Information("Request for deleting current user...");
        UserService.DeleteCurrentUser();
        NavigationService.NavigateToNull();
        await MessageBoxService.SuccessAsync("User has been successfully deleted!").ConfigureAwait(true);
        await DialogService.ShowAsync(LoginDialogViewModel).ConfigureAwait(false);
    }

    #region Services

    [UsedImplicitly]
    public User User { get; init; } = null!;

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public ILoginDialogViewModel LoginDialogViewModel { get; init; } = null!;

    [UsedImplicitly]
    public IMessageBoxService MessageBoxService { get; init; } = null!;

    [UsedImplicitly]
    public INavigationService NavigationService { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    #endregion
}