using System.Text.RegularExpressions;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;
using Group = MVVM_Lb4.Domain.Models.Group;

namespace MVVM_Lb4.EF.Queries;

public class GetAllGroupsQueryJson : JsonCommandBase, IGetCollectionQuery<Group>
{
    public async Task<List<Group>> Execute(object? param = null)
    {
        await CreateFilesIfNotExistsAsync();
        
        var json = await File.ReadAllTextAsync(GroupFileName);
        
        return JsonConvert.DeserializeObject<List<Group>>(json)!;
    }
}