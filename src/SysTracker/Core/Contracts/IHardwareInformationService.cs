using SysTracker.Core.Entities;

namespace SysTracker.Core.Contracts;
public interface IHardwareInformationService
{
    Cpu GetProcessorInfo();
    Ram GetMemoryInfo();
}
