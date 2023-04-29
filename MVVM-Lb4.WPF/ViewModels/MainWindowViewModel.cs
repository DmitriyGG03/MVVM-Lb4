using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.EF;
using MVVM_Lb4.Infrastructure.Commands;
using MVVM_Lb4.ViewModels.Base;
using MVVM_Lb4.Views.DialogWindows;

namespace MVVM_Lb4.ViewModels;

internal class MainWindowViewModel : ViewModel
{
	#region Parameters

	#region Title

	private string _title = "University Group Manager";

	/// <summary>Window title</summary>
	public string Title
	{
		get => _title;
		set => Set(ref _title, value);
	}

	#endregion Title

	#region Students

	public ObservableCollection<Group> GroupsView { get; }

	#endregion Students

	#region DbContext

	ApplicationDbContext DbContext = new ApplicationDbContext();

	#endregion

	#region SelectedGroup

	private Group _selectedGroup;

	public Group SelectedGroup 
	{ 
		get => _selectedGroup;
		set
		{
			Set(ref _selectedGroup, value);
			OnPropertyChanged(nameof(GroupIsSelected));
		}
	}

	public bool GroupIsSelected => SelectedGroup is not null;

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
		AddGroupWindow addGroupWindow = new AddGroupWindow(this);

		var groups = DbContext.Groups;


		if ((bool)addGroupWindow.ShowDialog()!)
		{
			if (!ValidateStringSyntaxEnteredData(EnteredGroupName, "Group name")) return;

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

	public string EnteredGroupName { get => _enteredGroupName; set => Set(ref _enteredGroupName, value); }

	private bool CanAddGroupCommmandExecute(object p) => true;

	#endregion AddGroup

	#region AddStudent

	public ICommand AddStudentCommmand { get; }
	private string _enteredStudentName;
	private string _enteredStudentSurname;
	private string _enteredStudentPatronymic;
	private string _enteredStudentCourse;

	private void OnAddStudentCommmandExecuted(object p)
	{
		AddStudentWindow addStudentWindow = new AddStudentWindow(this);

		var students = SelectedGroup.Students;

		if ((bool)addStudentWindow.ShowDialog()!)
		{

			if (!ValidateStringSyntaxEnteredData(EnteredStudentName, "Student name")) return;
			if (!ValidateStringSyntaxEnteredData(EnteredStudentSurname, "Student surname")) return;
			if (!ValidateStringSyntaxEnteredData(EnteredStudentPatronymic, "Student patronymic")) return;

			DbContext.Students.Add(new Student(EnteredStudentName,
											   EnteredStudentSurname, 
											   EnteredStudentPatronymic, 
											   byte.Parse(EnteredStudentCourse),
											   SelectedGroup));
			DbContext.SaveChanges();

			MessageBox.Show($"A group called {EnteredGroupName} has been successfully created");

		}
		else
		{
			MessageBox.Show("You must enter data in order to create a new group!");
		}
	}

	private bool ValidateStringSyntaxEnteredData(string data, string paramName)
	{
		if (data is null)
		{
			MessageBox.Show("You must enter data");
			return false;
		}
		else if (data.Length < 3 || data.Length > 15)
		{
			MessageBox.Show($"{paramName} must have minimum 3 symbols and maximum 30");
			return false;
		}
		else return true;
	}

	public string EnteredStudentName { get => _enteredStudentName; set => Set(ref _enteredStudentName, value); }
	public string EnteredStudentSurname { get => _enteredStudentSurname; set => Set(ref _enteredStudentSurname, value); }
	public string EnteredStudentPatronymic { get => _enteredStudentPatronymic; set => Set(ref _enteredStudentPatronymic, value); }
	public string EnteredStudentCourse { get => _enteredStudentCourse; set => Set(ref _enteredStudentCourse, value); }

	private bool CanAddStudentCommmandExecute(object p) => true;

	#endregion AddStudent

	#endregion Commands

	public MainWindowViewModel()
	{
		#region Commands

		CloseApplicationCommand =
			new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

		AddGroupCommmand =
			new LambdaCommand(OnAddGroupCommmandExecuted, CanAddGroupCommmandExecute);

		AddStudentCommmand =
			new LambdaCommand(OnAddStudentCommmandExecuted, CanAddStudentCommmandExecute);


		#endregion Commands

		DbContext.Database.EnsureCreated();
		DbContext.Groups.Load();
		DbContext.Students.Load();
		GroupsView = DbContext.Groups.Local.ToObservableCollection();

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