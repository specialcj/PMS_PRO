using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.COMMON.Helper
{
    public class FileHelper
    {
        public static string sAppStartPath = "";

        /// <summary>
        /// .exe文件的路径..\bin\Debug\xxx.exe
        /// </summary>
        public static string sExeFilePath = "";

        /// <summary>
        /// .exe文件目录的路径..\bin\Debug
        /// </summary>
        public static string sExeFolderPath = "";

        /// <summary>
        /// ..\..\bin\Debug\Config\PMS.ini
        /// </summary>
        public static string sIniFilePathPMS = "";

        /// <summary>
        /// ..\..\bin\Debug\Config\PMS_CFM.ini
        /// </summary>
        public static string sIniFilePathCFM = "";

        /// <summary>
        /// ..\..\bin\Debug\Config\PMS_Debug.ini
        /// </summary>
        public static string sIniFilePathDebug = "";

        /// <summary>
        /// ..\..\bin\Debug\Config\PMS_Local.ini
        /// </summary>
        public static string sIniFilePathLocal = "";

        /// <summary>
        /// ..\..\bin\Debug\DModels\MenuInfos.txt
        /// </summary>
        public static string sMenuInfosTxtPath = "";


        #region parameters defined in PMS.ini
        public static string sIniPMSDev = "";

        public static string sIniPMSUsage = "";

        public static string sIniPMSFtpUpdate = "";

        //public static string sIniPMSVersion = "";

        public static string sIniPwdOpr = "";

        public static string sIniPwdEncrypt = "";

        public static string sIniFormStartup = "";
        #endregion


        #region parameters defined in PMS_Local.ini
        /// <summary>
        /// define the input path of .HEIC file
        /// </summary>
        public static string sIniPMSLocalPath1 = "";

        /// <summary>
        /// define the output path of .jpg file
        /// </summary>
        public static string sIniPMSLocalPath2 = "";
        #endregion


        #region define Ini Section
        /// <summary>
        /// "PMS"
        /// </summary>
        public static string sIniPMSSection = "PMS";

        public static string sIniPMSLocalSection = "PMS_Local";

        public static string sIniVeoneerSection = "Veoneer";

        public static string sIniRDRSection = "RDR";

        public static string sIniRDRSELSection = "RDR_SEL";

        public static string sIniRDR1SELSection = "RDR1_SEL";

        public static string sIniRDR2SELSection = "RDR2_SEL";

        public static string sIniRDR3SELSection = "RDR3_SEL";

        public static string sIniRDR4SELSection = "RDR4_SEL";

        public static string sIniRDR5SELSection = "RDR5_SEL";

        public static string sIniRDRAlvCanCommsDllSection= "RDR_ALV_CAN_COMMS_DLL";

        public static string sIniRDR1AlvCanCommsDllSection= "RDR1_ALV_CAN_COMMS_DLL";

        public static string sIniRDR2AlvCanCommsDllSection= "RDR2_ALV_CAN_COMMS_DLL";

        public static string sIniRDR3AlvCanCommsDllSection= "RDR3_ALV_CAN_COMMS_DLL";
        
        public static string sIniRDR4AlvCanCommsDllSection= "RDR4_ALV_CAN_COMMS_DLL";
        
        public static string sIniRDR5AlvCanCommsDllSection= "RDR5_ALV_CAN_COMMS_DLL";
        #endregion

    }
}
