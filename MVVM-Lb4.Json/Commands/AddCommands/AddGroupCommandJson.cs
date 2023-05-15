using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.AddCommands;

public class AddGroupCommandJson : IAddCommand<Group>
{
    public async Task Execute(Group group)
    {
        var json = File.ReadAllText("groups.json");
        var groups = JsonConvert.DeserializeObject<List<Group>>(json);
        groups.Add(group);
        File.WriteAllText("groups.json", JsonConvert.SerializeObject(groups));
    }
}