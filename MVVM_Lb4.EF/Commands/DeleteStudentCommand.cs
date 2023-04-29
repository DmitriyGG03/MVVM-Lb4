using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.Commands;

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
            Student student = context.Students.FirstOrDefault(i => i.StudentId.Equals(id));
            
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }
    }
}