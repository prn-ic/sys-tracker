using System.Reflection;

namespace SysTracker.Desktop.Services.InfoViewer.Models;
public class SmallTableModel
{
    public string Title { get; set; } = "Undefined";
    public string Content { get; set; } = "Undefined";
    public SmallTableModel(FieldInfo fieldInfo, object type)
    {
        Title = fieldInfo.Name.Replace("<", "")
                .Replace(">", "")
                .Replace("k__BackingField", ""); ;
        Content = fieldInfo.GetValue(type)!.ToString()!;
    }
}
