namespace SysTracker.Core.Entities;
public class Cpu : Hardware
{
    public UInt32 Cores { get; set; }
    public UInt32 Threads { get; set; }
    public UInt16 LoadPercentage { get; set; }
}
