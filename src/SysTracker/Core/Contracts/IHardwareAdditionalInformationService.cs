using SysTracker.Core.Entities;

namespace SysTracker.Core.Contracts;
public interface IHardwareAdditionalInformationService
{
    CpuAdditional GetProcessorInfo();
    GpuAdditional GetVideoInfo();
}
