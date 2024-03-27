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
    public class InitItac
    {
        private IMSApiDotNet _imsApi = null;

        public IMSApiDotNet imsApi
        {
            get
            {
                if (null == _imsApi)
                {
                    throw new Exception("Please load iTac Library and Initial.");
                }
                return _imsApi;
            }
        }

       
        private IMSApiSessionValidationStruct _sessionValidationStruct;
        public IMSApiSessionValidationStruct sessionValidationStruct { get => _sessionValidationStruct; set => _sessionValidationStruct = value; }

        private IMSApiSessionContextStruct _sessionContext;
        public IMSApiSessionContextStruct sessionContext { get => _sessionContext; set => _sessionContext = value; }

        public string errorString(int errorCode)
        {
            string _errorString = "";
            if (errorCode != 0)
            {
                this._imsApi.imsapiGetErrorText(this._sessionContext, errorCode, out _errorString);
            }
            else
            {
                _errorString = "";
            }
            
            return _errorString;
        }

        /// <summary>
        /// false -> logout
        /// true -> login
        /// </summary>
        private bool _status = false;
    
        public bool IsLogin
        {
            get => _status;
        }

        public InitItac()
        {

        }

        public int Login()
        {
            this._imsApi = IMSApiDotNet.loadLibrary();
            int rtn = this._imsApi.imsapiInit();

            if (rtn == 0)
            {
                rtn = this._imsApi.regLogin(this._sessionValidationStruct, out this._sessionContext);
            }

            if (rtn == 0)
            {
                this._status = true;
            }
            else
            {
                this._status = false;
            }

            return rtn;
        }

        public int Logout()
        {
            int rtn = this._imsApi.regLogout(this._sessionContext);

            if (rtn == 0)
            {
                this._imsApi.imsapiShutdown();
            }

            this._status = false;

            return rtn;
        }
    }
}
