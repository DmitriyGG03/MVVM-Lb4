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

namespace MVVM_Lb4.Views.DialogWindows
{
    public partial class AddGroupWindow : Window
    {
		internal AddGroupWindow(MainWindowViewModel mainWindowViewModel)
        {
            //Add MainWindowsViewModel object into constructor in order to do not create new and use already existed instead
            InitializeComponent();

            DataContext = mainWindowViewModel;
		}

		/// <summary>Set success result for dialog window</summary>
		private void Accept_Click(object sender, RoutedEventArgs e) // Of course, better way is to create a new command, but this way is easier
        {
            this.DialogResult = true;
        }

	}
}
