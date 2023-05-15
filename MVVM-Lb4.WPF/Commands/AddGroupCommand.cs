using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
    private readonly GroupsStoreController _store;
    private readonly GroupsListingViewModel _groupsListingViewModel;

    public AddGroupCommand(
        GroupsStoreController grStore,
        GroupsListingViewModel groupsListingViewModel)
    {
        _store = grStore;
        _groupsListingViewModel = groupsListingViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _groupsListingViewModel.EnteredGroupName = null;
        AddGroupWindow addGroupWindow = new AddGroupWindow(_groupsListingViewModel, "Creating a new group");
            
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            if (!ValidateStringSyntaxEnteredData(_groupsListingViewModel.EnteredGroupName, "Group name")) return;

            if (_groupsListingViewModel.GroupsView.Any(g => g.GroupName.Equals(_groupsListingViewModel.EnteredGroupName)))
            {
                MessageBox.Show("A group with the same name already exists!", "Group name error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                await _store.AddGroupToDb(new Group(_groupsListingViewModel.EnteredGroupName));
                _groupsListingViewModel.LoadGroups();

                MessageBox.Show($"A group called {_groupsListingViewModel.EnteredGroupName} has been successfully created", "Success action", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}