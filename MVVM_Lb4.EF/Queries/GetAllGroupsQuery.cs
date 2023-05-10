using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Queries;

public class GetAllGroupsQuery : IGetCollectionQuery<Group>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public GetAllGroupsQuery(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Group>> Execute(object? param = null)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            IList<GroupDbSaveObject> groups = context.Groups.ToList();
            
            return groups.Select(g => new Group()
            {
                GroupId = g.GroupId,
                GroupName = g.GroupName,
                Students = null
            }).ToList();
        }
    }
}