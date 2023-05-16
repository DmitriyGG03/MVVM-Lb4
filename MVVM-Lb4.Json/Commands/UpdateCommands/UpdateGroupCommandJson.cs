using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Json.Commands.Abstract;
using Newtonsoft.Json;

namespace MVVM_Lb4.Json.Commands.UpdateCommands;

public class UpdateGroupCommandJson : JsonCommandBase, IUpdateCommand<Group>
{
    public async Task Execute(Group group)
    {
        //Impossible situation, according to app logic
        if (!File.Exists(GroupFileName)) throw new DataException("Groups file does not exist");

        var json = await File.ReadAllTextAsync(GroupFileName);

        //Impossible situation, according to app logic
        if (string.IsNullOrWhiteSpace(json)) throw new DataException("Groups file is empty");

        var groups = JsonConvert.DeserializeObject<List<Group>>(json);
        Group updatingGroup = groups?.FirstOrDefault(g => g.GroupId.Equals(group.GroupId))!;

        //Impossible situation, according to app logic
        if (updatingGroup is default(Group)) throw new DataException("Group with received Id does not exist");

        groups![groups.IndexOf(updatingGroup)] = group; //TODO: Need review

        await File.WriteAllTextAsync(GroupFileName, JsonConvert.SerializeObject(groups));
    }
}