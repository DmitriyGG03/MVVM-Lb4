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
using YouTubeViewers.WPF.Commands;

namespace MVVM_Lb4.ViewModels
{
    public class GroupsListingViewModel : ViewModel
    {
        
        #region ViewGroupList
        
        private List<Group> _groupsView =
            new List<Group>();

        public List<Group> GroupsView
        {
            get => _groupsView;
            set => Set(ref _groupsView, value);
        }
        
        #endregion
        
        #region SelectedGroup

        private Group? _selectedGroup = null;

        public Group? SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                Set(ref _selectedGroup, value);
                _groupsViewModel.GroupsStudentsViewModel.GroupIsSelected = true;
                GroupIsSelected = true;
                _groupsViewModel.GroupsStudentsViewModel.GetStudentsList();
            }
        }
        
        private bool _groupIsSelected = false;
        public bool GroupIsSelected
        {
            get => _groupIsSelected; 
            set => Set(ref _groupIsSelected, value); 
        }

        #endregion
        
        #region AddGroup

        private string _enteredGroupName = "";

        public string EnteredGroupName
        {
            get => _enteredGroupName;
            set => Set(ref _enteredGroupName, value);
        }

        #endregion

        private GroupsStoreController _groupsStore { get; }
        private GroupsViewModel _groupsViewModel { get; }
        
        
        public ICommand AddGroupCommand { get; }
        public ICommand DeleteGroupCommand { get; }
        public ICommand EditGroupCommand { get; }

        public GroupsListingViewModel(GroupsViewModel groupsViewModel, GroupsStoreController groupsStore)
        {
            _groupsStore = groupsStore;
            _groupsViewModel = groupsViewModel;

            LoadGroups();

            AddGroupCommand = new AddGroupCommand(groupsStore, this);
            DeleteGroupCommand = new DeleteGroupCommand(groupsStore, this);
            EditGroupCommand = new EditGroupCommand();
        }

        public async void LoadGroups()
        {
            GroupsView = await _groupsStore.LoadGroups();
        }
    }
}