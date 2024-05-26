using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using TestWPFEFCore.Views;

namespace TestWPFEFCore.ViewModels
{
    public class MyWindow1ViewModel : BindableBase
    {
        public MyWindow1ViewModel(IRegionManager regionManager, IContainerProvider container)
        {

        }
    }
}
