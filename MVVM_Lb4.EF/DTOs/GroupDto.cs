using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.DTOs;

public class GroupDto
{
    public int GroupId { get; set; }
    public string GroupFullName { get; set; }
    public ICollection<Student>? Students { get; set; }
}