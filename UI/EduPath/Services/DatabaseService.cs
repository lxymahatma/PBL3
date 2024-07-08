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
            await LoadCoursesFromDatabaseAsync().ConfigureAwait(false);
        }

        return _courseDatabase;
    }

    private async Task LoadCoursesFromDatabaseAsync()
    {
        var stream = ResourceUtils.GetResource("CourseDatabase.json");
        _courseDatabase = await SerializationService.DeserializeAsync<CourseInformation[]>(stream).ConfigureAwait(false);
        Logger.Information("Course database loaded");
    }

    public void DeleteUserFromDatabase(User user)
    {
        _userDatabase.Remove(user.UserName!);
        _userDatabase.Remove(user.Email!);
        Logger.Information("User {UserName} with email {Email} deleted", user.UserName,user.Email);
    }
}