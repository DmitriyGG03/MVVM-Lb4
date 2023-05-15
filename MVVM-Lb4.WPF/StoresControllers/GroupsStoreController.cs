using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.Stores;

public class GroupsStoreController
{
    #region DatabaseInteractions

    private IGetCollectionQuery<Group> _getGroupsCollection;
    private IGetCollectionQuery<Student> _getStudentsCollection;

    private readonly IAddCommand<Group> _addGroupCommand;
    private readonly IAddCommand<Student> _addStudentCommand;
    private readonly IDeleteCommand<Group> _deleteGroupCommand;
    private readonly IDeleteCommand<Student> _deleteStudentCommand;

    #region Commands

    private ICommand LoadStudentsCommand { get; }

    #endregion Commands

    #endregion DatabaseInteractions

    // #region Events
    //
    // public event Action GroupsLoaded;
    // public event Action StudentsLoaded;
    // public event Action<Group> GroupAddedToDb;
    // public event Action<Student> StudentAddedToDb;
    // public event Action<Group> YouTubeViewerUpdated;
    // public event Action<Guid> YouTubeViewerDeleted;
    //
    // #endregion

    


    /// <summary>
    /// Instantiate values and load data from db
    /// </summary>
    /// <param name="getGroupsCollection">Request to db from host</param>
    /// <param name="getStudentsCollection">Request to db from host</param>
    public GroupsStoreController(
        IGetCollectionQuery<Group> getGroupsCollection,
        IGetCollectionQuery<Student> getStudentsCollection,
        IAddCommand<Group> addGroupCommand,
        IAddCommand<Student> addStudentCommand,
        IDeleteCommand<Group> deleteGroupCommand,
        IDeleteCommand<Student> deleteStudentCommand
    )
    {
        _getGroupsCollection = getGroupsCollection;
        _getStudentsCollection = getStudentsCollection;

        _addGroupCommand = addGroupCommand;
        _addStudentCommand = addStudentCommand;
        _deleteGroupCommand = deleteGroupCommand;
        _deleteStudentCommand = deleteStudentCommand;

        //_groupsViewModel = groupsViewModel;
    }

    public async Task<List<Group>> LoadGroups()
    {
        return await _getGroupsCollection.Execute(); /* TestGroupGeneration();*/
    }

    public async Task<List<Student>> LoadStudents(Group? selectedGroup)
    {
        if (selectedGroup is null) return new List<Student>(0);

        return await _getStudentsCollection.Execute(selectedGroup);
    }

    public async Task AddGroupToDb(Group addingGroup)
    {
        await _addGroupCommand.Execute(addingGroup);
    }

    public async Task AddStudentToDb(Student addingStudent)
    {
        await _addStudentCommand.Execute(addingStudent);
    }
    
    public async Task DeleteGroupFromDb(Guid id)
    {
        await _deleteGroupCommand.Execute(id);
    }
    public async Task EditGroupDb(Group addingGroup)
    {
        await _addGroupCommand.Execute(addingGroup);
    }


    // public async Task Update(Group youTubeViewer)
    // {
    //     await _updateYouTubeViewerCommand.Execute(youTubeViewer);
    //
    //     int currentIndex = _youTubeViewers.FindIndex(y => y.Id == youTubeViewer.Id);
    //
    //     if (currentIndex != -1)
    //     {
    //         _youTubeViewers[currentIndex] = youTubeViewer;
    //     }
    //     else
    //     {
    //         _youTubeViewers.Add(youTubeViewer);
    //     }
    //
    //     YouTubeViewerUpdated?.Invoke(youTubeViewer);
    // }
    //
    // public async Task Delete(Guid id)
    // {
    //     await _deleteYouTubeViewerCommand.Execute(id);
    //
    //     _youTubeViewers.RemoveAll(y => y.Id == id);
    //
    //     YouTubeViewerDeleted?.Invoke(id);
    // }
}