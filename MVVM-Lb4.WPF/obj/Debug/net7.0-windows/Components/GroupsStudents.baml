   M S B A M L   `   `   `  ����  MVVM-Lb4.WPF(    "MVVM_Lb4.Components.GroupsStudents   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��5      4  .System.Windows.Automation.AutomationProperties   AutomationId$ AddStudentButton��5      $ ��Add student into the group��5      $��16(�5      ��5      �� *AddStudentCommand+{�5      �� *GroupIsSelected+5      �� 5   
   $��1��5      $��5,5,5,5q�5       J� SnapsToDevicePixels$
 true��5      ��5      �� *SelectedGroupName+ �� FallbackValue$ Students�� �� TargetNullValue$ Group not selected��.��5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5         
IsReadOnly$
 true��5      ��5      �� *StudentsView+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *Name+
 �� Mode$
 TwoWay=�  5"      $ 	last name��6)   	 6<   �� *
LastName+$
 TwoWay=�  5#      $ 
Patronymic��6)   	 6=   �� *
Patronymic+$
 TwoWay=�  5$      $ Course number��6)   	 6@   �� *CourseNumber+$
 TwoWay=�5&      5'      5(      5)      