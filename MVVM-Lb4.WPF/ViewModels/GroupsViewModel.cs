using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels.Base;
using MVVM_Lb4.Views.DialogWindows;
using YouTubeViewers.WPF.Commands;

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