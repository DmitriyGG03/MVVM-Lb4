using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.StoresControllers;

public class GroupsStoreController
{
    #region DatabaseInteractions

    private IGetCollectionQuery<Group> _getGroupsCollection;
    private IGetCollectionQuery<Student> _getStudentsCollection;

    private readonly IAddCommand<Group> _addGroupCommand;
    private readonly IAddCommand<Student> _addStudentCommand;
    private readonly IDeleteCommand<Group> _deleteGroupCommand;
    private readonly IUpdateCommand<Group> _updateGroupCommand;

    #endregion DatabaseInteractions

    public GroupsStoreController(
        IGetCollectionQuery<Group> getGroupsCollection,
        IGetCollectionQuery<Student> getStudentsCollection,
        IAddCommand<Group> addGroupCommand,
        IAddCommand<Student> addStudentCommand,
        IDeleteCommand<Group> deleteGroupCommand,
        IUpdateCommand<Group> updateGroupCommand
    )
    {
        _getGroupsCollection = getGroupsCollection;
        _getStudentsCollection = getStudentsCollection;

        _addGroupCommand = addGroupCommand;
        _addStudentCommand = addStudentCommand;
        _deleteGroupCommand = deleteGroupCommand;
        _updateGroupCommand = updateGroupCommand;
    }

    public async Task<List<Group>> LoadGroupsAsync()
    {
        return await _getGroupsCollection.Execute(); 
    }

    public async Task<List<Student>> LoadStudentsAsync(Group? selectedGroup)
    {
        if (selectedGroup is null) return new List<Student>(0);

        return await _getStudentsCollection.Execute(selectedGroup);
    }

    public async Task AddGroupToDbAsync(Group addingGroup)
    {
        await _addGroupCommand.Execute(addingGroup);
    }

    public async Task AddStudentToDbAsync(Student addingStudent)
    {
        await _addStudentCommand.Execute(addingStudent);
    }
    
    public async Task DeleteGroupFromDbAsync(Guid id)
    {
        await _deleteGroupCommand.Execute(id);
    }
    public async Task EditGroupDb(Group group)
    {
        await _updateGroupCommand.Execute(group);
    }
}