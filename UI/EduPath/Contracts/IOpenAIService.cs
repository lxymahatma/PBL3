namespace EduPath.Contracts;

public interface IOpenAIService
{
    Task RecommendCourseByRequest(string request);
}