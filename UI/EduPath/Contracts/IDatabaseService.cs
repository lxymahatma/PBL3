namespace EduPath.Contracts;

public interface IDatabaseService
{
    Task InitializeUserDatabaseAsync();
    Task<CourseInformation[]> GetCoursesFromDatabaseAsync();
    bool RegisterUser(User user);
    User? GetUserFromKey(string key);
    void DeleteUserFromDatabase(User user);
}