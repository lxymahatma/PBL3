namespace PBL3.Contracts;

public interface IDatabaseService
{
    Dictionary<string, User> GetUsersFromDatabase();

    User? GetUserFromKey(string key);
}