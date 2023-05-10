using System.Linq;
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
/// Create dialog window for creating Group and computing response.
/// If data has been entered success, execute AddGroupToDb method in the store
/// </summary>
public class AddGroupCommand : AsyncCommandBase
{
    private readonly GroupsStore _store;
    private readonly GroupsViewModel _groupsViewModel;
    
    public AddGroupCommand(
        GroupsStore grStore, 
        GroupsViewModel groupsViewModel)
    {
        _store = grStore;
        _groupsViewModel = groupsViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        AddGroupWindow addGroupWindow = new AddGroupWindow(_groupsViewModel);
            
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            if (!ValidateStringSyntaxEnteredData(_groupsViewModel.EnteredGroupName, "Group name")) return;

            if (_store.GroupsView.Any(g => g.GroupName.Equals(_groupsViewModel.EnteredGroupName)))
            {
                MessageBox.Show("A group with the same name already exists!");
            }
            else
            {
                await _store.AddGroupToDb(new Group(_groupsViewModel.EnteredGroupName));

                MessageBox.Show($"A group called {_groupsViewModel.EnteredGroupName} has been successfully created");
            }
        }
        else
        {
            MessageBox.Show("You must enter data in order to create a new group!");
        }
    }
}