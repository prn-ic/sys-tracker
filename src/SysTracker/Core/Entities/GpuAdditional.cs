using System.Management;

namespace SysTracker.Core.Entities;
public class GpuAdditional : Hardware
{
    public string? AdapterRam { get; set; }
    public string? Monochrome { get; set; }
    public string? DriverVersion { get; set; }
    public string? VideoProcessor { get; set; }
    public string? VideoArchitecture { get; set; }
    public string? VideoMemoryType { get; set; }
    public string? InstalledDisplayDrivers { get; set; }
    public GpuAdditional()
    {
    }
    public GpuAdditional(ManagementObjectCollection objCollection)
    {
        foreach (ManagementObject obj in objCollection)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Name = obj["Name"].ToString();
            DeviceId = obj["DeviceID"].ToString();
            AdapterRam = ((uint)obj["AdapterRAM"] / (1024 * 1024)).ToString() + " Mb";
            Monochrome = obj["Monochrome"].ToString();
            DriverVersion = obj["DriverVersion"].ToString();
            VideoProcessor = obj["VideoProcessor"].ToString();
            VideoArchitecture = Enum.GetName((VideoArchitectureEnum)(UInt16)obj["VideoArchitecture"]) ?? "";
            VideoMemoryType = Enum.GetName((VideoMemoryType)(UInt16)obj["VideoMemoryType"]) ?? "";
            InstalledDisplayDrivers = obj["InstalledDisplayDrivers"].ToString();
            Capacity = (uint)obj["AdapterRAM"];
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
public enum VideoArchitectureEnum
{
    Another = 1,
    Undefined = 2,
    CGA = 3,
    EGA = 4,
    VGA = 5,
    SVGA = 6, 
    MDA = 7,
    HGC = 8,
    MCGA = 9,
    _8514A = 10,
    XGA = 11,
    Linear = 12,
    PC_98 = 160
}

public enum VideoMemoryType
{
    Another = 1,
    Undefined = 2,
    VRAM = 3,
    DRAM = 4,
    SRAM = 5,
    WRAM = 6,
    RAM_EDO = 7,
    Sync_DRAM = 8,
    PB_SRAM = 9,
    CDRAM = 10,
    _3DRAM = 11,
    SDRAM = 12,
    SGRAM = 13
}

