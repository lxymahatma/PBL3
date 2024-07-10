namespace EduPath.Contracts;

public interface IOpenAIService
{
    Task<string> RecommendCourseByRequestAsync(string request);
}