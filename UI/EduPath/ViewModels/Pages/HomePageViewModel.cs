using System.Collections.ObjectModel;
using DynamicData;

namespace EduPath.ViewModels.Pages;

public sealed partial class HomePageViewModel : ViewModelBase, IHomePageViewModel
{
    private readonly ReadOnlyObservableCollection<CourseInformation> _courses;
    private readonly SourceCache<CourseInformation, string> _sourceCache = new(x => x.Name);

    [ObservableProperty]
    private bool _isAdvancedSearch;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IOpenAIService OpenAIService { get; init; } = null!;

    [UsedImplicitly]
    public IDatabaseService DatabaseService { get; init; } = null!;

    public ReadOnlyObservableCollection<CourseInformation> Courses => _courses;

    public HomePageViewModel()
    {
        _sourceCache.Connect()
            .Filter(x => string.IsNullOrEmpty(SearchText) ||
                         x.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            .SortBy(x => x.Name)
            .Bind(out _courses)
            .Subscribe();
    }

    [RelayCommand]
    private async Task GetCoursesAsync()
    {
        Logger.Information("Getting courses...");
        var courses = await DatabaseService.GetCoursesFromDatabaseAsync().ConfigureAwait(false);
        _sourceCache.AddOrUpdate(courses);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (!IsAdvancedSearch)
        {
            Logger.Information("Normal Searching for {SearchText}", SearchText);
            _sourceCache.Refresh();
            return;
        }

        await AdvancedSearchAsync().ConfigureAwait(false);
    }

    private Task AdvancedSearchAsync() => OpenAIService.RecommendCourseByRequest(SearchText);
}