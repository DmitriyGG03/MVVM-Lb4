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
                IList<StudentDbSaveObject> groups = 
                    await context.Students.Where(s => s.Group.Equals(param as Group)).ToListAsync();
            
                return groups.Select(s => new Student()
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    LastName = s.LastName,
                    Patronymic = s.Patronymic,
                    CourseNumber = s.CourseNumber,
                    Group = s.Group
                }).ToList();
            }
        }

        throw new ArgumentException("Invalid argument type");
    }
}