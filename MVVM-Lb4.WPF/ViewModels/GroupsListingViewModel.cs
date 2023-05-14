using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Specialized;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Stores;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels
{
    public class GroupsListingViewModel : ViewModel
    {
        private List<Group> _groupsView =
            new List<Group>();

        public List<Group> GroupsView
        {
            get => _groupsView;
            set => Set(ref _groupsView, value);
        }

        private GroupsStoreController _groupsStore { get; }
        private GroupsViewModel _groupsViewModel { get; }

        public Group? SelectedGroup
        {
            set
            {
                _groupsStore.SelectedGroup = value;
                _groupsViewModel.GroupsStudentsViewModel.GetStudentsList();

                if (value is not null)
                    _groupsViewModel.GroupIsSelected = true;
                
                else _groupsViewModel.GroupIsSelected = false;
            }
        }

        public ICommand DeleteGroupCommand { get; }
        public ICommand EditGroupCommand { get; }

        public GroupsListingViewModel(GroupsViewModel groupsViewModel, GroupsStoreController groupsStore)
        {
            _groupsStore = groupsStore;
            _groupsViewModel = groupsViewModel;

            LoadGroups();

            DeleteGroupCommand = new DeleteGroupCommand();
            EditGroupCommand = new EditGroupCommand();
        }

        public async void LoadGroups()
        {
            GroupsView = await _groupsStore.LoadGroups();
        }
    }
}