using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShardingCore.Core.EntityMetadatas;
using ShardingCore.VirtualRoutes.Days;
using ShardingCore.VirtualRoutes.Months;
using TestWPFEFCore.Entity;

namespace TestWPFEFCore.VirtualTableRoute
{
    public class CarVirtualTableRoute : AbstractSimpleShardingDayKeyDateTimeVirtualTableRoute<CarInfo>
    {
        public override bool AutoCreateTableByTime()
        {
            return true;
        }

        public override void Configure(EntityMetadataTableBuilder<CarInfo> builder)
        {
            builder.ShardingProperty(o => o.CreateDate);
            builder.AutoCreateTable(true);
            builder.TableSeparator("_");
        }

        public override DateTime GetBeginTime()
        {
            //注意必须返回固定时间,不然每次启动时间都会变动
            return new DateTime(2021, 1, 1);
        }
    }
}
