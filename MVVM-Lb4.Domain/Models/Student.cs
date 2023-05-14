using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM_Lb4.Domain.Models.Base;

namespace MVVM_Lb4.Domain.Models;

public class Student : ModelBase
{
	#region Parameters
	
	public Guid StudentId { get; set; }

	private string _name;
	private string _lastName;
	private string _patronymic;
	private byte _courseNumber;
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

	public Guid GroupId { get; set; }
	public Group? Group { get; set; }

	#endregion Parameters

	public Student(string name, string lastName, string patronymic, byte course)
	{
		if (name is null || lastName is null || patronymic is null) throw new ArgumentNullException();

		Name = name;
		LastName = lastName;
		Patronymic = patronymic;
		CourseNumber = course;
	}

	public Student()
	{ }
}