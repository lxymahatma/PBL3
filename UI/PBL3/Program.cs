using Avalonia;
#if !DEBUG
using PBL3.Models;
#endif

namespace PBL3;

internal static class Program
{
    private static readonly string LogPath = Path.Combine(AppContext.BaseDirectory, "Latest.log");

    [STAThread]
    public static void Main(string[] args)
    {
        // Prevent multiple launch
        using var mutex = new Mutex(true, nameof(PBL3));
        if (!mutex.WaitOne(TimeSpan.Zero, true))
        {
            return;
        }

        DeleteExistedLogFile();
        CreateLogger();
        RegisterDependencies();
        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            Log.Logger.Fatal(ex, "Unhandled exception");
        }
    }

    private static void RegisterDependencies() => Bootstrapper.Register();

    private static void DeleteExistedLogFile()
    {
        if (File.Exists(LogPath))
        {
            File.Delete(LogPath);
        }
    }

    private static void CreateLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
#if DEBUG
            .WriteTo.Console()
#else
            .WriteTo.File(new LogFileFormatter(), LogPath)
#endif
            .CreateLogger();
    }

    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}