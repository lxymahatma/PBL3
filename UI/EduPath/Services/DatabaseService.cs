namespace EduPath.Services;

public sealed class DatabaseService : IDatabaseService
{
    private readonly Dictionary<string, Guid> _emailToId = new();
    private readonly Dictionary<Guid, User> _userDatabase = new();
    private readonly Dictionary<string, Guid> _usernameToId = new();

    private CourseInformation[]? _courseDatabase;

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public ISerializationService SerializationService { get; init; } = null!;

    public async Task InitializeUserDatabaseAsync()
    {
        var stream = ResourceUtils.GetResource("UserDatabase.json");
        var users = await SerializationService.DeserializeAsync<User[]>(stream).ConfigureAwait(false);
        foreach (var user in users!)
        {
            _userDatabase[user.UserId] = user;
            _usernameToId[user.UserName!] = user.UserId;
            _emailToId[user.Email!] = user.UserId;
        }

        Logger.Information("User database loaded");
    }

    public bool RegisterUser(User user)
    {
        if (_usernameToId.ContainsKey(user.UserName!) || _emailToId.ContainsKey(user.Email!))
        {
            Logger.Error("User {UserName} with Email {Email} already exists", user.UserName, user.Email);
            return false;
        }

        user.UserId = Guid.NewGuid();
        _userDatabase[user.UserId] = user;
        _usernameToId[user.UserName!] = user.UserId;
        _emailToId[user.Email!] = user.UserId;
        Logger.Information("User {UserName} registered with Email {Email} and Password {Password}",
            user.UserName, user.Email, user.Password);
        return true;
    }

    public User? GetUserFromKey(string key)
    {
        Guid userId;
        if (_usernameToId.TryGetValue(key, out userId) || _emailToId.TryGetValue(key, out userId))
        {
            return _userDatabase[userId];
        }

        return null;
    }

    public async Task<CourseInformation[]> GetCoursesFromDatabaseAsync()
    {
        if (_courseDatabase is null)
        {
            await LoadCoursesFromDatabaseAsync().ConfigureAwait(false);
        }

        return _courseDatabase!;
    }

    public void DeleteUserFromDatabase(User user)
    {
        _userDatabase.Remove(user.UserId);
        _usernameToId.Remove(user.UserName!);
        _emailToId.Remove(user.Email!);
        Logger.Information("User {UserName} with email {Email} deleted", user.UserName, user.Email);
    }

    private async Task LoadCoursesFromDatabaseAsync()
    {
        var stream = ResourceUtils.GetResource("CourseDatabase.json");
        _courseDatabase = await SerializationService.DeserializeAsync<CourseInformation[]>(stream).ConfigureAwait(false);
        Logger.Information("Course database loaded");
    }
}