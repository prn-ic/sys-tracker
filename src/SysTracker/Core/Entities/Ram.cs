namespace SysTracker.Core.Entities;
public class Ram : Hardware
{
    public UInt64 CurrentUsage { get; set; }
    public int Percentage { get; set; } 
}
