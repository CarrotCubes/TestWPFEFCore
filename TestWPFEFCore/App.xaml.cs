using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using TestWPFEFCore.Context;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;
using TestWPFEFCore.Services;
using TestWPFEFCore.UnitOfWork;
using TestWPFEFCore.ViewModels;
using TestWPFEFCore.Views;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace TestWPFEFCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.Register<WPFDBContext>();
            containerRegistry.Register<IUnitOfWork, UnitOfWork.UnitOfWork>();
            containerRegistry.Register(typeof(IRespository<>), typeof(Respository<>));
            containerRegistry.Register<ICarService, CCCarService>("cc");
            containerRegistry.Register<ICarService, CarService>("c");

        }

        // WithoutFastExpressionCompiler()  该行代码在DryIOC 5.0 版本已经删除，应该是Prism默认配置的还是存在该行代码，所以要重写该方法，把  WithoutFastExpressionCompiler() 去掉
        //protected override Rules CreateContainerRules()
        //{
        //    return Rules.Default.WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
        //                        .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
        //                        .WithFuncAndLazyWithoutRegistration()
        //                        .WithTrackingDisposableTransients()
        //                        //.WithoutFastExpressionCompiler() 
        //                        .WithFactorySelector(Rules.SelectLastRegisteredFactory());
        //}

        protected override IContainerExtension CreateContainerExtension()
        {
            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<WPFDBContext>(options =>
            options.UseMySql(conn, new MySqlServerVersion(new Version(5, 7, 37))));

            serviceCollection.AddLogging(logbuilder => logbuilder.AddSerilog());

            // 通过DruIoc扩展 IServiceCollection
            //return new DryIocContainerExtension(new Container(CreateContainerRules())
            //            .WithDependencyInjectionAdapter(serviceCollection));

            var container = new UnityContainer();
            container.BuildServiceProvider(serviceCollection);

            return new UnityContainerExtension(container);

        }

        protected override void Initialize()
        {
            var basePath = AppContext.BaseDirectory;
            string path = Path.Combine(basePath + @"Logs", @"Log.txt");
            string piDataPath = Path.Combine(basePath + "Logs", "PIData", "PIDataLog.txt");
            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Information()
                   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                   .Enrich.FromLogContext() // 从 LogContext 中获取信息 
                   .WriteTo.Console()
                   // 正常输入的日志
                   .WriteTo.Logger(x => x.Filter.ByExcluding(Matching.WithProperty("PIData"))
                   .WriteTo.File(path, rollingInterval: RollingInterval.Day, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}"))
                   // PI盒推送的原始报文日志
                   .WriteTo.Logger(x => x.Filter.ByIncludingOnly(Matching.WithProperty("PIData"))
                   .WriteTo.File(piDataPath, rollingInterval: RollingInterval.Day, shared: true, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Message:lj}{NewLine}{Exception}"))
                   .CreateLogger();
            base.Initialize();
        }
    }

}
