

using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.Commands;

public class CreateStudentCommand : ICreateCommand<Student>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public CreateStudentCommand(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Student student)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
        }
    }
}