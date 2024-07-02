namespace EduPath.Contracts;

public interface INavigationService
{
    Frame ContentFrame { get; }
    void NavigateTo<T>();
    void NavigateTo(Type pageType);
}