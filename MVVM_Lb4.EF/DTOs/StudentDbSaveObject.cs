using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.DTOs;

[Serializable]
public class StudentDbSaveObject
{
    public Guid StudentId { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public byte CourseNumber { get; set; }

    [ForeignKey("Group")]
    public Guid GroupId { get; set; }
    public Group? Group { get; set; }
}