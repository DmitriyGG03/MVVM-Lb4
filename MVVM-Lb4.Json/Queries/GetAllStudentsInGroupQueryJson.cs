using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using Newtonsoft.Json;

namespace MVVM_Lb4.EF.Queries;

public class GetAllStudentsInGroupQueryJson : IGetCollectionQuery<Student>
{
    public async Task<List<Student>> Execute(object? param = null)
    {
        if (param is Group)
        {
            string? json = File.ReadAllText("students.json");
            if (json is null)
            {
                return new List<Student>();
            }

            return JsonConvert.DeserializeObject<List<Student>>(json).Where(s => s.Group.Equals(param as Group)).ToList();
        }
        else throw new ArgumentException("Invalid argument type");
    }
}