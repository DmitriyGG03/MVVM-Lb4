using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels;

public class GroupsStudentsViewModel : ViewModel
{
    #region Params

    private GroupsStore GroupsStore { get; }

    public List<Student> StudentsOfSelectedGroup
    {
        get => GroupsStore.StudentsView;
        set => GroupsStore.StudentsView = value;
    }

    public bool GroupIsSelected => GroupsStore.StudentsView is not null; //Delete if not use

    public string? SelectedGroupFullName
    {
        get => GroupsStore.SelectedGroup?.GroupName;
    }

    #endregion Params

    public GroupsStudentsViewModel(GroupsStore groupsStore)
    {
        GroupsStore = groupsStore;
    }
}