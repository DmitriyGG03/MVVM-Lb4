using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF;
using MVVM_Lb4.Infrastructure.Commands;
using MVVM_Lb4.ViewModels.Base;
using MVVM_Lb4.Views.DialogWindows;

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