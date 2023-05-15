using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels;

public class GroupsViewModel : ViewModel
{
    public GroupsListingViewModel GroupsListingViewModel { get; }
    public GroupsStudentsViewModel GroupsStudentsViewModel { get; }
    

    public GroupsViewModel(GroupsStoreController groupsStore)
    {
        GroupsListingViewModel = new GroupsListingViewModel(this, groupsStore);
        GroupsStudentsViewModel = new GroupsStudentsViewModel(this, groupsStore);
    }
}