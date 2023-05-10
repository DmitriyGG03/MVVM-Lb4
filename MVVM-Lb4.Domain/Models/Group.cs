using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM_Lb4.Domain.Models.Base;

namespace MVVM_Lb4.Domain.Models;

public class Group : ModelBase
{
	#region Parameters

    public Guid GroupId { get; set; }
    
	private string _groupName;
	public string GroupName 
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

    private IList<Student>? _students = new List<Student>();
    public IList<Student>? Students
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

	public Group(string groupName, IList<Student>? students = null)
    {
        GroupName = groupName;        
        Students = students;
    }

	public Group()
    { }

}