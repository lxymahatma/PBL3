using Autofac;
using PBL3.Extensions.MarkupExtensions;
using PBL3.Services;
using IContainer = Autofac.IContainer;

namespace PBL3;

internal static class Bootstrapper
{
    private static readonly ContainerBuilder _builder = new();
    private static IContainer _container = null!;

    /// <summary>
    ///     Register all instances, services and view models
    ///     Configure static resolvers
    /// </summary>
    public static void Register()
    {
        RegisterComponents();
        RegisterServices();
        RegisterViewModels();

        _container = _builder.Build();

        ConfigureStaticResolvers();
    }

    /// <summary>
    ///     Register instances
    /// </summary>
    private static void RegisterComponents()
    {
        _builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();
        //_builder.RegisterInstance(new OpenAIClient(LoadFromFile())).SingleInstance();
        _builder.RegisterType<User>().SingleInstance();
    }

    /// <summary>
    ///     Register Services
    /// </summary>
    private static void RegisterServices()
    {
        _builder.RegisterType<DatabaseService>().As<IDatabaseService>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<DialogService>().As<IDialogService>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<MessageBoxService>().As<IMessageBoxService>().SingleInstance();
        _builder.RegisterType<OpenAIService>().As<IOpenAIService>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<UserService>().As<IUserService>().PropertiesAutowired().SingleInstance();
    }

    /// <summary>
    ///     Register all view models
    /// </summary>
    private static void RegisterViewModels()
    {
        _builder.RegisterType<HomePageViewModel>().As<IHomePageViewModel>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<LoginDialogViewModel>().As<ILoginDialogViewModel>()
            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
            .SingleInstance();
        _builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<RegisterDialogViewModel>().As<IRegisterDialogViewModel>()
            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
            .SingleInstance();
    }

    private static void ConfigureStaticResolvers()
    {
        DependencyInjectionExtension.Resolver = type => _container.Resolve(type!);
    }

    private static string LoadFromFile(string path = "OpenAIKey.txt") => File.ReadAllText(path);
}