using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.StoresControllers;
using MVVM_Lb4.UIModels.Abstract;
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
        _groupsListingViewModel.UiGroup.GroupName = _groupsListingViewModel.SelectedGroup?.GroupName ?? 
                                                    throw new DataException();
        AddGroupWindow addGroupWindow = new AddGroupWindow(_groupsListingViewModel, "Editing the group");
            
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            UIValidator uiValidator = new UIValidator();
            if (!await uiValidator.IsValidateGroupUIParamsSuccessAsync(_groupsListingViewModel.UiGroup)) return;

            if (_groupsListingViewModel.UiGroup.GroupName.Equals(_groupsListingViewModel.SelectedGroup.GroupName))
            {
                MessageBox.Show("The group name has not changed", "Warning", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (_groupsListingViewModel.GroupsView.Any(g => g.GroupName.Equals(_groupsListingViewModel.UiGroup.GroupName)))
            {
                MessageBox.Show("A group with the same name already exists!", "Group name error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Group group = _groupsListingViewModel.SelectedGroup;

                group.GroupName = _groupsListingViewModel.UiGroup.GroupName;
                
                await _store.EditGroupDb(group);
                _groupsListingViewModel.LoadGroups();
                _groupsListingViewModel.SelectedGroup = null;

                MessageBox.Show($"A group called {_groupsListingViewModel.UiGroup.GroupName} has been successfully changed", "Success action", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}