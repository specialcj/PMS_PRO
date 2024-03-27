using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.MODELS.DModels
{
    public class StationSetupModel
    {
        private string _PartNr;
        public string PartNr { get => _PartNr; set => _PartNr = value; }

        private string _BomVersion;
        public string BomVersion { get => _BomVersion; set => _BomVersion = value; }

        private string _BomIndex;
        public string BomIndex { get => _BomIndex; set => _BomIndex = value; }

        private string _PartDesc;
        public string PartDesc { get => _PartDesc; set => _PartDesc = value; }

        private string _WorkOrder;
        public string WorkOrder { get => _WorkOrder; set => _WorkOrder = value; }

        private string _Quantity;
        public string Quantity { get => _Quantity; set => _Quantity = value; }

        private string _State;
        public string State { get => _State; set => _State = value; }

        private string _CadPartNr;
        public string CadPartNr { get => _CadPartNr; set => _CadPartNr = value; }

        private string _ProcessLayer;
        public string ProcessLayer { get => _ProcessLayer; set => _ProcessLayer = value; }

        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        
        private string _CustomerPartNr;
        public string CustomerPartNr { get => _CustomerPartNr; set => _CustomerPartNr = value; }

        private string _Attribut1;
        public string Attribut1 { get => _Attribut1; set => _Attribut1 = value; }

        private string _ErrorString;
        public string ErrorString { get => _ErrorString; set => _ErrorString = value; }

        //private string _Result;
        //public string Result { get => _Result; set => _Result = value; }

        //private string _SessionId;
        //public string SessionId { get => _SessionId; set => _SessionId = value; }

        //private string _StationNr;
        //public string StationNr { get => _StationNr; set => _StationNr = value; }
        
    }
}
