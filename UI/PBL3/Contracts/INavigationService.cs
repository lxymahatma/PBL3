namespace PBL3.Contracts;

public interface INavigationService
{
    Frame ContentFrame { get; set; }
    void NavigateTo<T>();
    void NavigateTo(Type pageType);
}