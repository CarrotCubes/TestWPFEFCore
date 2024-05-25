using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPFEFCore.Entity;

namespace TestWPFEFCore.Services
{
    public interface ICarService
    {
        Task<CarInfo?> GetCarInfo();
    }
}
