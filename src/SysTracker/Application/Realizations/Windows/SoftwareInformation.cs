using System.Management;
using SysTracker.Core.Contracts;

namespace SysTracker.Application.Realizations.Windows;
public class SoftwareInformation : ISoftwareInformation
{
    public Core.Entities.OperatingSystem GetSystemInfo()
    {
#pragma warning disable CA1416 // Validate platform compatibility
        ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

        Core.Entities.OperatingSystem os = new Core.Entities.OperatingSystem(objvide.Get());

        return os;
#pragma warning restore CA1416 // Add explicit cast
    }

}
