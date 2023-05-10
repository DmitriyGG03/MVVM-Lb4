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
		public List<Group> GroupsListView { get => groupsStore.GroupsView; }

		private GroupsStore groupsStore { get; }

		public Group SelectedGroup { get => groupsStore.SelectedGroup; set => groupsStore.SelectedGroup = value; }

		public ICommand DeleteGroupCommand { get; }
		public ICommand EditGroupCommand { get; }

		public GroupsListingViewModel(GroupsStore groupsStore)
		{
			this.groupsStore = groupsStore;

			DeleteGroupCommand = new DeleteGroupCommand();
			EditGroupCommand = new EditGroupCommand();
		}
	}
}
