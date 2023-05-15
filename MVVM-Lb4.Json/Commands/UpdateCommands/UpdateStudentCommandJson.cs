using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.UpdateCommands;

public class UpdateStudentCommandJson : IUpdateCommand<Student>
{
    public async Task Execute(Student student)
    {
        var json = File.ReadAllText("students.json");
        var students = JsonConvert.DeserializeObject<List<Student>>(json);
        var studentForUpdating = students.FirstOrDefault(s => s.StudentId.Equals(student.StudentId));

        if (studentForUpdating is null) throw new DataException();

        studentForUpdating = student;
        
        File.WriteAllText("students.json", JsonConvert.SerializeObject(students));
    }
}