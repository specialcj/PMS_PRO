using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.MODELS
{
    public class RadarPackingWIModel
    {
        /// <summary>
        /// Shipping号
        /// </summary>
        public string ColAShippingPN { get; set; }

        /// <summary>
        /// 客户料号
        /// </summary>
        public string ColBCustomerPN { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        public string ColCSupplierCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string ColDQty { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string ColEDescription { get; set; }

        /// <summary>
        /// 包装箱
        /// </summary>
        public string ColFPackingBox { get; set; }

    }
}
