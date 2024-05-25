using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;

namespace TestWPFEFCore.Services
{
    public class CarService : ICarService
    {
        private readonly IRespository<CarInfo> respository;
        public CarService(IRespository<CarInfo> _respository)
        {
            respository = _respository;
        }
        public async Task<CarInfo?> GetCarInfo()
        {
            return await respository.GetFirstOrDefaultAsync();
        }
    }
}
