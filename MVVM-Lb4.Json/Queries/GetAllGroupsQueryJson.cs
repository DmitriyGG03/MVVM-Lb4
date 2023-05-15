using System.Text.RegularExpressions;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;
using Group = MVVM_Lb4.Domain.Models.Group;

namespace MVVM_Lb4.EF.Queries;

public class GetAllGroupsQueryJson : IGetCollectionQuery<Group>
{
    public async Task<List<Group>> Execute(object? param = null)
    {
        string? json = File.ReadAllText("groups.json");
        if (json is null)
        {
            return new List<Group>();
        }
        return JsonConvert.DeserializeObject<List<Group>>(json);
    }
}