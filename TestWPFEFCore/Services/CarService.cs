using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPFEFCore.Context;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;
using TestWPFEFCore.Services.Base;

namespace TestWPFEFCore.Services
{
    public class CarService : BaseService<CarInfo>, ICarService
    {
        private readonly IRespository<CarInfo>? _respository;

        public CarService(IRespository<CarInfo> _respository) : base(_respository)
        {
        }
    }
}
