using Avalonia.Media.Imaging;
using FluentAvalonia.UI.Windowing;
using PBL3.Utils;

namespace PBL3.Views.Windows;

public sealed partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();
        using var stream = ResourceUtils.GetResource("avares://PBL3/Assets/icon.ico");
        var appIcon = new Bitmap(stream);
        SplashScreen = new SplashScreen
        {
            AppName = "PBL3",
            AppIcon = appIcon,
            MinimumShowTime = 500
        };
    }
}