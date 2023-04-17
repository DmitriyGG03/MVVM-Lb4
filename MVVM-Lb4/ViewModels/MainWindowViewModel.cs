using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Infrastructure;
using MVVM_Lb4.Infrastructure.Commands;
using MVVM_Lb4.ViewModels.Base;
using MVVM_Lb4.Views.DialogWindows;
using Newtonsoft.Json.Linq;
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

	#region DbContext

    ApplicationDbContext DbContext = new ApplicationDbContext();

	#endregion

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

	#region AddGroup

	public ICommand AddGroupCommmand { get; }
	private string _enteredGroupName = "";

	private void OnAddGroupCommmandExecuted(object p)
	{
		AddGroupWindow addGroupWindow = new AddGroupWindow();

		var groups = DbContext.Groups;


		if ((bool)addGroupWindow.ShowDialog()!)
		{
			if (!ValidateSyntaxEnteredGroupName()) return;

			if (groups.Any(g => g.GroupFullName.Equals(EnteredGroupName)))
			{
				MessageBox.Show("A group with the same name already exists!");
			}
			else
			{
				DbContext.Groups.Add(new Group(EnteredGroupName));
				DbContext.SaveChanges();

				MessageBox.Show($"A group called {EnteredGroupName} has been successfully created");
			}
		}
		else
		{
			MessageBox.Show("You must enter data in order to create a new group!");
		}
	}

	private bool ValidateSyntaxEnteredGroupName()
	{
		if (EnteredGroupName is null)
		{
			MessageBox.Show("You must enter data");
			return false;
		}
		else if (EnteredGroupName.Length < 3 ||
			EnteredGroupName.Length > 15)
		{
			MessageBox.Show("Group name must have minimum 3 symbols and maximum 30");
			return false;
		}
		else return true;		
	}

	public string EnteredGroupName { get => _enteredGroupName; set => Set(ref _enteredGroupName, value); }

	private bool CanAddGroupCommmandExecute(object p) => true;

	#endregion AddGroup

	#endregion Commands

	public MainWindowViewModel()
    {
        #region Commands
        
        CloseApplicationCommand =
            new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

		AddGroupCommmand = 
			new LambdaCommand(OnAddGroupCommmandExecuted, CanAddGroupCommmandExecute);


		#endregion Commands

		DbContext.Database.EnsureCreated();
		DbContext.Groups.Load();
		DbContext.Students.Load();
		Groups = DbContext.Groups.Local.ToObservableCollection();

		//Groups = TestGroupGeneration();

	}

	/*
	private ObservableCollection<Group> TestGroupGeneration()
    {
		var studentNumber = 1;

		var students = Enumerable.Range(1, 20).Select(i => new Student($"Student name {studentNumber}", $"Student last name {studentNumber}", $"Student pantronymic {studentNumber++}", 1));

		var groups = Enumerable.Range(1, 10).Select(i => new Group($"Group {i}", new ObservableCollection<Student>(students)));

        return new ObservableCollection<Group>(groups);
	}
	*/
}