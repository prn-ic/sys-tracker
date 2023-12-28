using System.Management;
using System.Reflection;
using SysTracker.Core.Contracts;
using SysTracker.Core.Entities;

namespace SysTracker.Application.Realizations.Windows;

public class HardwareAdditionalInformationService : IHardwareAdditionalInformationService
{
#pragma warning disable CA1416 // Validate platform compatibility
    public CpuAdditional GetProcessorInfo()
    {
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_Processor");

        CpuAdditional cpu = new CpuAdditional(objvide.Get());

        return cpu;
    }

    public GpuAdditional GetVideoInfo()
    {
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");

        GpuAdditional gpu = new GpuAdditional(objvide.Get());

        return gpu;
    }
#pragma warning restore CA1416 // Add explicit cast
}
