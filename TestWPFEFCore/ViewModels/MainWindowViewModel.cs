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

                int count = 100000;
                Task task1 = null;
                Task task2 = null;

                int addNum = 1;

                while (count-- > 0)
                {
                    task1 = Task.Run(() =>
                    {
                        try
                        {
                            //await Task.Delay(200);
                            ICarService carService1 = provider.Resolve<ICarService>("c");
                            carService1.BeginTransaction();
                            CarInfo? carInfo = carService1.GetFirst(predicate: x => x.Vin == "123");
                            carInfo.UserId = Interlocked.Increment(ref addNum);
                            carService1.Update(carInfo);
                            carService1.CommitTransaction();
                        }
                        catch (Exception ex)
                        {

                        }
                    });

                    task2 = Task.Run(() =>
                    {
                        try
                        {
                            //await Task.Delay(200);
                            ICarService carService2 = provider.Resolve<ICarService>("c");
                            carService2.BeginTransaction();
                            CarInfo? carInfo = carService2.GetFirst(predicate: x => x.Vin == "123");
                            carInfo.UserId = Interlocked.Decrement(ref addNum);
                            carService2.Update(carInfo);
                            carService2.CommitTransaction();
                        }
                        catch (Exception ex)
                        {

                        }
                    });
                }

                Task.WaitAll(task1, task2);

                List<UploadFile>? result = await _uploadFileService.GetAllAsync();
                // redis 读写操作
                //_cache?.SetString("userName", "bing234");
                //_cache?.SetString("userNameqww", "444");
                //string? name = _cache?.GetString("userName");
                bool flag = sss == ddd;
                bool flag2 = _carService == ddd;
                //MyWindow1 myWindow1 = provider.Resolve<MyWindow1>();
                //myWindow1.ShowDialog();
            });
        }
    }
}
