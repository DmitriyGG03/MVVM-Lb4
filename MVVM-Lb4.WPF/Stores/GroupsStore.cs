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
using MVVM_Lb4.Domain.AbstractQueries;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Domain.Models.Base;
using MVVM_Lb4.EF;
using MVVM_Lb4.Stores.Base;
using YouTubeViewers.WPF.Commands;

namespace MVVM_Lb4.Stores;

public class GroupsStore : StoreBase
{
    #region DatabaseInteractions

    private IGetCollectionQuery<Group> _getGroupsCollection;
    private IGetCollectionQuery<Student> _getStudentsCollection;

    private ICommand LoadStudentsCommand { get; }

    #endregion

    #region Events

    public event Action GroupsLoaded;
    public event Action StudentsLoaded;
    public event Action<Group> GroupAddedToDb;
    public event Action<Student> StudentAddedToDb;
    public event Action<Group> YouTubeViewerUpdated;
    public event Action<Guid> YouTubeViewerDeleted;

    #endregion

    #region ListViews

    private List<Group> _groupsView =       
        new List<Group>();
    private List<Student> _studentsView =
        new List<Student>();

    public List<Group> GroupsView { get => _groupsView; set => Set(ref _groupsView, value); }
    public List<Student> StudentsView 
    { 
        get => _studentsView;
        set
        {
            Set(ref _studentsView, value);
		}
    }

    #endregion

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
    public GroupsStore(
        IGetCollectionQuery<Group> getGroupsCollection,
        IGetCollectionQuery<Student> getStudentsCollection
    )
    {
        _getGroupsCollection = getGroupsCollection;
        _getStudentsCollection = getStudentsCollection;

        LoadStudentsCommand = new LoadStudentsCommand(this);
    }

    public async Task LoadGroups()
    {
		List<Group> groups = await _getGroupsCollection.Execute(); /* TestGroupGeneration();*/

		GroupsView.Clear();
        GroupsView.AddRange(groups);

        GroupsLoaded?.Invoke();
    }
    
    

    public async Task LoadStudents()
    {
        if (SelectedGroup is null) return;

        List<Student> students = await _getStudentsCollection.Execute(SelectedGroup);

        StudentsView.Clear();
		StudentsView.AddRange(students);

        StudentsLoaded?.Invoke();
    }

    public async Task AddGroupToDb(Group addingGroup)
    {
        await _getGroupsCollection.Execute(addingGroup);

        await Task.Run(() => GroupsView.Add(addingGroup));

        GroupAddedToDb?.Invoke(addingGroup);
    }

    public async Task AddStudentToDb(Student addingStudent)
    {
        await _getStudentsCollection.Execute(addingStudent);

        await Task.Run(() => StudentsView.Add(addingStudent));

        StudentAddedToDb?.Invoke(addingStudent);
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