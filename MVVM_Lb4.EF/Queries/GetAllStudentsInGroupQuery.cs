using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.Queries;

public class GetAllStudentsInGroupQuery : IGetCollectionQuery<Student>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public GetAllStudentsInGroupQuery(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Student>> Execute()
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            return await context.Students.ToListAsync();
        }
    }
}