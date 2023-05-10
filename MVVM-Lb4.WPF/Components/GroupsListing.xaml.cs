using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DropdownMenuControl;
using MVVM_Lb4.Stores;

namespace MVVM_Lb4.Components;

/// <summary>
/// Логика взаимодействия для GroupsListing2.xaml
/// </summary>
public partial class GroupsListing : UserControl
{
	public GroupsListing()
	{
		InitializeComponent();
	}
	
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//dropdown.IsOpen = false;
	}
}
