using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
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
        AddStudentWindow addGroupWindow = new AddStudentWindow(_groupsStudentsViewModel);
        
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            //TODO: It is good to review code below
            if (!ValidateStringSyntaxEnteredData(_groupsStudentsViewModel.EnteredStudentName, "Student name")) return;
            if (!ValidateStringSyntaxEnteredData(_groupsStudentsViewModel.EnteredStudentSurname, "Student surname")) return;
            if (!ValidateStringSyntaxEnteredData(_groupsStudentsViewModel.EnteredStudentPatronymic, "Student patronymic")) return;

            await _store.AddStudentToDb(new Student(
                _groupsStudentsViewModel.EnteredStudentName,
                _groupsStudentsViewModel.EnteredStudentSurname,
                _groupsStudentsViewModel.EnteredStudentPatronymic,
                byte.Parse(_groupsStudentsViewModel.EnteredStudentCourse))
            {
                GroupId = _groupsStudentsViewModel.GroupsViewModel.GroupsListingViewModel.SelectedGroup!.GroupId
            });
            _groupsStudentsViewModel.GetStudentsList();

            MessageBox.Show($"A student called {_groupsStudentsViewModel.EnteredStudentName} has been successfully created", "Success action", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("You must enter data in order to create a new student!", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}