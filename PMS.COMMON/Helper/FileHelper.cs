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

        /// <summary>
        /// define the parameters of Conformity Report
        /// </summary>
        public static string sIniPMS_Conformity_Report_TestEngineer = "";
        public static string sIniPMS_Conformity_Report_PME = "";
        public static string sIniPMS_Conformity_Report_TestManager = "";
        public static string sIniPMS_Conformity_Report_PlantQualityManager = "";


        #endregion


        #region define Ini Section
        /// <summary>
        /// "PMS"
        /// </summary>
        public const string INI_SECTION_PMS = "PMS";

        public const string INI_PMS_LOCAL_SECTION = "PMS_Local";

        public const string INI_PMS_CONFORMITY_REPORT_SECTION = "PMS_Conformity_Report";

        public const string INI_SECTION_VEONEER = "Veoneer";

        public const string INI_SECTION_RDR = "RDR";

        public const string INI_RDR_SEL_SECTION = "RDR_SEL";

        public const string INI_SECTION_RDR1_SEL = "RDR1_SEL";

        public const string INI_SECTION_RDR2_SEL = "RDR2_SEL";

        public const string INI_SECTION_RDR3_SEL = "RDR3_SEL";

        public const string INI_SECTION_RDR4_SEL = "RDR4_SEL";

        public const string INI_SECTION_RDR5_SEL = "RDR5_SEL";

        public const string INI_SECTION_RDR_ALV_CAN_COMMS_DLL = "RDR_ALV_CAN_COMMS_DLL";

        public const string INI_SECTION_RDR1_ALV_CAN_COMMS_DLL = "RDR1_ALV_CAN_COMMS_DLL";

        public const string INI_SECTION_RDR2_ALV_CAN_COMMS_DLL = "RDR2_ALV_CAN_COMMS_DLL";

        public const string INI_SECTION_RDR3_ALV_CAN_COMMS_DLL = "RDR3_ALV_CAN_COMMS_DLL";
        
        public const string INI_SECTION_RDR4_ALV_CAN_COMMS_DLL = "RDR4_ALV_CAN_COMMS_DLL";
        
        public const string INI_SECTION_RDR5_ALV_CAN_COMMS_DLL = "RDR5_ALV_CAN_COMMS_DLL";
        #endregion

    }
}
