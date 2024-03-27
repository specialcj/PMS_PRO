using com.itac.mes.imsapi.client.dotnet;
using com.itac.mes.imsapi.domain.container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.itac.easyworks.api.client.mii;

namespace PMS.ITAC
{
    public class trGetStationSetting
    {
        private IMSApiSessionContextStruct _sessionContext;
        private IMSApiDotNet _imsApi = null;


        public trGetStationSetting(InitItac init)
        {
            this._sessionContext = init.sessionContext;
            this._imsApi = init.imsApi;
        }

        private string _stationNumber;
        public string stationNumber { get => _stationNumber; set => _stationNumber = value; }
        
        private string[] _stationSettingResultKeys;
        public string[] stationSettingResultKeys 
        {
            get
            {
                if (_stationSettingResultKeys == null)
                {
                    _stationSettingResultKeys = new string[] { "ATTRIBUTE_1", "ATTRIBUTE_2", "", "ATTRIBUTE_3", "BOM_VERSION", "CUSTOMER_NAME", "CUSTOMER_PART_NUMBER", "MAX_RECURSION",
                        "PART_NUMBER", "PROCESS_LAYER", "STATION_NUMBER", "WORKORDER_NUMBER", "WORKORDER_STATE", "WORKORDER_TYPE" };
                }
                return _stationSettingResultKeys;
            }
            set => _stationSettingResultKeys = value; 
        }

        private string[] _stationSettingResultValues;
        public string[] StationSettingResultValues { get => _stationSettingResultValues; set => _stationSettingResultValues = value; }

        /// <summary>
        /// Error Message From ITAC
        /// </summary>
        private string _errorString;
        
        public string errorString
        {
            get { return _errorString; }
        }

        public int GetStationSetting()
        {
            int errorCode = this._imsApi.trGetStationSetting(this._sessionContext, this.stationNumber, this.stationSettingResultKeys, out this._stationSettingResultValues);

            if (errorCode != 0)
                this._imsApi.imsapiGetErrorText(this._sessionContext, errorCode, out this._errorString);
            
            return errorCode;
        }
    }
}
