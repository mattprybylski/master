   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View  5   	   M+clr-namespace:MPAccountApplication.ControlsMPAccountApplication.Controls  5   	   0    *MPAccountApplication.View.LedgerViewWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	   @controls+clr-namespace:MPAccountApplication.Controls     5   	     � Title$  LedgerViewWindow��5	   	   $	��450��6"   $	��800��6/   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6    �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $�� auto �6   6/   �� 5      6!   .+�5   
   �� $��0��6   $��0��6#   $��Account:��63   �� 5   
   $��0��6   $��1��6#   $��5q�6c   ��65   �� *
Accounts+ �� Mode$ TwoWay=� �� SelectedItem 5      �� *	Account+$ TwoWay=��� 5   
   $��1��6   $��0��6#   $��Type : ��65   $��5q�6D   �� 5   
   $��1��6   $��1��6#   $��5q�6i   ��67   �� *BillExpenses+$ TwoWay=� 5       �� *BillExpense+$ TwoWay=�5&      (  "System.Windows.Controls.DatePicker  5'   
   $��2��6   $��3��6"   $��5q�65      Text 6@   �� *DataItem.PaymentDate+�� 5(   
   $��2��6   $��0��6"   $��Payment Date: ��62   $��5q�6H   �� 5)   
   $��3��6   $��0��6"   $��Tranaction Type��62   $��5q�6I   �� 5*   
   $��3��6   $��1��6"   $��5q�6\   ��62   �� *DataItem.TransactionType+6\   �� 5+   
   $��4��6   $��0��6"   $��Amount��62   $��5q�6@   �� 5,   
   $��4��6   $��1��6"   $��5q�6a   ��62   �� *DataItem.Payment+$ TwoWay=�6a   �� 5-   
   $��5��6   $��1��6"   $��5q�6R   $��50��6]    �� AcceptsReturn$
 True��6i   ��62   �� *DataItem.Notes+6i   �� 5.   
   $��5��6   $��0��6"   $��Notes: ��63   $��5q�6B   ]� 50   
   $��6��6   $��2��6!   $
��True��61   $
��Auto=�6V   $��2��6�   .+�51      � .+�52      �� $��5q�6h   ��6   �� *Items+$ TwoWay=� 6F   �� *
DataItem+ �� View 53      �� 54      .P�55      �� $
��Name��6-    �� Width$	 100��6m   	 �� DisplayMemberBinding	 6;   �� *BillExpense.Name+6m   �� 56      $��Payment��6-   $	 100��6m   	 6>   �� *PaymentString+6m   �� 57      $��Payment��6-   $	 100��6g   	 6>   �� *	Balance+6g   58      5:      5;      5<      1   +MPAccountApplication.Controls.EditorControl  5>   
   $��8��6!   5@      5B      5C      