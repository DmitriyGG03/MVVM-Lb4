using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.DeleteCommands;

public class DeleteStudentCommandJson : JsonCommandBase, IDeleteCommand<Student>
{
    /// <summary>
    /// Only general logic implemented, must be changed
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="DataException"></exception>
    public async Task Execute(Guid id)
    {
        //Impossible situation, according to app logic
        if (!File.Exists(StudentFileName)) throw new DataException("Students file does not exist");
        
        var json = await File.ReadAllTextAsync(StudentFileName);
        
        //Impossible situation, according to app logic
        if (string.IsNullOrWhiteSpace(json)) throw new DataException("Students file is empty");
        
        var students = JsonConvert.DeserializeObject<List<Student>>(json)!;
        var studentForDeleting = students.FirstOrDefault(s => s.StudentId.Equals(id));

        //Impossible situation, according to app logic
        if (studentForDeleting is null) throw new DataException("Students with received Id does not exist");
        
        students?.Remove(studentForDeleting);
        
        await File.WriteAllTextAsync(StudentFileName, JsonConvert.SerializeObject(students));
    }
}