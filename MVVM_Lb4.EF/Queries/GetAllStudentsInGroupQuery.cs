using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Queries;

public class GetAllStudentsInGroupQuery : IGetCollectionQuery<Student>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public GetAllStudentsInGroupQuery(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Student>> Execute(object? param = null)
    {
        if (param is Group)
        {
            using (ApplicationDbContext context = _contextFactory.Create())
            {
                return await context.Students.Where(s => s.Group.Equals(param as Group)).ToListAsync();
            }
        }

        throw new ArgumentException("Invalid argument type");
    }
}