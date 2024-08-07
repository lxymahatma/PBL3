﻿namespace EduPath.Contracts;

public interface IUserService
{
    bool IsLoggedIn { get; }
    bool IsRegistered { get; }
    void Login(string key, string password);
    void Register(User user);
    void DeleteCurrentUser();
}