using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.AddCommands;

public class AddStudentCommandJson : JsonCommandBase, IAddCommand<Student>
{
    public async Task Execute(Student student)
    {
        await CreateFilesIfNotExistsAsync();
        
        var json = await File.ReadAllTextAsync(StudentFileName);
        
        List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json)!;
        
        //If StudentId have only zeros create new guid
        if (student.StudentId.Equals(Guid.Empty))
        {
            student.StudentId = Guid.NewGuid();
        }
        
        students.Add(student);
        
        await File.WriteAllTextAsync(StudentFileName, JsonConvert.SerializeObject(students));
    }
}