using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.DeleteCommands;

public class DeleteStudentCommand : IDeleteCommand<Student>
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
            Student? student = context.Students.FirstOrDefault(i => i.StudentId.Equals(id));
            
            if (student is null)
                throw new DataException("Student was not found");
            
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }
    }
}