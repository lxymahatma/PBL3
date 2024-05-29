namespace PBL3.Services;

public class UserService : IUserService
{
    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IDatabaseService DatabaseService { get; init; } = null!;

    public bool Login(string? key, string? password)
    {
        if (key is null || password is null)
        {
            Logger.Information("Entered invalid information");
            return false;
        }

        var user = DatabaseService.GetUserFromKey(key);

        if (user is null)
        {
            Logger.Error("User with key {Key} not found", key);
            return false;
        }

        if (user.Password != password)
        {
            Logger.Error("Password incorrect");
            return false;
        }

        Logger.Information("User {UserName} logged in", user.UserName);
        return true;
    }
}