using System.Management;

namespace SysTracker.Core.Entities;
public class RamAdditional : Hardware
{
    public string? BankLabel { get; set; }
    public string? DeviceLocator { get; set; }
    public string? FormFactor { get; set; }
    public string? HotSwappable { get; set; }
    public string? MaxVoltage { get; set; }
    public string? Speed { get; set; }

    public RamAdditional()
    {

    }

    public RamAdditional(ManagementObjectCollection objects)
    {
#pragma warning disable CA1416 // Validate platform compatibility
        foreach (ManagementObject obj in objects)
        {
            Name = obj["Name"].ToString();
            Manufacturer = obj["Manufacturer"].ToString();
            DeviceId = obj["Tag"].ToString();
            Capacity = (UInt64)obj["Capacity"];
            BankLabel = obj["BankLabel"].ToString();
            DeviceLocator = obj["DeviceLocator"].ToString();
            FormFactor = obj["FormFactor"].ToString();
            HotSwappable = obj["HotSwappable"] is null? "Unknown" : obj["HotSwappable"].ToString(); 
            MaxVoltage = obj["MaxVoltage"].ToString();
            Speed = obj["Speed"].ToString();
        }

#pragma warning restore CA1416 // Validate platform compatibility
    }
}
