   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View  5   	   5    /MPAccountApplication.View.BillExpenseViewWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	     � Title$  BillExpenseViewWindow��5   	   $	��600��6'   $
��1000��64   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   6.   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��75 �6   6*   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   �� $��1��6   $��0��6"   $��Name:��62   $��5q�6?   �� 5   
   $��1��6   $��1��6"   $��5q�6Q   $	��100��6\   $
��Left=�6h   ��62   �� *DataItem.Name+6h   �� 5   
   $��2��6   $��0��6"   $��Payment:��62   $��5q�6B   �� 5    
   $��2��6   $��1��6"   $��5q�6T   ��62   �� *DataItem.Payment+6T   �� 5!   
   $��3��6   $��0��6"   $��Notes:��62   $��5q�6@   �� 5"   
   $��3��6   $��1��6"   $��1��6R   $��5q�6c   ��62   �� *DataItem.Notes+6c   (  "System.Windows.Controls.DatePicker  5#   
   $��4��6   $��3��6"   $��5q�65   $
��Left=�6f      Text 6@   �� *DataItem.PaymentDate+6f   �� 5$   
   $��4��6   $��0��6"   $��Payment Date Due: ��62   $��5q�6L   ]� 5'   
   $��1��6   $��2��6!   $	��200��62   .+�5(      9� $��Configure Balances��6   $��5q�63    9� 
IsExpanded 6>   �� *ExpandBalance+.��5)      �  5*      �� 5+      $
��auto �6+   6:   �� 5,      6-    5.      �� 5/      $
��auto �6(   68   �� 50      $
��auto �6(   68   �� 51      $
��auto �6(   68   .+�53      �� $��0��6   $��0��6,   $��5q�6f    d� 	IsChecked 6<   �� *DataItem.HasBalance+.��54      �� $��Has Balance��6$   55      �� 56      $��1��6    $��0��6-   $��Balance��6=   $��5q�6L   �� 57      $��1��6    $��1��6-   $��5q�6_   ��6=   �� *DataItem.Balance+6_   58      59      5:      ]� 5;   
   $��5��6   $��1��6"   $
��True��62   $
��Auto=�6W   $��5q�6�   $��2��6�   .+�5<      � .+�5=      �� $��5q�6h   ��6   �� *Items+ �� Mode$ TwoWay=� �� SelectedItem 6F   �� *
DataItem+ �� View 5>      �� 5?      .P�5@      �� $
��Name��6-   	 �� Width$		 100��6a   
 �� DisplayMemberBinding
 6;   �� *Name+6a   �� 5A      $��Payment��6-   $		 100��6g   
 6>   �� *	Payment+6g   5B      5D      5E      5F      � 5G   
   $��6��6   .+�5H      �� $��5q�6   ��6    �� *SaveCommand+.��6A   Save6G   �� 5I      $��5q�6   ��6    �� *DeleteCommand+.��6B   Delete6J   �� 5J      $��5q�6   ��6    �� *
NewCommand+.��6@   New6E   �� 5K      $��5q�6   ��6    �� *CloseCommand+.��6B   Close6I   5L      �� 5M   
   $��6��6   $��1��6!   $��5q�6S   ��61   �� *TotalBillExpense+6S   5O      5P      