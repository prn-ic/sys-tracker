using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SysTracker.Core.Entities;
using SysTracker.Desktop.Services.InfoViewer.Models;

namespace SysTracker.Desktop.Services.InfoViewer;
public class SmallTableViewer : IInfoViewer<List<SmallTableModel>>
{
    public List<SmallTableModel> View<E>(E data) where E : EntityBase
    {
        List<SmallTableModel> smallTableModels = new List<SmallTableModel>();
        var parentFields = data.GetType().BaseType!.GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding
        );

        var childFields = typeof(E).GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding
        );

        var fields = parentFields.Concat(childFields).ToArray();

        foreach (FieldInfo field in fields)
            smallTableModels.Add(new SmallTableModel(field, data));

        return smallTableModels;
    }
}
