using System.Collections.ObjectModel;
using DynamicData;

namespace EduPath.ViewModels.Pages;

public sealed partial class HomePageViewModel : ViewModelBase, IHomePageViewModel
{
    private readonly ReadOnlyObservableCollection<CourseInformation> _courses;
    private readonly SourceCache<CourseInformation, string> _sourceCache = new(x => x.Name);

    [ObservableProperty]
    private bool _isAdvancedSearch;

    private string _previousSearchText = string.Empty;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _watermark = "Search for courses by name...";

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

    partial void OnIsAdvancedSearchChanged(bool value)
    {
        (SearchText, _previousSearchText) = (_previousSearchText, SearchText);

        if (value)
        {
            Watermark = "Search course recommendations by preference...";
            return;
        }

        Watermark = "Search for courses by name...";
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

        Logger.Information("Advanced Searching for {SearchText}", SearchText);
        await AdvancedSearchAsync().ConfigureAwait(false);
    }

    private Task AdvancedSearchAsync() => OpenAIService.RecommendCourseByRequest(SearchText);
}