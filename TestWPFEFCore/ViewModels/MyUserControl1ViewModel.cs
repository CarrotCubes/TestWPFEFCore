using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Mvvm;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Services;

namespace TestWPFEFCore.ViewModels
{
    public class MyUserControl1ViewModel : BindableBase
    {
        private readonly ICarService _carService;

        private readonly ILogger<MyUserControl1ViewModel> _logger;

        public MyUserControl1ViewModel(ICarService carService, ILogger<MyUserControl1ViewModel> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        public DelegateCommand command => new DelegateCommand(async () =>
        {
            CarInfo? sss = await _carService.GetCarInfo();
            _logger.LogInformation(sss.Vin);
            await Task.Delay(1000000);
        });
    }
}
