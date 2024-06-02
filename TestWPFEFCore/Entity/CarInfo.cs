using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPFEFCore.Entity
{
    [Table("Car")]
    public class CarInfo
    {
        [Key]
        public int Id { get; set; }
        [Column]
        public string? Vin { get; set; }

        [Column]
        public string? CarBodyCode { get; set; }

        public string? CarType { get; set; }
        [Column]
        public string? Brand { get; set; }
        [Column]
        public string? Factory { get; set; }
        [Column]
        public string? Cyqdm { get; set; }
        [Column]
        public string? Clsbdh { get; set; }
        [Column]
        public string? Csys { get; set; }
        [Column]
        public string? Cllx { get; set; }
        [Column]
        [DefaultValue(false)]
        public bool? DisplayFinish { get; set; } = false;

        /// <summary>
        /// 数据是否已经上传预查验
        /// </summary>
        public bool PhotoEnabled { get; set; }

        public bool CameraEnabled { get; set; }

        public bool CarAllPhotoOk { get; set; }

        public bool IsCreatePdf { get; set; }

        public bool StandardImageCommit { get; set; }
        /// <summary>
        /// 信息科接口是否调用成功。0：失败，1：成功
        /// </summary>
        public bool ExcuteCheckInterface { get; set; }

        [Column]
        public int? UserId { get; set; }
        [Column]
        public string? UserName { get; set; }


        public string? Sfx { get; set; }

        public int Status { get; set; }

        /// <summary>
        /// 在vin里当做是否需要补拍，null或空字符串需要补拍；“1”不需要补拍(一次审核)；“0” 当作跳过，不把Other=0的展示出来
        /// </summary>
        public string? Other { get; set; }



        /// <summary>
        /// 手动跳过标识，99表示手动跳过，0表示没有跳过
        /// </summary>
        public int IsManual { get; set; }

        public IEnumerable<UploadFile>? UploadFiles { get; set; }

    }
}
