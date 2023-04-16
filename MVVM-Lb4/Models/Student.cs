using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UniversityLb4.Model;

public class Student : INotifyPropertyChanged
{
	#region Parameters

	private string _name;
	private string _lastName;
	private byte _courseNumber;

	public int StudentId { get; set; }

	public string Name
	{
		get => _name;
		private set
		{
			if (value is null) throw new ArgumentNullException();

			if (value.Length < 3 || value.Length > 20) throw new ArgumentException();

			_name = value;
		}
	}
	public string LastName
	{
		get => _lastName;
		private set
		{
			if (value is null) throw new ArgumentNullException();

			if (value.Length < 3 || value.Length > 20) throw new ArgumentException();

			_lastName = value;
		}
	}

	public byte CourseNumber
	{
		get => _courseNumber;
		private set
		{
			if (value < 1 || value > 6) throw new ArgumentException();

			_courseNumber = value;
		}
	}


	public int GroupId { get; private set; }
	public Group? Group { get; private set; }

	#endregion Parameters

	public Student(string name, string lastName, byte course, Group group)
	{
		if (name == null || lastName == null) throw new ArgumentNullException();

		Name = name;
		LastName = lastName;
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