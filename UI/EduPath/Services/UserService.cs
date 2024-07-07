namespace EduPath.Services;

public sealed class UserService : IUserService
{
    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IDatabaseService DatabaseService { get; init; } = null!;

    [UsedImplicitly]
    public User User { get; init; } = null!;

    public bool IsLoggedIn { get; private set; }
    public bool IsRegistered { get; private set; }

    public void Login(string key, string password)
    {
        var user = DatabaseService.GetUserFromKey(key);

        if (user is null)
        {
            Logger.Error("User with key {Key} not found", key);
            return;
        }

        if (user.Password != password)
        {
            Logger.Error("Password incorrect");
            return;
        }

        User.CopyFrom(user);
        Logger.Information("User {UserName} logged in", user.UserName);
        IsLoggedIn = true;
    }

    public void Register(User user) => IsRegistered = DatabaseService.RegisterUser(user);
}