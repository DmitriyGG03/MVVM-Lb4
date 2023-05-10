using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.AddCommands;

public class AddStudentDbCommand : IAddCommand<Student>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public AddStudentDbCommand(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Student student)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            context.Students.Add(new StudentDbSaveObject()
            {
                StudentId = student.StudentId,
                Name = student.Name,
                LastName = student.LastName,
                Patronymic = student.Patronymic,
                CourseNumber = student.CourseNumber,
                Group = student.Group
            });
            
            await context.SaveChangesAsync();
        }
    }
}