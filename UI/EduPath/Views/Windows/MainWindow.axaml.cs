using FluentAvalonia.UI.Windowing;

namespace EduPath.Views.Windows;

public sealed partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();
        SplashScreen = new SplashScreen
        {
            MinimumShowTime = 1500,
            SplashScreenContent = new SplashScreenPage()
        };
    }
}