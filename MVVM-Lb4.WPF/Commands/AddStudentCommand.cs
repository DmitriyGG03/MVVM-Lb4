using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.StoresControllers;
using MVVM_Lb4.UIModels;
using MVVM_Lb4.UIModels.Abstract;
using MVVM_Lb4.ViewModels;
using MVVM_Lb4.Views.DialogWindows;

namespace MVVM_Lb4.Commands;

/// <summary>
/// Create dialog window for creating Student and computing response.
/// If data has been entered success, execute AddGroupToDb method in the store
/// </summary>
public class AddStudentCommand : AsyncCommandBase
{
    private readonly GroupsStoreController _store;
    private readonly GroupsStudentsViewModel _groupsStudentsViewModel;

    public AddStudentCommand(
        GroupsStoreController grStore,
        GroupsStudentsViewModel groupsStudentsViewModel)
    {
        _store = grStore;
        _groupsStudentsViewModel = groupsStudentsViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _groupsStudentsViewModel.UiStudent = new UIStudent();
        AddStudentWindow addGroupWindow = new AddStudentWindow(_groupsStudentsViewModel);

        if ((bool)addGroupWindow.ShowDialog()!)
        {
            UIValidator uiValidator = new UIValidator();
            if (!await uiValidator.IsValidateStudentUIParamsSuccessAsync(_groupsStudentsViewModel.UiStudent)) return;

            await _store.AddStudentToDbAsync(new Student(
                _groupsStudentsViewModel.UiStudent.Name,
                _groupsStudentsViewModel.UiStudent.LastName,
                _groupsStudentsViewModel.UiStudent.Patronymic,
                _groupsStudentsViewModel.UiStudent.CourseNumber)
            {
                GroupId = _groupsStudentsViewModel.GroupsViewModel.GroupsListingViewModel.SelectedGroup!.GroupId,
                Group = _groupsStudentsViewModel.GroupsViewModel.GroupsListingViewModel.SelectedGroup
            });
            _groupsStudentsViewModel.GetStudentsList();

            MessageBox.Show($"A student called {_groupsStudentsViewModel.UiStudent.Name} has been successfully created",
                "Success action", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}