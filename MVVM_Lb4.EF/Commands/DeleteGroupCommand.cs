using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.Commands;

public class DeleteGroupCommand : IDeleteCommand<Guid>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public DeleteGroupCommand(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Guid id)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            Group group = context.Groups.FirstOrDefault(i => i.GroupId.Equals(id));
            
            context.Groups.Remove(group);
            await context.SaveChangesAsync();
        }
    }
}