using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.DeleteCommands;

public class DeleteStudentCommandJson : IDeleteCommand<Student>
{
    public async Task Execute(Guid id)
    {
        var json = File.ReadAllText("students.json");
        var students = JsonConvert.DeserializeObject<List<Student>>(json);
        var studentForDeleting = students.FirstOrDefault(g => g.StudentId.Equals(id));

        if (studentForDeleting is null) throw new DataException();
        
        students.Remove(studentForDeleting);
        
        File.WriteAllText("students.json", JsonConvert.SerializeObject(students));
    }
}