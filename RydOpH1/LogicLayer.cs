using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Management;

namespace RydOpH1
{
    public static class LogicLayer
    {
        // Method ReturnDiskMetaData.
        #region ReturnDiskMetaData.
        public static List <ManagementObject> ReturnDiskMetaData()
        {
            return DalManager.GetDiskMetaData();
        }
        #endregion ReturnDiskMetaData.

        // Method ReturnHardDiskSerialNumber.
        #region ReturnHardDiskSerialNumber.
        public static ManagementObject ReturnHardDiskSerialNumber(string drive)
        {
            return DalManager.GetHardDiskSerialNumber(drive);
        }
        #endregion ReturnHardDiskSerialNumber.

        // Method ReturnProcessorData,
        #region ReturnProcessorData.
        public static List<ManagementObject> ReturnProcessorData()
        {
            return DalManager.GetProcessorData();
        }
        #endregion ReturnProcessorData.

        // Method ReturnMemoryData,
        #region ReturnMemoryData.
        public static List<ManagementObject> ReturnMemoryData()
        {
            return DalManager.GetMemoryData();
        }
        #endregion ReturnMemoryData.

        // Method ReturnUserData
        #region ReturnUserData.
        public static List<ManagementObject> ReturnUserData()
        {
            return DalManager.GetUserData();
        }
        #endregion ReturnUserData.

        // Method ReturnBootDeviceData
        #region ReturnBootDeviceData.
        public static List<ManagementObject> ReturnBootDeviceData()
        {
            return DalManager.GetBootDeviceData();
        }
        #endregion ReturnBootDeviceData.

        // Method ReturnAllServicesData
        // Is not used since I could not figure out how to split up the ListAllServices code in Main to return the count as well
        // as the List.
        #region ReturnAllServicesData.
        public static List<ManagementObject> ReturnAllServices()
        {
            return DalManager.GetAllServicesData();
        }
        #endregion ReturnAllServicesData.
    }

}
