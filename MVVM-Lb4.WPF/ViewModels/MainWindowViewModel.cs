using System.Windows.Input;
using MVVM_Lb4.Commands;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels;

internal class MainWindowViewModel : ViewModel
{
	#region Commands

	#region CloseApp
	public ICommand CloseApplicationCommand { get; }

	#endregion CloseApp

	#endregion Commands
	
	public GroupsViewModel GroupsViewModel { get; }

	public MainWindowViewModel(GroupsViewModel groupsViewModel)
	{
		#region Commands

		CloseApplicationCommand =
			new CloseApplicationCommand();

		#endregion Commands

		GroupsViewModel = groupsViewModel;
	}
}