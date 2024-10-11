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
        public CarService(IRespository<CarInfo> respository) : base(respository)
        {

        }
    }
}
