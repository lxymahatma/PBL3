namespace PBL3;

public sealed class ViewLocator : StrongViewLocator
{
    public ViewLocator()
    {
        Register<HomePageViewModel, HomePage>();
        Register<LoginPageViewModel, LoginPage>();
        Register<MainWindowViewModel, MainWindow>();
        Register<RegisterPageViewModel, RegisterPage>();
    }
}