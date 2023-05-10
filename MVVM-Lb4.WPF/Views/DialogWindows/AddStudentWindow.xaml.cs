using MVVM_Lb4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MVVM_Lb4.Stores;

namespace MVVM_Lb4.Views.DialogWindows
{
	/// <summary>
	/// Логика взаимодействия для AddStudentWindow.xaml
	/// </summary>
	public partial class AddStudentWindow : Window
	{
		internal AddStudentWindow(GroupsViewModel groupsViewModel)
		{
			InitializeComponent();

			DataContext = groupsViewModel;
		}

		private void Accept_Click(object sender, RoutedEventArgs e) // Of course, better way is to create a new command, but this way is easier
		{
			this.DialogResult = true;
		}
	}
}
