   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View  5   	   5    /MPAccountApplication.View.ExpenseTypeViewWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	   -   5          � Title$  Bill Expense Type��5   	   $	��200��6#   $	��500��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Expense Type: ��6$   �� 5   
   $��1��6   ��6$   �� *DataItem.Name+]� 5   
   $��1��6   $
��True��6!   $
��Auto=�6F   $��5q�6v   $��2��6�   .+�5      � .+�5      �� $��5q�6h   ��6   �� *Items+ �� Mode$ TwoWay=� �� SelectedItem 6F   �� *
DataItem+ �� View 5      �� 5      .P�5      �� $
��Name��6-    �� Width$	 100��6a    �� DisplayMemberBinding 6;   �� *Name+6a   5      5      5      5      � 5    
   $��4��6   .+�5!      �� $��5q�6   ��6    �� *SaveCommand+.��6A   Save6G   �� 5"      $��5q�6   ��6    �� *DeleteCommand+.��6B   Delete6J   �� 5#      $��5q�6   ��6    �� *
NewCommand+.��6@   New6E   �� 5$      $��5q�6   ��6    �� *CloseCommand+.��6B   Close6I   5%      5&      5'      