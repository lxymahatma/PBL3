namespace EduPath.ViewModels.Pages;

public sealed partial class HomePageViewModel : ViewModelBase, IHomePageViewModel
{
    [ObservableProperty]
    private string _searchText = string.Empty;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IDatabaseService DatabaseService { get; init; } = null!;

    [RelayCommand]
    private async Task GetCoursesAsync()
    {
        Logger.Information("Getting courses...");
        var courses = await DatabaseService.GetCoursesFromDatabaseAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private void Search()
    {
        Logger.Information("Searching for {SearchText}", SearchText);
    }
}