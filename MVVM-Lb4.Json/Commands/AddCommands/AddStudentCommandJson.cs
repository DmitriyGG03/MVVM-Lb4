using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.AddCommands;

public class AddStudentCommandJson : IAddCommand<Student>
{
    public async Task Execute(Student student)
    {
        var json = File.ReadAllText("students.json");
        var students = JsonConvert.DeserializeObject<List<Student>>(json);
        students.Add(student);
        File.WriteAllText("students.json", JsonConvert.SerializeObject(students));
    }
}