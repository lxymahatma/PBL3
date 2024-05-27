namespace PBL3.Services;

public class DatabaseService : IDatabaseService
{
    private static readonly Dictionary<string, User> _users = new()
    {
        ["user1"] = new User { UserId = 1, UserName = "user1", Password = "password1", Email = "aa@gmail.com" },
        ["user2"] = new User { UserId = 2, UserName = "user2", Password = "password2", Email = "bb@gmail.com" }
    };

    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    public Dictionary<string, User> GetUsersFromDatabase() => _users;

    public User? GetUserFromKey(string key) => _users.GetValueOrDefault(key);
}