namespace PBL3.Services;

public partial class NavigationService : ObservableObject, INavigationService
{
    [ObservableProperty]
    private Frame _contentFrame = new();

    public void NavigateTo<T>() => ContentFrame.Navigate(typeof(T));
    public void NavigateTo(Type pageType) => ContentFrame.Navigate(pageType);
}