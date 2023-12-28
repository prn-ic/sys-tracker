using System.Management;

namespace SysTracker.Core.Entities;
public enum ProcessorArch
{
    x86 = 0,
    MIPS = 1,
    Alpha = 2,
    PowerPC = 3,
    ARM = 5,
    ia64 = 6,
    x64 = 9,
    ARM64 = 12
}
public class CpuAdditional : Hardware
{
    public string? Architecture { get; set; } = "";
    public string? Caption { get; set; } = "";
    public string? Description { get; set; } = "";
    public string? PartNumber { get; set; } = "";
    public string? SerialNumber { get; set; } = "";
    public UInt32 Cores { get; set; }
    public UInt32 Threads { get; set; }
    public UInt16 LoadPercentage { get; set; }
    public string? ClockSpeed { get; set; }
    public CpuAdditional()
    {

    }

    public CpuAdditional(ManagementObjectCollection objCollection)
    {
        foreach (ManagementObject obj in objCollection)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Name = obj["Name"].ToString();
            Architecture = Enum.GetName((ProcessorArch)(UInt16)obj["Architecture"]) ?? "";
            Caption = obj["Caption"].ToString();
            Description = obj["Description"].ToString();
            PartNumber = obj["PartNumber"].ToString();
            SerialNumber = obj["SerialNumber"].ToString();
            Cores = (uint)obj["NumberOfCores"];
            Threads = (uint)obj["ThreadCount"];
            DeviceId = obj["DeviceID"].ToString();
            LoadPercentage = (ushort)(obj["LoadPercentage"] ?? (ushort)0);
            Capacity = (uint)obj["MaxClockSpeed"];
            ClockSpeed = obj["MaxClockSpeed"].ToString() + " GHz";
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
