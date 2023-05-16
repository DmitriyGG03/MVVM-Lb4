using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb4.EF.Queries;

public class GetAllStudentsInGroupQueryJson : JsonCommandBase, IGetCollectionQuery<Student>
{
    public async Task<List<Student>> Execute(object? param = null)
    {
        await CreateFilesIfNotExistsAsync();

        if (param is null || param is not Group) throw new ArgumentException("Invalid argument type");
        
        Group receivedGroup = param as Group;

        string? json = await File.ReadAllTextAsync(StudentFileName);

        return JsonConvert.DeserializeObject<List<Student>>(json)!
            .Where(s => s.GroupId.Equals(receivedGroup!.GroupId)).ToList();
    }
}