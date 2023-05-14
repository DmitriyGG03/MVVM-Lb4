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

    private List<Student> _studentsView;
    public List<Student> StudentsView
    {
        get => _studentsView;
        set => Set(ref _studentsView, value);
    }

    private GroupsStoreController _groupsStore { get; }

    #endregion Params

    public GroupsStudentsViewModel(GroupsStoreController groupsStore)
    {
        _groupsStore = groupsStore;
    }

    public async void GetStudentsList()
    {
        StudentsView = await _groupsStore.LoadStudents();
    }
}