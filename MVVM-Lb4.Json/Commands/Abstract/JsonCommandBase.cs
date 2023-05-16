using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Domain.Models.Base;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.Abstract;

public abstract class JsonCommandBase
{
    protected const string StudentFileName = @"students.json";
    protected const string GroupFileName = @"groups.json";

    protected async Task CreateFilesIfNotExistsAsync()
    {
        if (!File.Exists(GroupFileName))
        {
            await File.WriteAllTextAsync(GroupFileName, JsonConvert.SerializeObject(new List<Group>(0)));
        }

        if (!File.Exists(StudentFileName))
        {
            await File.WriteAllTextAsync(StudentFileName, JsonConvert.SerializeObject(new List<Student>(0)));
        }
    }
}