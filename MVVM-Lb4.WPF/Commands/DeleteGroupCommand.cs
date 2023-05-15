using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels;
using MVVM_Lb4.Views.DialogWindows;

namespace MVVM_Lb4.Commands;

public class DeleteGroupCommand : AsyncCommandBase
{
    private readonly GroupsStoreController _store;
    private readonly GroupsListingViewModel _groupsListingViewModel;

    public DeleteGroupCommand(
        GroupsStoreController grStore,
        GroupsListingViewModel groupsListingViewModel)
    {
        _store = grStore;
        _groupsListingViewModel = groupsListingViewModel;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        ConfirmOperationWindow addGroupWindow = new ConfirmOperationWindow("delete selected group");

        if ((bool)addGroupWindow.ShowDialog()!)
        {
            await _store.DeleteGroupFromDb(_groupsListingViewModel.SelectedGroup.GroupId);

            MessageBox.Show($"A group called {_groupsListingViewModel.EnteredGroupName} has been successfully deleted",
                "Success action",
                MessageBoxButton.OK, MessageBoxImage.Information);
            
            _groupsListingViewModel.LoadGroups();
        }
    }
}