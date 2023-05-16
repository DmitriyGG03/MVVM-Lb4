using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.AddCommands;

public class AddGroupCommandJson : JsonCommandBase, IAddCommand<Group>
{
    public async Task Execute(Group group)
    {
        await CreateFilesIfNotExistsAsync();
        
        var json = await File.ReadAllTextAsync(GroupFileName);
        
        List<Group> groups = JsonConvert.DeserializeObject<List<Group>>(json)!;
        
        //If GroupId have only zeros create new guid
        if (group.GroupId.Equals(Guid.Empty))
        {
            group.GroupId = Guid.NewGuid();
        }
        
        groups?.Add(group);
        await File.WriteAllTextAsync(GroupFileName, JsonConvert.SerializeObject(groups));
    }
}