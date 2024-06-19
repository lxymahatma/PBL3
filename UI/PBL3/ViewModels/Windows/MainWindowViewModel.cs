namespace PBL3.ViewModels.Windows;

public sealed partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    [ObservableProperty]
    private string _searchText = string.Empty;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IUserService UserService { get; init; } = null!;

    [UsedImplicitly]
    public IDialogService DialogService { get; init; } = null!;

    [RelayCommand]
    private async Task OpenLoginPage()
    {
        var dialog = DialogService.CreateViewModel<IPopupWindowViewModel>();
        await DialogService.ShowDialogAsync(this, dialog);
    }

    [RelayCommand]
    private void Search()
    {
        Logger.Information("Searching for {SearchText}", SearchText);
    }
}