   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MPAccountApplication.ViewMPAccountApplication.View  5   	   O,clr-namespace:MPAccountApplication.ViewModelMPAccountApplication.ViewModel  5   	   W SMPAccountApplicationControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:MPAccountApplicationControls.ControlStyles;assembly=MPAccountApplicationControls*MPAccountApplicationControls.ControlStyles 5   	   I)clr-namespace:MPAccountApplication.CommonMPAccountApplication.Common  5	   	   7    1MPAccountApplication.View.StateProvinceViewWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MPAccountApplication.View     5   	   B	viewModel,clr-namespace:MPAccountApplication.ViewModel     5   	   scontrols^clr-namespace:MPAccountApplicationControls.ControlStyles;assembly=MPAccountApplicationControls     5   	   <common)clr-namespace:MPAccountApplication.Common     5	   	   -   5          � Title$  StateProvinceViewWindow��5   	   $	��450��6)   $	��800��66   .��5   
   �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $�� auto �6   6/   �� 5      6!   .+�5   
   3   -MPAccountApplication.Common.SearchUserControl  $��0��6#   $��0��60   $��2��6@   �� 5   
   $��1��6   $��0��6!   $��Abbreviation��61   $��5q�6E   6R   �� 5   
   $��1��6   $��1��6!   $��5q�6X   $	��100��6c   $
��Left=�6o   ��61   �� *DataItem.Abbreviation+6o   �� 5    
   $��2��6   $��0��6!   $��State or Province��61   $��5q�6J   6W   �� 5!   
   $��2��6   $��1��6    $��5q�6P   $	��100��6[   $
��Left=�6g   ��61   �� *DataItem.Name+6g   ]� 5#   
   $��3��6   $
��True��6!   $
��Auto=�6F   $��5q�6v   $��2��6�   .+�5$      � .+�5%      �� $��5q�6h   ��6   �� *Items+ �� Mode$ TwoWay=� �� SelectedItem 6F   �� *
DataItem+ �� View 5&      �� 5'      .P�5(      �� $
��Name��6-    �� Width$	 100��6a    �� DisplayMemberBinding 6;   �� *Name+6a   �� 5)      $��Abbreviation��6-   $	 200��6q    6C   �� *Abbreviation+6q   5*      5,      5-      5.      � 50   
   $��4��6   .+�51      �� $��5q�6   ��6    �� *SaveCommand+.��6A   Save6G   �� 52      $��5q�6   ��6    �� *DeleteCommand+.��6B   Delete6J   �� 53      $��5q�6   ��6    �� *
NewCommand+.��6@   New6E   �� 54      $��5q�6   ��6    �� *CloseCommand+.��6B   Close6I   55      57      58      