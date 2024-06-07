namespace PBL3.Contracts;

public interface IDatabaseService
{
    Dictionary<string, CourseInformation> GetCoursesFromDatabase();
    Dictionary<string, User> GetUsersFromDatabase();

    User? GetUserFromKey(string key);
}