namespace PBL3.Contracts;

public interface IUserService
{
    bool Login(string key, string password);
}