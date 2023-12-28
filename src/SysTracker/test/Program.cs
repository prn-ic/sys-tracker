using System.Management;
using System.Xml.Linq;

namespace test;

internal class Program
{
    static void Main(string[] args)
    {
        GetGpuPreferences();
        Console.WriteLine();
        GetCpuPreferences();
        Console.WriteLine();
        GetRamPreferences();
    }

    public static void GetGpuPreferences()
    {
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");

        Console.WriteLine("GPU: ");

        foreach (ManagementObject obj in objvide.Get())
        {
            Console.WriteLine("Name  -  " + obj["Name"] + "</br>");
            Console.WriteLine("DeviceID  -  " + obj["DeviceID"] + "</br>");
            Console.WriteLine("AdapterRAM  -  " + obj["AdapterRAM"] + "</br>");
            Console.WriteLine("AdapterDACType  -  " + obj["AdapterDACType"] + "</br>");
            Console.WriteLine("Monochrome  -  " + obj["Monochrome"] + "</br>");
            Console.WriteLine("DriverVersion  -  " + obj["DriverVersion"] + "</br>");
            Console.WriteLine("VideoProcessor  -  " + obj["VideoProcessor"] + "</br>");
            Console.WriteLine("VideoArchitecture  -  " + obj["VideoArchitecture"] + "</br>");
            Console.WriteLine("VideoMemoryType  -  " + obj["VideoMemoryType"] + "</br>");
            Console.WriteLine("Some  -  " + obj["Availability"] + "</br>");
        }
    }

    public static void GetCpuPreferences()
    {
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_Processor");

        Console.WriteLine("CPU: ");

        foreach (ManagementObject obj in objvide.Get())
        {
            Console.WriteLine("Name  -  " + obj["Manufacturer"] + "</br>");
            Console.WriteLine("Caption  -  " + obj["Caption"] + "</br>");
            Console.WriteLine("DeviceID  -  " + obj["DeviceID"] + "</br>");
            Console.WriteLine("Cores  -  " + obj["NumberOfCores"] + "</br>");
            Console.WriteLine("Current Speed  -  " + obj["CurrentClockSpeed"] + "</br>");
            Console.WriteLine("Max Speed  -  " + obj["MaxClockSpeed"] + "</br>");
            Console.WriteLine("Percentage  -  " + obj["LoadPercentage"] + "</br>");
            Console.WriteLine("Threads  -  " + obj["ThreadCount"] + "</br>");
        }
    }

    public static void GetRamPreferences()
    {
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

        Console.WriteLine("RAM: ");

        foreach (ManagementObject obj in objvide.Get())
        {
            ulong totalRam = Convert.ToUInt64(obj["TotalVisibleMemorySize"]); 
            ulong busyRam = totalRam - Convert.ToUInt64(obj["FreePhysicalMemory"]);
            Console.WriteLine("Busy  -  " + ((busyRam * 100) / totalRam) + "</br>"); 
        }
    }
}
