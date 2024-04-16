using System.Net.Http;
using Autofac;
using PBL3.Contracts;
using PBL3.Extensions.MarkupExtensions;
using PBL3.ViewModels;
using Serilog;

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
        _builder.RegisterInstance(new HttpClient());
    }

    /// <summary>
    ///     Register all view models
    /// </summary>
    private static void RegisterViewModels()
    {
        _builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().PropertiesAutowired().SingleInstance();
    }

    private static void ConfigureStaticResolvers(IContainer container)
    {
        DependencyInjectionExtension.Resolver = type => container.Resolve(type!);
    }
}