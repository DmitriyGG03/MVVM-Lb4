using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UniversityLb4.Model;

public class Student : INotifyPropertyChanged
{
	#region Parameters

	private string _name;
	private string _lastName;
	private string _patronymic;
	private byte _courseNumber;

	public int StudentId { get; set; }

	public string Name
	{
		get => _name;
		set
		{
			if (value is null) throw new ArgumentNullException();

			if (value.Length < 3 || value.Length > 30) throw new ArgumentException();

			_name = value;
		}
	}
	public string LastName
	{
		get => _lastName;
		set
		{
			if (value is null) throw new ArgumentNullException();

			if (value.Length < 3 || value.Length > 30) throw new ArgumentException();

			_lastName = value;
		}
	}
	
	public string Patronymic
	{
		get => _patronymic;
		set
		{
			if (value is null) throw new ArgumentNullException();

			if (value.Length < 3 || value.Length > 30) throw new ArgumentException();

			_patronymic = value;
		}
	}

	public byte CourseNumber
	{
		get => _courseNumber;
		set
		{
			if (value < 1 || value > 6) throw new ArgumentException();

			_courseNumber = value;
		}
	}


	public int? GroupId { get; private set; }
	public Group? Group { get; private set; }

	#endregion Parameters

	public Student(string name, string lastName, string patronymic, byte course, Group group = null)
	{
		if (name == null || lastName == null) throw new ArgumentNullException();

		Name = name;
		LastName = lastName;
		Patronymic = patronymic;
		CourseNumber = course;
		Group = group;
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string prop = "")
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(prop));
	}
}