using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.DeleteCommands;

public class DeleteGroupCommandJson : JsonCommandBase, IDeleteCommand<Group>
{
    public async Task Execute(Guid id)
    {
        //Impossible situation, according to app logic
        if (!File.Exists(GroupFileName)) throw new DataException("Groups file does not exist");

        var json = await File.ReadAllTextAsync(GroupFileName);

        //Impossible situation, according to app logic
        if (string.IsNullOrWhiteSpace(json)) throw new DataException("Groups file is empty");

        var groups = JsonConvert.DeserializeObject<List<Group>>(json);
        var groupForDeleting = groups?.FirstOrDefault(g => g.GroupId.Equals(id));

        //Impossible situation, according to app logic
        if (groupForDeleting is null) throw new DataException("Group with received Id does not exist");

        await RemoveDependentStudents(id);

        groups?.Remove(groupForDeleting);

        await File.WriteAllTextAsync(GroupFileName, JsonConvert.SerializeObject(groups));
    }

    private async Task RemoveDependentStudents(Guid id)
    {
        //If the file does not exist, than there are no students to delete
        if (!File.Exists(StudentFileName)) return;

        var jsonStudents = await File.ReadAllTextAsync(StudentFileName);

        //If the file is empty, than there are no students to delete
        if (string.IsNullOrWhiteSpace(jsonStudents)) return;

        var students = JsonConvert.DeserializeObject<List<Student>>(jsonStudents);
        
        List<Student> studentsForDeleting = students.Where(s => s.GroupId.Equals(id)).ToList();
        
        foreach (Student st in studentsForDeleting ?? new List<Student>())
        {
            students.Remove(st);
        }

        await File.WriteAllTextAsync(StudentFileName, JsonConvert.SerializeObject(students));
    }
}