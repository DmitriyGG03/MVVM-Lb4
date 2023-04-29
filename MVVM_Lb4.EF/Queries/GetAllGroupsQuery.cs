using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.Queries;

public class GetAllGroupsQuery : IGetCollectionQuery<Group>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public GetAllGroupsQuery(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Group>> Execute()
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            return await context.Groups.ToListAsync();
        }
    }
}