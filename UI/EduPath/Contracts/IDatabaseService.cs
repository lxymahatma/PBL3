namespace EduPath.Contracts;

public interface IDatabaseService
{
    Task<CourseInformation[]> GetCoursesFromDatabaseAsync();
    Dictionary<string,User> GetUsersFromDatabase();
    bool RegisterUser(User user);

    User? GetUserFromKey(string key);
    void DeleteUserFromDatabase(User user);
}