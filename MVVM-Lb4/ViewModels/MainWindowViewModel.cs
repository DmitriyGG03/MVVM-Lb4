using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using MVVM_Lb4.Infrastructure.Commands;
using MVVM_Lb4.ViewModels.Base;
using UniversityLb4.Model;

namespace MVVM_Lb4.ViewModels;

internal class MainWindowViewModel : ViewModel
{
	#region Parameters

	#region Title

	private string _title = "University Group Manager";

    /// <summary>Window title</summary>
    public string Title { get => _title;
        set => Set(ref _title, value);
    }

	#endregion Title

	#region Students

    public ObservableCollection<Group> Groups { get; }

    #endregion Students

    #region SelectedGroup

    private Group _selectedGroup;

    public Group SelectedGroup { get => _selectedGroup; set => Set(ref _selectedGroup, value); }

	#endregion SelectedGroup

	#endregion Parameters

	#region Commands

	#region CloseApp

	public ICommand CloseApplicationCommand { get; }

    private void OnCloseApplicationCommandExecuted(object p)
    {
        Application.Current.Shutdown();
    }

    private bool CanCloseApplicationCommandExecute(object p) => true;

    #endregion CloseApp
    
    #endregion Commands

    public MainWindowViewModel()
    {
        #region Commands
        
        CloseApplicationCommand =
            new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);


        #endregion Commands

        var studentNumber = 1;

		var students = Enumerable.Range(1, 20).Select(i => new Student($"Student name {studentNumber}", $"Student last name {studentNumber}", $"Student pantronymic {studentNumber++}", 1));

		var groups = Enumerable.Range(1, 10).Select(i => new Group($"Group {i}", new ObservableCollection<Student>(students)));

        Groups = new ObservableCollection<Group>(groups);

	}
}