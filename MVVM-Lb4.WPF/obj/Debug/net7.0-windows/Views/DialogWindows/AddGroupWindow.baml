   M S B A M L   `   `   `  ����  MVVM-Lb4.WPF1    +MVVM_Lb4.Views.DialogWindows.AddGroupWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � SizeToContent$  WidthAndHeight=�5   	    � WindowStartupLocation$ CenterScreen=�6(    � Title$ Creating a new group��5   	   $	��450��6&   $	��800��63    � 
ResizeMode$ NoResize=�6?   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $��30 �6   �� 5
      $��30 �6   �� 5      $
��Auto �6   .+�5   
   �� Enter group name:6'   �� 5   
   $��1��6l   $	��250��6y   ��6   ��  �� Path$ UiGroup.GroupName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6y   � 5   
   $��2��6   $��Right=�6!   $��0,15,0,0q�6=   .+�5      �� -   5         �� 	IsDefault$
 True��5      $��60��6;   $��0,0,10,0q�6I   .��6[   OK6_   �� 5      	 �� IsCancel$
	 True��6   $��60��6%   .��63   Cancel6;   5      5      5      