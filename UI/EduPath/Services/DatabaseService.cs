namespace EduPath.Services;

public sealed class DatabaseService : IDatabaseService
{
    private static readonly Dictionary<string, User> _users = new()
    {
        ["user1"] = new User { UserName = "user1", Password = "password1", Email = "aa@gmail.com" },
        ["user2"] = new User { UserName = "user2", Password = "password2", Email = "bb@gmail.com" }
    };

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public Dictionary<string, CourseInformation> GetCoursesFromDatabase() => throw new NotImplementedException();

    public Dictionary<string, User> GetUsersFromDatabase() => _users;

    public bool RegisterUser(User user)
    {
        if (_users.ContainsKey(user.UserName!) || _users.ContainsKey(user.Email!))
        {
            Logger.Error("User {UserName} with Email {Email} already exists", user.UserName, user.Email);
            return false;
        }

        _users[user.UserName!] = user;
        _users[user.Email!] = user;
        Logger.Information("User {UserName} added with Email {Email} and Password {Password}",
            user.UserName, user.Email, user.Password);
        return true;
    }

    public User? GetUserFromKey(string key) => _users.GetValueOrDefault(key);
}