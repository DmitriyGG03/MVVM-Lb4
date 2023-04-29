using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.EF.Commands;

public class CreateGroupCommand : ICreateCommand<Group>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public CreateGroupCommand(ApplicationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Group group)
    {
        using (ApplicationDbContext context = _contextFactory.Create())
        {
            context.Groups.Add(group);
            await context.SaveChangesAsync();
        }
    }
}