using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.DeleteCommands;

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
            GroupDbSaveObject? group = context.Groups.FirstOrDefault(i => i.GroupId.Equals(id));

            if (group is null)
                throw new DataException("Group was not found");

            context.Groups.Remove(new GroupDbSaveObject()
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                Students = group.Students
            });
            
            await context.SaveChangesAsync();
        }
    }
}