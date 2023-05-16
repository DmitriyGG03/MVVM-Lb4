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
    public partial class ConfirmOperationWindow : Window
    {
		internal ConfirmOperationWindow(string operation)
        {
            
            InitializeComponent();

            Title = Char.ToUpper(operation[0]) + operation.Substring(1);
            textBlock.Text = $"Are you sure you want to {operation}?";
        }

		/// <summary>Set success result for dialog window</summary>
		private void Accept_Click(object sender, RoutedEventArgs e) // Of course, better way is to create a new command, but this way is easier
        {
            this.DialogResult = true;
        }

	}
}
