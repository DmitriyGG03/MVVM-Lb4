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
        _groupsListingViewModel.UiGroup = new UIGroup();
        AddGroupWindow addGroupWindow = new AddGroupWindow(_groupsListingViewModel, "Creating a new group");
            
        if ((bool)addGroupWindow.ShowDialog()!)
        {
            UIValidator uiValidator = new UIValidator();
            if (!await uiValidator.IsValidateGroupUIParamsSuccessAsync(_groupsListingViewModel.UiGroup)) return;

            if (_groupsListingViewModel.GroupsView.Any(g => g.GroupName.Equals(_groupsListingViewModel.UiGroup.GroupName)))
            {
                MessageBox.Show("A group with the same name already exists!", "Group name error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                await _store.AddGroupToDbAsync(new Group(_groupsListingViewModel.UiGroup.GroupName));
                _groupsListingViewModel.LoadGroups();

                MessageBox.Show($"A group called {_groupsListingViewModel.UiGroup.GroupName} has been successfully created", "Success action", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}