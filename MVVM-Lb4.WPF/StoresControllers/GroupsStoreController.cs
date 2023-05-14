using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.AbstractCommands;
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Domain.Models.Base;
using MVVM_Lb4.EF;
using MVVM_Lb4.EF.Commands.AddCommands;
using MVVM_Lb4.Stores.Base;
using MVVM_Lb4.ViewModels;
using YouTubeViewers.WPF.Commands;

namespace MVVM_Lb4.Stores;

public class GroupsStoreController : StoreControllerBase
{
    #region DatabaseInteractions

    private IGetCollectionQuery<Group> _getGroupsCollection;
    private IGetCollectionQuery<Student> _getStudentsCollection;

    private readonly IAddCommand<Group> _addGroupCommand;
    private readonly IAddCommand<Student> _addStudentCommand;
    private readonly IAddCommand<Group> _deleteGroupCommand;
    private readonly IAddCommand<Student> _deleteStudentCommand;

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

    #region SelectedItems

    private Group? _selectedGroup = null;

    public Group? SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            Set(ref _selectedGroup, value);
            LoadStudentsCommand.Execute(null);
        }
    }

    #endregion


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
        IAddCommand<Group> deleteGroupCommand,
        IAddCommand<Student> deleteStudentCommand
    )
    {
        _getGroupsCollection = getGroupsCollection;
        _getStudentsCollection = getStudentsCollection;

        LoadStudentsCommand = new LoadStudentsCommand(this);

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

    public async Task<List<Student>> LoadStudents()
    {
        if (SelectedGroup is null) return new List<Student>(0);

        return await _getStudentsCollection.Execute(SelectedGroup);
    }

    public async Task AddGroupToDb(Group addingGroup)
    {
        await _addGroupCommand.Execute(addingGroup);

        //await Task.Run(() => GroupsView.Add(addingGroup));
    }

    public async Task AddStudentToDb(Student addingStudent)
    {
        await _addStudentCommand.Execute(addingStudent);
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

    private List<Group> TestGroupGeneration()
    {
        List<Group> groups = Enumerable.Range(1, 10).Select(i =>
            new Group() { GroupName = $"Group {i++}" }).ToList();

        //ObservableCollection<Group> obGroup = new ObservableCollection<Group>(groups);
        var studentNumber = 1;

        //IList<Student> students = Enumerable.Range(0, 9).Select(i => new Student()
        //{
        //    Name = $"Student name {studentNumber}",
        //    LastName = $"Student last name {studentNumber}",
        //    Patronymic = $"Student patronymic {studentNumber++}",
        //    CourseNumber = 1,
        //    Group = groups[i]
        //}).ToList();

        return groups;
    }
}