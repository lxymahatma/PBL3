namespace PBL3;

public sealed class ViewLocator : StrongViewLocator
{
    public ViewLocator()
    {
        Register<RegisterPageViewModel, RegisterPage>();
        Register<MainWindowViewModel, MainWindow>();
        Register<LoginPageViewModel, LoginPage>();
        Register<PopupWindowViewModel, PopupWindow>();
    }
}