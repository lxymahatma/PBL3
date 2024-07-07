namespace EduPath.Contracts;

public interface IDatabaseService
{
    Task<CourseInformation[]> GetCoursesFromDatabaseAsync();
    Task GetUsersFromDatabase();
    bool RegisterUser(User user);

    User? GetUserFromKey(string key);
}