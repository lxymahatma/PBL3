using Autofac;
using OpenAI;
using PBL3.Extensions.MarkupExtensions;
using PBL3.Services;
using PBL3.ViewModels;

namespace PBL3;

internal static class Bootstrapper
{
    private static readonly ContainerBuilder _builder = new();

    /// <summary>
    ///     Register all instances, services and view models
    ///     Configure static resolvers
    /// </summary>
    public static void Register()
    {
        RegisterInstances();
        RegisterServices();
        RegisterViewModels();

        var container = _builder.Build();

        ConfigureStaticResolvers(container);
    }

    /// <summary>
    ///     Register instances
    /// </summary>
    private static void RegisterInstances()
    {
        _builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();
        //_builder.RegisterInstance(new OpenAIClient(LoadFromFile())).SingleInstance();
    }

    /// <summary>
    ///     Register Services
    /// </summary>
    private static void RegisterServices()
    {
        _builder.RegisterType<DatabaseService>().As<IDatabaseService>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<OpenAIService>().As<IOpenAIService>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<UserService>().As<IUserService>().PropertiesAutowired().SingleInstance();
    }

    /// <summary>
    ///     Register all view models
    /// </summary>
    private static void RegisterViewModels()
    {
        _builder.RegisterType<LoginWindowViewModel>().As<ILoginWindowViewModel>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<RegisterWindowViewModel>().As<IRegisterWindowViewModel>().PropertiesAutowired().SingleInstance();
    }

    private static void ConfigureStaticResolvers(IContainer container)
    {
        DependencyInjectionExtension.Resolver = type => container.Resolve(type!);
    }

    private static string LoadFromFile(string path = "OpenAIKey.txt") => File.ReadAllText(path);
}