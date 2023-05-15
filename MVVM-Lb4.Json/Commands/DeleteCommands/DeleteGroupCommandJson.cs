using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.DeleteCommands;

public class DeleteGroupCommandJson : IDeleteCommand<Group>
{
    public async Task Execute(Guid id)
    {
        var json = File.ReadAllText("groups.json");
        var groups = JsonConvert.DeserializeObject<List<Group>>(json);
        var groupForDeleting = groups.FirstOrDefault(g => g.GroupId.Equals(id));

        if (groupForDeleting is null) throw new DataException();
        
        groups.Remove(groupForDeleting);
        
        File.WriteAllText("groups.json", JsonConvert.SerializeObject(groups));
    }
}