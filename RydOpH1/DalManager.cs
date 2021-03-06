using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Management;


namespace RydOpH1
{
    public static class DalManager
    {
        //public static List<string> PopulateDisk() // bruges ikke 
        //{
        //    List<string> disk = new List<string>();

        //    SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");

        //    ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(selectQuery);

        //    foreach (ManagementObject managementObject in managementObjectSearcher.Get())
        //    {
        //        disk.Add(managementObject.ToString());
        //    }
        //    return disk;
        //}

        // START

        // Method
        #region GetDiskMetaData.
        public static List<ManagementObject> GetDiskMetaData()
        {
            // Create list to contain the objects.
            List<ManagementObject> diskMetaData = new List<ManagementObject>();

            //create object searcher with no scope but a query.
            ManagementObjectSearcher diskMetaDataSearcher = new ManagementObjectSearcher("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            //get a collection of WMI objects.
            ManagementObjectCollection queryCollection = diskMetaDataSearcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                //PropertyDataCollection metaDataProperties = metaData.Properties;
                //foreach (PropertyData metaDataProperty in metaDataProperties)
                //{
                //    string name = metaData["Name"].ToString();
                //    string freeSpace = metaData["FreeSpace"].ToString();
                //    string size = metaData["Size"].ToString();
                //    metaDataProperty.
                //}

                    
                // adding the objects to the list.
                diskMetaData.Add(m);
            }
            return diskMetaData;
        }
        #endregion GetDiskMetaData.

        #region GetHardDiskSerialNumber.
        public static ManagementObject GetHardDiskSerialNumber(string drive)
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();
            
            return managementObject;
        }
        #endregion GetHardDiskSerialNumber.

        #region GetProcessorData.
        public static List<ManagementObject> GetProcessorData()
        {
            List<ManagementObject> processorData = new List<ManagementObject>();

            ObjectQuery objectQuery = new System.Management.ObjectQuery("select * from Win32_PerfFormattedData_PerfOS_Processor");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(objectQuery);
                        
            ManagementObjectCollection results = managementObjectSearcher.Get();

            foreach (ManagementObject m in results)
            {
                //var usage = managementObject["PercentProcessorTime"].ToString();
                //var name = managementObject["Name"].ToString();
                //ManagementObject test = new ManagementObject(usage, name);
                processorData.Add(m);
            }
            return processorData;           
        }
        #endregion GetprocessorData.

        #region GetMemoryData.
        public static List<ManagementObject> GetMemoryData()
        {
            List<ManagementObject> memoryData = new List<ManagementObject>();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject m in results)
            {
                memoryData.Add(m);
            }
            return memoryData;
        }
        #endregion GetMemoryData.

        #region GetUser.
        public static List<ManagementObject> GetUserData()
        {
            List<ManagementObject> userData = new List<ManagementObject>();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject m in results)
            {
                userData.Add(m);
            }
            return userData;
        }
        #endregion GetUserData.

        #region GetBootDeviceData.
        public static List<ManagementObject> GetBootDeviceData()
        {
            List<ManagementObject> bootDeviceData = new List<ManagementObject>();

            //create object searcher with scope and query
            ManagementObjectSearcher bootDeviceSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            
            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = bootDeviceSearcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                bootDeviceData.Add(m);
            }
            return bootDeviceData;
        }
        #endregion GetBootDeviceData.

        // Is not used since I could not figure out how to split up the ListAllServices code in Main to return the count as well
        // as the List.
        #region GetAllServices.
        public static List<ManagementObject> GetAllServicesData()
        {
            List<ManagementObject> allServicesData = new List<ManagementObject>();
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();


            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = windowsServicesSearcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                allServicesData.Add(m);
            }
            return allServicesData;
        }
        # endregion GetBootDeviceData.




    }

}

