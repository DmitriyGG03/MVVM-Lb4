using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.DTOs;

public class StudentDto
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public byte CourseNumber { get; set; }

    public int GroupId { get; private set; }
    public Group? Group { get; private set; }
}