using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOpH1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Would have liked it to have these types of calls: managementObject["Name"] put in DAL and then be able to call it from main.

            #region GetDiskMetaData.
            List<ManagementObject> diskMetaData = LogicLayer.ReturnDiskMetaData();
            PrintStart("Disk Meta data start");
            foreach (ManagementObject managementObject in diskMetaData )
            {
                Console.WriteLine("Disk Name : " + managementObject["Name"]);

                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"]);

                Console.WriteLine("Disk Size: " + managementObject["Size"]);
                
                Console.WriteLine("---------------------------------------------------");
            }
            PrintEnd("Disk Meta data end");
            #endregion GetDiskMetaData.

            #region GetHardDiskSerialNumber.
            ManagementObject serialNumber = LogicLayer.ReturnHardDiskSerialNumber("C");
            PrintStart("\nSerialNumber");
            Console.WriteLine(serialNumber["VolumeSerialNumber"]);
            #endregion GetHardDiskSerialNumber.

            #region GetProcessorData.
            List<ManagementObject> processorData = LogicLayer.ReturnProcessorData();
            PrintStart("\nProcessor data start");
            foreach (ManagementObject obj in processorData)
            {
                Console.WriteLine("Name: " + obj["Name"] + "," + " Percent Processor Time: " + obj["PercentProcessorTime"]);
                Console.WriteLine("CPU");
            }
            PrintEnd("Processor data end");
            #endregion GetProcessorData.

            #region GetMemoryData.
            List<ManagementObject> memoryData = LogicLayer.ReturnMemoryData();
            PrintStart("\nMemory data start");
            foreach (ManagementObject obj in memoryData)
            {
                Console.WriteLine("Total Visible Memory: {0}KB", obj["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", obj["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", obj["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", obj["FreeVirtualMemory"]);
            }
            PrintEnd("Memory data end");
            #endregion GetMemoryData.

            #region GetUserData.
            List<ManagementObject> userData = LogicLayer.ReturnUserData();
            PrintStart("\nUser data start");
            foreach (ManagementObject obj in userData)
            {
                Console.WriteLine("User:\t{0}", obj["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", obj["Organization"]);
                Console.WriteLine("O/S :\t{0}", obj["Name"]);
            }
            PrintEnd("User data end");
            #endregion GetUserData.

            #region GetBootDeviceData.
            List<ManagementObject> bootDeviceData = LogicLayer.ReturnBootDeviceData();
            PrintStart("\nBootDevice data start");
            foreach (ManagementObject obj in userData)
            {
                Console.WriteLine("BootDevice : {0}", obj["BootDevice"]);
            }
            PrintEnd("BootDevice data end");
            #endregion GetBootDeviceData.

            #region GetAllServicesData.
            //List<ManagementObject> allServicesData = LogicLayer.ReturnBootDeviceData();
            //PrintStart("\nAll Services data start");
            // foreach (ManagementObject windowsService in objectCollection)
            //{
            //    PropertyDataCollection serviceProperties = windowsService.Properties;
            //    foreach (PropertyData serviceProperty in serviceProperties)
            //    {
            //        if (serviceProperty.Value != null)
            //        {
            //            Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
            //            Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
            //        }
            //    }
            //Console.WriteLine("---------------------------------------");
            //PrintEnd("All Services data end");
            #endregion GetAllServicesData.

            Console.WriteLine("\nprocess søgning");
            // Could not figure out how to get it to work from DAL/LOGIC/MAIN
            LISTAllServices(); 

            Console.ReadKey();

        } //Slut main 

        public static void PrintStart(string query)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(query);
            Console.ResetColor();
        }
        public static void PrintEnd(string query)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(query);
            Console.ResetColor();
        }

        // could not figure out how to split up the ListAllServices code in Main to return the count as well
        private static void LISTAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            Console.WriteLine("There are {0} Windows services: ", objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }

}
