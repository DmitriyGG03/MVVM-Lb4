using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.UpdateCommands;

public class UpdateStudentCommand : IUpdateCommand<Student>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public UpdateStudentCommand(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Student student)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }
    }
}