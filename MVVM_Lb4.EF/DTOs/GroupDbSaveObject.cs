using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.DTOs;

[Serializable]
[PrimaryKey("GroupId")]
public class GroupDbSaveObject
{
    public Guid GroupId { get; set; }

    public string GroupName { get; set; }

    public IList<Student>? Students { get; set; }
}