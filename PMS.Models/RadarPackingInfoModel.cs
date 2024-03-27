using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.MODELS
{
    public class RadarPackingInfoModel
    {
        /// <summary>
        /// 操作类型标识值
        /// </summary>
        public int ActType { get; set; }

        public RadarPackingIniModel RadarPackingIniModel { get; set; }

        /// <summary>
        /// 雷达包装Ini文件
        /// </summary>
        public string RadarPackingIniFile { get; set; }

        /// <summary>
        /// 选中Section的序号
        /// </summary>
        public int RadarPackingSelectedSectionNum { get; set; }

        /// <summary>
        /// 选中Section下的所有key的数量
        /// </summary>
        public int RadarPackingSelectedKeyCounts { get; set; }

        public Action CheckRadarPackingInfoIsDo { get; set; }

        /// <summary>
        /// Action委托
        /// </summary>
        public Action ReLoadAction { get; set; }

        /// <summary>
        /// Func委托
        /// </summary>
        public Func<Task> ReLoadTask { get; set; }

    }
}
