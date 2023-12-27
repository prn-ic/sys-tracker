namespace SysTracker.Core.Entities;
public class Hardware : EntityBase
{
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    public string? DeviceId { get; set; }
    public UInt64 Capacity { get; set; }
}
