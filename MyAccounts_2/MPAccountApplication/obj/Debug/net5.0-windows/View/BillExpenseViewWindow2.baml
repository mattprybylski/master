   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View  5   	   M+clr-namespace:MPAccountApplication.ControlsMPAccountApplication.Controls  5   	   6    0MPAccountApplication.View.BillExpenseViewWindow2   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	   @controls+clr-namespace:MPAccountApplication.Controls     5   	     � Title$  BillExpenseViewWindow2��5
   	   $	��450��6(   $	��800��65   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   ]� $��0��6   $��0��6$   .+�5      �  5      �� 5      $
��auto �6'   66   �� 5      6)    5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5       $
��auto �6$   64   �� 5!      $
��auto �6$   64   .+�5#      �� $��0��6   $��0��6*   $��Name:��6:   $��5q�6G   �� 5$      $��0��6   $��1��6*   $	��150��6]   $
��Left=�6i   $��5q�6�   ��6:   �� *DataItem.Name+6�   �� 5%      $��1��6   $��0��6*   $��Payment:��6:   $��5q�6J   �� 5&      $��1��6   $��1��6*   $	��150��6]   $
��Left=�6i   $��5q�6�   ��6:   �� *DataItem.Payment+6�   �� 5'      $��2��6   $��0��6*   $��Notes:��6:   $��5q�6H   �� 5(      $��2��6   $��1��6*   $	��100��6[   $��1��6h    �� AcceptsReturn$
 True��6y   $��5q�6�   ��6:   �� *DataItem.Notes+6�   �� 5)      $��3��6   $��0��6*   $��Payment Date Due: ��6:   $��5q�6T   (  "System.Windows.Controls.DatePicker  5*      $��3��6   $��1��6*   $
��Left=�6p   $��5q�6�      Text 6:   �� *DataItem.PaymentDateDue+ �� Mode$ TwoWay=�6�   �� 5+      $��4��6   $��0��6*   $��Day Of Month��6:   $��5q�6N   �� 5,      $��4��6   $��1��6*   $��5q�6b   ��6:   �� *DataItem.PaymentDayDue+6b   �� 5-      $��5��6   $��0��6*   $��Has Balance��6:   $��5q�6M   �� 5.      $��5��6   $��1��6*   $��5q�6[    d� 	IsChecked 6:   �� *
HasBalance+6[   5/      50      ]� 51   
   $��1��6   $��0��6$   .+�52      �  53      �� 54      $
��auto �6$   64   .+�56      9� $��Balance��6>      StretchyExpanderTemp#��[  6O   $��5q�6�    9� 
IsExpanded 6   �� *
HasBalance+.��57      �� .+�58      �� $��Balance��6$   $��5q�63   �� 59      ��6"   �� *DataItem.Balance+5:      5;      5=      5>      ]� 5?   
   $��1��6   $��0��6!   $��2��61   .+�5@      ]� $��5��6   $��1��6&   $
��True��66   $
��Auto=�6[   $��5q�6�   $��2��6�   .+�5A      � .+�5B      �� $��5q�6l   ��6   �� *Items+$ TwoWay=� �� SelectedItem 6J   �� *
DataItem+	 �� View	 5C      �� 5D      .P�5E   "   �� $
��Name��61   
 �� Width$	
 100��6e    �� DisplayMemberBinding 6?   �� *Name+6e   �� 5F   "   $��Payment��61   $	
 100��6k    6B   �� *	Payment+6k   �� 5G   "   $��Payment��61   $	
 100��6k    6B   �� *	Balance+6k   5H      5J      5K      5L      5M      1   +MPAccountApplication.Controls.EditorControl  5T   
   $��2��6!   5V      �� 5Y      $��6��6   $��1��6   $��5q�6Q   ��6/   �� *TotalBillExpense+6Q   5Z      5[      