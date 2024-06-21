namespace PBL3.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private string _searchText = string.Empty;

    [RelayCommand]
    private async Task OpenLoginPage() => await DialogService.ShowAsync(LoginDialogViewModel, () => UserService.IsLoggedIn);

    [RelayCommand]
    private void Search()
    {
        Logger.Information("Searching for {SearchText}", SearchText);
    }
    
    [RelayCommand]
    private void Settings()
    {
        Logger.Information("Opening settings");
    }

    #region Services

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public ILoginDialogViewModel LoginDialogViewModel { get; init; } = null!;

    #endregion
}