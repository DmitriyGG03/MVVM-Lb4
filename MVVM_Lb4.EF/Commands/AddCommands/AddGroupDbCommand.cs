using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.AddCommands;

public class AddGroupDbCommand : IAddCommand<Group>
{
    private readonly ApplicationDbContextFactory _contextFactory;

    public AddGroupDbCommand(ApplicationDbContextFactory contextFactory)
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