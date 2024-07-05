namespace EduPath.Services;

public sealed class DatabaseService : IDatabaseService
{
    private static readonly Dictionary<string, User> _userDatabase = new()
    {
        ["user1"] = new User { UserName = "user1", Password = "password1", Email = "aa@gmail.com" },
        ["user2"] = new User { UserName = "user2", Password = "password2", Email = "bb@gmail.com" }
    };

    private CourseInformation[]? _courseDatabase;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public ISerializationService SerializationService { get; init; } = null!;

    public Task GetUsersFromDatabase() => throw new NotImplementedException();

    public bool RegisterUser(User user)
    {
        if (_userDatabase.ContainsKey(user.UserName!) || _userDatabase.ContainsKey(user.Email!))
        {
            Logger.Error("User {UserName} with Email {Email} already exists", user.UserName, user.Email);
            return false;
        }

        _userDatabase[user.UserName!] = user;
        _userDatabase[user.Email!] = user;
        Logger.Information("User {UserName} added with Email {Email} and Password {Password}",
            user.UserName, user.Email, user.Password);
        return true;
    }

    public User? GetUserFromKey(string key) => _userDatabase.GetValueOrDefault(key);

    public async Task<CourseInformation[]> GetCoursesFromDatabaseAsync()
    {
        while (_courseDatabase is null)
        {
            await LoadCoursesFromDatabase();
        }

        return _courseDatabase;
    }

    private async Task LoadCoursesFromDatabase()
    {
        if (!File.Exists("CourseDatabase.json"))
        {
            Logger.Error("Course database not found");
            return;
        }

        var json = await File.ReadAllTextAsync("CourseDatabase.json");
        _courseDatabase = await SerializationService.DeserializeAsync<CourseInformation[]>(json);
        Logger.Information("Course database loaded");
    }
}