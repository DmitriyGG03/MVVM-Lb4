using System;

namespace MVVM_Lb4.UIModels;

public class UIStudent
{
    public Guid StudentId { get; set; }
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public byte CourseNumber { get; set; }
}