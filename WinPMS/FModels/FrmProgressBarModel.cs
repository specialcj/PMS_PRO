using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPMS.FModels
{
    public class FrmProgressBarModel
    {
        public FrmProgressBar FrmProgressBar { get; set; }
        public FrmLoginModel FrmLoginModel { get; set; }
        public string PMSVersion { get; set; }
        public RDRAlvCanComms RdrAlvCanComms { get; set; }
        public Action LoadAction { get; set; }

    }
}
