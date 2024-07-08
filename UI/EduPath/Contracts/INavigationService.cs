namespace EduPath.Contracts;

public interface INavigationService
{
    Frame ContentFrame { get; }
    void NavigateTo<T>();
    void NavigateToNull();
    void NavigateToWithoutNotify<T>();
}