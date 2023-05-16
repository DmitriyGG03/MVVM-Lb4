using System.Collections.Generic;
using System.Windows.Input;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.StoresControllers;
using MVVM_Lb4.UIModels;
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

    #region UiStudentEnteringData

    private UIStudent _uiStudent = new();

    public UIStudent UiStudent
    {
        get => _uiStudent;
        set => Set(ref _uiStudent, value);
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
        StudentsView = await GroupsStore.LoadStudentsAsync(GroupsViewModel.GroupsListingViewModel.SelectedGroup);
    }
}