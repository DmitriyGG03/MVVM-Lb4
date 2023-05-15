using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.UpdateCommands;

public class UpdateGroupCommandJson : IUpdateCommand<Group>
{
    public async Task Execute(Group group)
    {
        var json = File.ReadAllText("groups.json");
        var groups = JsonConvert.DeserializeObject<List<Group>>(json);
        var groupForUpdating = groups.FirstOrDefault(g => g.GroupId.Equals(group.GroupId));

        if (groupForUpdating is null) throw new DataException();

        groupForUpdating = group;
        
        File.WriteAllText("groups.json", JsonConvert.SerializeObject(groups));
    }
}