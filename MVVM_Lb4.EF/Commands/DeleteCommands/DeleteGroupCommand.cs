using System.Data;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Domain.Models.Base;
using MVVM_Lb4.EF.DTOs;

namespace MVVM_Lb4.EF.Commands.DeleteCommands;

public class DeleteGroupCommand : IDeleteCommand<Group> 
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
            Group? group = context.Groups.FirstOrDefault(i => i.GroupId.Equals(id));

            if (group is null)
                throw new DataException("Group was not found");

            context.Students.Where(s => s.Group.Equals(group)).
                Select(s => context.Students.Remove(s));
            context.Groups.Remove(group);
            await context.SaveChangesAsync();
        }
    }
}