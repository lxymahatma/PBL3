using Autofac;
using PBL3.Extensions.MarkupExtensions;
using PBL3.Services;

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

        ConfigureStaticResolvers(_container);
    }

    /// <summary>
    ///     Register instances
    /// </summary>
    private static void RegisterComponents()
    {
        _builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();
        //_builder.RegisterInstance(new OpenAIClient(LoadFromFile())).SingleInstance();
        _builder.Register(_ => new DialogService(
                new DialogManager(new ViewLocator(),
                    new DialogFactory().AddFluent()),
                x => _container.Resolve(x)))
            .As<IDialogService>().SingleInstance();
        _builder.RegisterType<User>().SingleInstance();
    }

    /// <summary>
    ///     Register Services
    /// </summary>
    private static void RegisterServices()
    {
        _builder.RegisterType<DatabaseService>().As<IDatabaseService>().PropertiesAutowired().SingleInstance();
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
        _builder.RegisterType<LoginPageViewModel>().As<ILoginPageViewModel>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().PropertiesAutowired().SingleInstance();
        _builder.RegisterType<RegisterPageViewModel>().As<IRegisterPageViewModel>().PropertiesAutowired().SingleInstance();
    }

    private static void ConfigureStaticResolvers(IContainer container)
    {
        DependencyInjectionExtension.Resolver = type => container.Resolve(type!);
    }

    private static string LoadFromFile(string path = "OpenAIKey.txt") => File.ReadAllText(path);
}