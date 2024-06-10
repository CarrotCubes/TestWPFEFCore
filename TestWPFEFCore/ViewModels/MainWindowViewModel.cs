using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using TestWPFEFCore.Context;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Services;
using TestWPFEFCore.Views;
using Unity;

namespace TestWPFEFCore.ViewModels
{
    partial class MainWindowViewModel : BindableBase
    {
        public DelegateCommand DelegateCommand { get; set; }

        [Dependency("c")]
        public ICarService? _carService;

        [Dependency]
        public IUploadFileService _uploadFileService;

        [Dependency]
        public ILogger<MainWindowViewModel>? _logger;

        [Dependency]
        public IDistributedCache? _cache;

        public MainWindowViewModel(IContainerProvider provider, IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MyUserControl1));
            DelegateCommand = new DelegateCommand(async () =>
            {
                _logger?.LogInformation("TestLog");
                var sss = provider.Resolve<ICarService>("cc");
                var ddd = provider.Resolve<ICarService>("c");
                List<CarInfo>? carInfos = await _carService.GetAllAsync(include: x => x.Include(x => x.UploadFile));
                List<UploadFile>? result = await _uploadFileService.GetAllAsync();
                // redis 读写操作
                //_cache?.SetString("userName", "bing234");
                //_cache?.SetString("userNameqww", "444");
                //string? name = _cache?.GetString("userName");
                bool flag = sss == ddd;
                bool flag2 = _carService == sss;
                //MyWindow1 myWindow1 = provider.Resolve<MyWindow1>();
                //myWindow1.ShowDialog();
            });
        }
    }
}
