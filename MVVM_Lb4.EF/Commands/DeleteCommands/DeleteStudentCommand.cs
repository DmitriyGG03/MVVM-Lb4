using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.DeleteCommands;

public class DeleteStudentCommand : IDeleteCommand<Guid>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public DeleteStudentCommand(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Guid id)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            StudentDbSaveObject? student = context.Students.FirstOrDefault(i => i.StudentId.Equals(id));
            
            if (student is null)
                throw new DataException("Student was not found");
            
            context.Students.Remove(new StudentDbSaveObject()
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