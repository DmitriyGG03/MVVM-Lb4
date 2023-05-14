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
    private readonly GroupsViewModel _groupsViewModel;
    
    public AddStudentCommand(
        GroupsStoreController grStore,  
        GroupsViewModel groupsViewModel)
    {
        _store = grStore;
        _groupsViewModel = groupsViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        AddStudentWindow addGroupWindow = new AddStudentWindow(_groupsViewModel);
        
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            //TODO: It is good to review code below
            if (!ValidateStringSyntaxEnteredData(_groupsViewModel.EnteredStudentName, "Student name")) return;
            if (!ValidateStringSyntaxEnteredData(_groupsViewModel.EnteredStudentSurname, "Student surname")) return;
            if (!ValidateStringSyntaxEnteredData(_groupsViewModel.EnteredStudentPatronymic, "Student patronymic")) return;

            await _store.AddStudentToDb(new Student(
                _groupsViewModel.EnteredStudentName,
                _groupsViewModel.EnteredStudentSurname,
                _groupsViewModel.EnteredStudentPatronymic,
                byte.Parse(_groupsViewModel.EnteredStudentCourse)) {GroupId = _store.SelectedGroup!.GroupId});

            MessageBox.Show($"A student called {_groupsViewModel.EnteredStudentName} has been successfully created", "Success action", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("You must enter data in order to create a new student!", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}