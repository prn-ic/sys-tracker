using System.Management;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace SysTracker.Core.Entities;
public class OperatingSystem : EntityBase
{
    public string? Name { get; set; }
    public string? BootDevice { get; set; }
    public string? BuildNumber { get; set; }
    public string? Caption { get; set; }
    public string? CountryCode { get; set; }
    public string? Description { get; set; }
    public string? Locale { get; set; }
    public string? InstallDate { get; set; }
    public string? Manufacturer { get; set; }
    public string? NumberOfUsers { get; set; }
    public string? OSArchitecture { get; set; }
    public string? OSLanguage { get; set; }
    public string? ProductType { get; set; }
    public string? SerialNumber { get; set; }
    public string? Version { get; set; }
    public string? Organization { get; set; }
    public string? SystemDevice { get; set; }

    public OperatingSystem()
    {
    }

    public OperatingSystem(ManagementObjectCollection objects)
    {

        var fields = typeof(OperatingSystem).GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding
        );

        foreach (ManagementObject obj in objects)
        {
            foreach (FieldInfo field in fields)
            {
                string fieldName = field.Name.Replace("<", "")
                .Replace(">", "")
                .Replace("k__BackingField", "") ?? "";

                string value = obj[fieldName] is null ? "Unknown" : obj[fieldName].ToString()!;

                field.SetValue(this, value);

            }
        }
    }
}
