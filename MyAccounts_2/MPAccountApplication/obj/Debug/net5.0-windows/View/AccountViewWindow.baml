   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View  5   	   O,clr-namespace:MPAccountApplication.ViewModelMPAccountApplication.ViewModel  5   	   1    +MPAccountApplication.View.AccountViewWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	   C
localmodel,clr-namespace:MPAccountApplication.ViewModel     5   	     � Title$  AccountViewWindow��5   	   $	��450��6#   $	��800��60   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6    �� 5      6    �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      6#   .+�5   
   �� $��0��6   $��Bank:��6!   $��5q�6.   �� 5   
   $��0��6   $��1��6!   $��5q�6b   $	��200��6m   $
��Left=�6y   ��62   �� *DataItem.BankName+ �� Mode$ TwoWay=�6y   �� 5   
   $��1��6   $��Bank Location��6!   $��5q�66   �� 5    
   $��1��6   $��1��6!   $��5q�6f   $	��200��6r   $
��Left=�6~   ��62   �� *DataItem.BankLocation+$ TwoWay=�6~   �� 5!   
   $��2��6   $��Account Number:��6!   $��5q�68   �� 5"   
   $��2��6   $��1��6!   $��5q�6g   $	��200��6s   $
��Left=�6   ��62   �� *DataItem.AccountNumber+$ TwoWay=�6   �� 5#   
   $��3��6   $��Routing Number:��6!   $��5q�68   �� 5$   
   $��3��6   $��1��6!   $��5q�6g   $	��200��6s   $
��Left=�6   ��62   �� *DataItem.RoutingNumber+$ TwoWay=�6   �� 5%   
   $��4��6   $��Balance:��6!   $��5q�61   �� 5&   
   $��4��6   $��1��6!   $��5q�6a   $	��200��6m   $
��Left=�6y   ��62   �� *DataItem.Balance+$ TwoWay=�6y   �� 5'   
   $��5��6   $��Primary:��6!   $��5q�61   �� 5(   
   $��5��6   $��1��6    $��5q�6Y    d� 	IsChecked 60   �� *DataItem.IsPrimary+6Y   �� 5)   
   $��6��6   $��Note:��6!   $��5q�6.   �� 5*   
   $��6��6   $��1��6!   $��5q�6^   
������� �� AcceptsReturn$
 True��6�   ��61   �� *DataItem.Notes+$ TwoWay=�6�   ]� 5,   
   $��7��6   $��2��6"   $
��True��62   $
��Auto=�6W   $��5q�6�   $��2��6�   .+�5-      � .+�5.      �� $��5q�6u   ��6   �� *Items+$ TwoWay=� �� SelectedItem 6F   �� *
DataItem+$ TwoWay=� �� View 5/      �� 50      .P�51      �� $��	Bank Name��6-    �� Width$	 100��6w   	 �� DisplayMemberBinding	 6@   �� *
BankName+$ TwoWay=�6w   �� 52      $��Bank Location��6-   $	 100��6   	 6D   �� *BankLocation+$ TwoWay=�6   �� 53      $��Balance��6-   $	 100��6g   	 6>   �� *	Balance+6g   �� 54      $��Notes��6-   $	 100��6c   	 6<   �� *Notes+6c   55      57      58      59      � 5:   
   $��8��6   $��1��6!   .+�5;      �� $��5q�6   ��6    �� *SaveCommand+.��6A   Save6G   �� 5<      $��5q�6   ��6    �� *DeleteCommand+.��6B   Delete6J   �� 5=      $��5q�6   ��6    �� *
NewCommand+.��6@   New6E   �� 5>      $��5q�6   ��6    �� *CloseCommand+.��6B   Close6I   5?      5@      5A      