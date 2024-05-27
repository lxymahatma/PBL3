namespace PBL3.Services;

public class UserService : IUserService
{
    [UsedImplicitly]
    public ILogger Logger { get; init; } = null!;

    [UsedImplicitly]
    public IDatabaseService DatabaseService { get; init; } = null!;

    public bool Login(string key, string password)
    {
        var user = DatabaseService.GetUserFromKey(key);

        if (user is null)
        {
            Logger.Error("User not found");
            return false;
        }

        if (user.Password != password)
        {
            Logger.Error("Password incorrect");
            return false;
        }

        Logger.Information("User logged in");
        return true;
    }
}