   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   O KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View 5   	   O,clr-namespace:MPAccountApplication.ConverterMPAccountApplication.Converter 5   	   J FMyAccountModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullX=clr-namespace:MyAccountModels.Common;assembly=MyAccountModelsMyAccountModels.Common 5	   	   1   +MPAccountApplication.View.ExpenseViewWindow   5   	   .sys&clr-namespace:System;assembly=mscorlib  5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	   HvalueConverters,clr-namespace:MPAccountApplication.Converter     5   	   Oenums=clr-namespace:MyAccountModels.Common;assembly=MyAccountModels     5	   	   -   5          � Title$  ExpenseViewWindow��5   	   $	��450��6#   $	��800��60    � 	Resources 5         dataFromEnum S� 
MethodName S� 
ObjectTypeU	 QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 	 System.Enum S� MethodParameters M� TypeName��%|   &	        S� 5   
   $ 	GetValues��62   "  6I    5      M� 5      $ enums:ExpenseDuration��6   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      6!   �� 5      $
��auto �6   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      6   �� 5"      $
��auto �6   .+�5)   
   �� $��1��6   $��0��6!   $
��Name��61   $��5q�6=   �� 5*   
   $��1��6   $��1��6!   $��5q�6P   ��61   �� *DataItem.Name+6P   �� 5,   
   $��0��6   $��2��6!   $��Balance��61   $��5q�6@   �� 5-   
   $��0��6   $��3��6!   $��5q�6S   ��61   �� *DataItem.Balance+6S   �� 5.   
   $��1��6   $��2��6!   $��Payment Day Due��61   $��5q�6H   �� 5/   
   $��1��6   $��3��6!   $��5q�6Y   ��61   �� *DataItem.PaymentDayDue+6Y   �� 50   
   $��2��6   $��0��6!   $��Payment��61   $��5q�6@   �� 51   
   $��2��6   $��1��6!   $��5q�6S   ��61   �� *DataItem.Payment+6S   �� 52   
   $��2��6   $��2��6!   $��Notes��61   $��5q�6>   �� 53   
   $��2��6   $��3��6!   $��5q�6Q   $��50��6\   $��2��6h   ��61   �� *DataItem.Notes+6h   �� 54   
   $��3��6   $��0��6!   $��Notes��61   $��5q�6>   �� 55   
   $��3��6   $��1��6    $��5q�56   n   ��55   2   ��  �� Source# [  	 �� SelectedItem	 56      �� *ExpenseDuration+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6n   ]� 5:   
   $��4��6   $
��True��6!   $
��Auto=�6F   $��5q�6v   $��4��6�   .+�5;      � .+�5<      �� $��5q�6h   ��6   �� *Items+$
 TwoWay=�	 6F   �� *
DataItem+ �� View 5=      �� 5>      .P�5?      �� $
��Name��6-    �� Width$	 100��6a    �� DisplayMemberBinding 6;   �� *Name+6a   5@      5B      5C      5D      � 5E   
   $��5��6   .+�5F      �� $��5q�6   ��6    �� *SaveCommand+.��6A   Save6G   �� 5G      $��5q�6   ��6    �� *DeleteCommand+.��6B   Delete6J   �� 5H      $��5q�6   ��6    �� *
NewCommand+.��6@   New6E   �� 5I      $��5q�6   ��6    �� *CloseCommand+.��6B   Close6I   5J      5K      5L      