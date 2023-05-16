using System.Collections.Generic;
using System.Windows.Input;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels;

public class GroupsStudentsViewModel : ViewModel
{
    #region Params

    #region StudentsViewList

    private List<Student> _studentsView;

    public List<Student> StudentsView
    {
        get => _studentsView;
        set => Set(ref _studentsView, value);
    }

    #endregion

    #region AddStudent

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

    private bool _groupIsSelected = false;

    public bool GroupIsSelected
    {
        get => _groupIsSelected;
        set => Set(ref _groupIsSelected, value);
    }

    public string? SelectedGroupName
    {
        get => GroupsViewModel.GroupsListingViewModel.SelectedGroup?.GroupName ?? null;
    }

    public GroupsStoreController GroupsStore { get; }
    public GroupsViewModel GroupsViewModel { get; }


    #region Commands

    public ICommand AddStudentCommand { get; }

    #endregion

    #endregion Params

    public GroupsStudentsViewModel(GroupsViewModel groupsViewModel, GroupsStoreController groupsStore)
    {
        GroupsViewModel = groupsViewModel;
        GroupsStore = groupsStore;

        AddStudentCommand = new AddStudentCommand(groupsStore, this);
    }

    public async void GetStudentsList()
    {
        StudentsView = await GroupsStore.LoadStudents(GroupsViewModel.GroupsListingViewModel.SelectedGroup);
    }
}