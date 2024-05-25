using System.Configuration;
using System.Data;
using System.Windows;
using Example;
using Prism.DryIoc;
using Prism.Ioc;
using TestWPFEFCore.Context;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;
using TestWPFEFCore.Services;
using TestWPFEFCore.UnitOfWork;
using TestWPFEFCore.ViewModels;

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
            //containerRegistry.Register<IRespository<CarInfo>, Respository<CarInfo>>();
            containerRegistry.Register(typeof(IRespository<>), typeof(Respository<>));
            containerRegistry.Register<ICarService, CarService>();
        }
    }

}
