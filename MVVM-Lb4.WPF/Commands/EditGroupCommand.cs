using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels;
using MVVM_Lb4.Views.DialogWindows;

namespace MVVM_Lb4.Commands;

public class EditGroupCommand : AsyncCommandBase
{
    private readonly GroupsStoreController _store;
    private readonly GroupsListingViewModel _groupsListingViewModel;

    public EditGroupCommand(
        GroupsStoreController grStore,
        GroupsListingViewModel groupsListingViewModel)
    {
        _store = grStore;
        _groupsListingViewModel = groupsListingViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        _groupsListingViewModel.EnteredGroupName = _groupsListingViewModel.SelectedGroup.GroupName;
        AddGroupWindow addGroupWindow = new AddGroupWindow(_groupsListingViewModel, "Editing the group");
            
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            if (!ValidateStringSyntaxEnteredData(_groupsListingViewModel.EnteredGroupName, "Group name")) return;

            if (_groupsListingViewModel.EnteredGroupName.Equals(_groupsListingViewModel.SelectedGroup.GroupName))
            {
                MessageBox.Show("The group name has not changed", "Warning", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (_groupsListingViewModel.GroupsView.Any(g => g.GroupName.Equals(_groupsListingViewModel.EnteredGroupName)))
            {
                MessageBox.Show("A group with the same name already exists!", "Group name error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Group group = _groupsListingViewModel.SelectedGroup;

                group.GroupName = _groupsListingViewModel.EnteredGroupName;
                
                await _store.EditGroupDb(group);
                _groupsListingViewModel.LoadGroups();

                MessageBox.Show($"A group called {_groupsListingViewModel.EnteredGroupName} has been successfully changed", "Success action", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}