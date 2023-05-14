using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels.Base;
using MVVM_Lb4.Views.DialogWindows;
using YouTubeViewers.WPF.Commands;

namespace MVVM_Lb4.ViewModels;

public class GroupsViewModel : ViewModel
{
    public GroupsListingViewModel GroupsListingViewModel { get; }
    public GroupsStudentsViewModel GroupsStudentsViewModel { get; }

    #region Parameters

    #region AddGroup

    private string _enteredGroupName = "";

    public string EnteredGroupName
    {
        get => _enteredGroupName;
        set => Set(ref _enteredGroupName, value);
    }

    #endregion

    #region AddStudent

    private bool _groupIsSelected = false;

    public bool GroupIsSelected
    {
        get => _groupIsSelected; 
        set => Set(ref _groupIsSelected, value); 
    }


    private string _enteredStudentName = "";
    private string _enteredStudentSurname = "";
    private string _enteredStudentPatronymic = "";
    private string _enteredStudentCourse = "";


    public string EnteredStudentName
    {
        get => _enteredStudentName;
        set => Set(ref _enteredStudentName, value);
    }

    public string EnteredStudentSurname
    {
        get => _enteredStudentSurname;
        set => Set(ref _enteredStudentSurname, value);
    }

    public string EnteredStudentPatronymic
    {
        get => _enteredStudentPatronymic;
        set => Set(ref _enteredStudentPatronymic, value);
    }

    public string EnteredStudentCourse
    {
        get => _enteredStudentCourse;
        set => Set(ref _enteredStudentCourse, value);
    }

    #endregion

    #endregion

    #region Commands

    public ICommand AddGroupCommand { get; }
    public ICommand AddStudentCommand { get; }
    public ICommand LoadGroupsCommand { get; }

    #endregion

    public GroupsViewModel(GroupsStoreController groupsStore)
    {
        LoadGroupsCommand = new LoadGroupsCommand(groupsStore);
        LoadGroupsCommand.Execute(null);

		GroupsListingViewModel = new GroupsListingViewModel(this, groupsStore);
        GroupsStudentsViewModel = new GroupsStudentsViewModel(groupsStore);
        
        

        AddGroupCommand = new AddGroupCommand(groupsStore, this);
        AddStudentCommand = new AddStudentCommand(groupsStore, this);
    }
}