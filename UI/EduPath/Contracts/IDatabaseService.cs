namespace EduPath.Contracts;

public interface IDatabaseService
{
    Dictionary<string, CourseInformation> GetCoursesFromDatabase();
    Dictionary<string, User> GetUsersFromDatabase();
    bool RegisterUser(User user);

    User? GetUserFromKey(string key);
}