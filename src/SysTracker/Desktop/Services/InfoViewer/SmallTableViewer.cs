using System.Collections.Generic;
using System.Reflection;
using SysTracker.Core.Entities;
using SysTracker.Desktop.Services.InfoViewer.Models;

namespace SysTracker.Desktop.Services.InfoViewer;
public class SmallTableViewer : IInfoViewer<List<SmallTableModel>>
{
    public List<SmallTableModel> View<E>(E data) where E : Hardware
    {
        List<SmallTableModel> smallTableModels = new List<SmallTableModel>();
        var fields = typeof(E).GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Static
        );

        foreach (FieldInfo field in fields)
            smallTableModels.Add(new SmallTableModel(field, data));

        return smallTableModels;
    }
}
