using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPMS.FModels
{
    public class FrmModel
    {
        /// <summary>
        /// 操作类型标识值
        /// </summary>
        public int ActType { get; set; }

        /// <summary>
        /// 当前用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Action委托，用于跨页面刷新
        /// </summary>
        public Action ReLoadAction { get; set; }

        /// <summary>
        /// Func委托
        /// </summary>
        public Func<Task> ReLoadTask { get; set; }
    }
}
