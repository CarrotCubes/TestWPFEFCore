using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using TestWPFEFCore.Context;
using TestWPFEFCore.Services;

namespace TestWPFEFCore.ViewModels
{
    partial class MainWindowViewModel : BindableBase
    {
        public DelegateCommand DelegateCommand { get; set; }

        private readonly ICarService _carService;

        public MainWindowViewModel(ICarService carService)
        {
            _carService = carService;
            DelegateCommand = new DelegateCommand(async () =>
            {
                var sss = await _carService.GetCarInfo();
            });
        }
    }
}
