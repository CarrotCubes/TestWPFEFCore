using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Repository;
using TestWPFEFCore.Services.Base;

namespace TestWPFEFCore.Services
{
    public class UploadFileService : BaseService<UploadFile>, IUploadFileService
    {
        public UploadFileService(IRespository<UploadFile> _respository) : base(_respository)
        {
        }
    }
}
