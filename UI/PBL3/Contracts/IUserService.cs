namespace PBL3.Contracts;

public interface IUserService
{
    bool LoggedIn { get; }
    bool Login(string key, string password);
    bool Register(User user);
}