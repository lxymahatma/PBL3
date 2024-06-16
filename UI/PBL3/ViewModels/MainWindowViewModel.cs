namespace PBL3.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private string _searchText = string.Empty;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [RelayCommand]
    private void Search()
    {
        Logger.Information("Searching for {SearchText}", SearchText);
    }
    [RelayCommand]
    private void Login()
    {
        Logger.Information("Logging in");
    }
}