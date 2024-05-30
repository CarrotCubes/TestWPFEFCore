using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPFEFCore.Entity;

namespace TestWPFEFCore.Services
{
    public class CCCarService : ICarService
    {
        public Task<CarInfo?> GetCarInfo()
        {
            return new Task<CarInfo?>(() => new CarInfo());
        }
    }
}
