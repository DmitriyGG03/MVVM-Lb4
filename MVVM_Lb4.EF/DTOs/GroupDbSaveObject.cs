using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.DTOs;

[Serializable]
public class GroupDbSaveObject
{
    public Guid GroupId { get; set; }
    
    public string GroupName { get; set; }
    
    [ForeignKey("Students")]
    public IList<Student>? Students { get; set; }
}