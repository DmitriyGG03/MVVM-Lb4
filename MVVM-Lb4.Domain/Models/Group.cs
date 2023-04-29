using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Lb4.Domain.Models;

public class Group : INotifyPropertyChanged
{
	#region Parameters

	private string _groupName;
    private ICollection<Student>? _students;

	public Guid GroupId { get; set; }

	public string GroupFullName 
    {
        get => _groupName;

		set
        {
            if (value is null) throw new ArgumentNullException();

            if (value.Length < 3 || value.Length > 15) 
                throw new ArgumentException();

            _groupName = value;
        } 
    }

    public ICollection<Student>? Students
    {
        get => _students;
        set
        {
            if (_students is not null && _students.Count >= 35)
                throw new InvalidOperationException();

            _students = value;
        }
    }

	#endregion Parameters

	public Group(string groupName, ICollection<Student>? students = null)
    {
        GroupFullName = groupName;        
        Students = students;
    }

	public Group()
    { }

	public event PropertyChangedEventHandler PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string prop = "")
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(prop));
	}
}