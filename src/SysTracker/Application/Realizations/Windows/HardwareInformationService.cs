using System.Management;
using SysTracker.Core.Contracts;
using SysTracker.Core.Entities;

namespace SysTracker.Application.Realizations.Windows;
public class HardwareInformationService : IHardwareInformationService
{
    public Ram GetMemoryInfo()
    {
#pragma warning disable CA1416 // Validate platform compatibility
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

        Ram ram = new Ram();

        foreach (ManagementObject obj in objvide.Get())
        {
            ram.Name = obj["Name"].ToString();
            ram.Manufacturer = obj["Caption"].ToString();
            ram.Capacity = (UInt64) obj["TotalVisibleMemorySize"];
            ram.CurrentUsage = (UInt64) obj["FreePhysicalMemory"];
        }

        return ram;
#pragma warning restore CA1416 // Add explicit cast
    }

    public Cpu GetProcessorInfo()
    {
#pragma warning disable CA1416 // Validate platform compatibility
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_Processor");

        Cpu cpu = new Cpu();

        foreach (ManagementObject obj in objvide.Get())
        {
            cpu.Name = obj["Name"].ToString();
            cpu.Cores = (uint) obj["NumberOfCores"];
            cpu.Threads = (uint) obj["ThreadCount"];
            cpu.DeviceId = obj["DeviceID"].ToString();
            cpu.LoadPercentage = (ushort) (obj["LoadPercentage"] ?? (ushort) 0);
            cpu.Capacity = (uint) obj["MaxClockSpeed"];
        }

        return cpu;
#pragma warning restore CA1416 // Add explicit cast
    }
}
