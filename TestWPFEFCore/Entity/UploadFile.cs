using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPFEFCore.Entity
{
    public class UploadFile
    {
        [Key]
        public int Id { get; set; }
        public string Vin { get; set; }

        public string Sort { get; set; }

        public int Type { get; set; }

        //vin摄像-正前：2
        //vin摄像-正后：3
        //标准照片-正前：4
        //标准照片-正后：5
        //标准照片-正左：6
        //标准照片-正右：7
        //整车-左前：8
        //整车-右后：9
        //整车摄像-正前：10
        //整车摄像-正后：11
        public int Position { get; set; }

        public string FilePath { get; set; }

        public bool IsOk { get; set; }

        /// <summary>
        /// 0:还没有比对、1：比对失败、2：比对成功、3：vin补拍
        /// </summary>
        public int Status { get; set; }

        public string? VisionCode { get; set; }

        public string? ErrorMsg { get; set; }

        //public int CarId { get; set; }

        public CarInfo? CarInfo { get; set; }
    }
}
