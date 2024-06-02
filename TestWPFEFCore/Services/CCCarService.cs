using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;
using TestWPFEFCore.Services.Base;

namespace TestWPFEFCore.Services
{
    public class CCCarService : BaseService<CarInfo>, ICarService
    {
        public CCCarService(IRespository<CarInfo> _respository) : base(_respository)
        {
        }
    }
}
