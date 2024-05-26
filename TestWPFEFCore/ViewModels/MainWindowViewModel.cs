using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DryIoc;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using TestWPFEFCore.Context;
using TestWPFEFCore.Services;
using TestWPFEFCore.Views;

namespace TestWPFEFCore.ViewModels
{
    partial class MainWindowViewModel : BindableBase
    {
        public DelegateCommand DelegateCommand { get; set; }

        public MainWindowViewModel(IContainerProvider provider, IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MyUserControl1));
            DelegateCommand = new DelegateCommand(() =>
            {
                MyWindow1 myWindow1 = provider.Resolve<MyWindow1>();
                myWindow1.ShowDialog();
            });
        }
    }
}
