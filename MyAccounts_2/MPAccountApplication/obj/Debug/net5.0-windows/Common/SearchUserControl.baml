   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MPAccountApplication.CommonMPAccountApplication.Common  5      3    -MPAccountApplication.Common.SearchUserControl   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MPAccountApplication.Common     5        � 	Resources  5
         brushWatermarkBackground �� Color  brushWatermarkBorder   BooleanToVisibilityConverter/   )MPAccountApplication.Common.TextBoxHelper  TextBoxHelper  EntryFieldStyle �� 
TargetType �� Property �� Value��%2  &	        &	      &	 ?     &	 R     &	 e     �� 5   
   $ White��6;   �� 5   
   $ Indigo��67   �� 5   
   6'     5   
   6   �� 5   
   " �6(   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   �� 5       � ��$
 20,0q�6'   5      5      .��5      � .+�5   
   �� $��	Search...��6   
�������$��5q�6?   $	��200��6J   $
��Left=�6V   y�5      `� 5       `� 	Converter# [ 6   .1�5      ��  �� ElementName$ 	txtSearch��6    �� Path$ Text.IsEmpty�66   �� 5      $ 	txtSearch��6   $ 	IsFocused�66   5      5"      �� 5#   
   -   5         ��Name$ 	txtSearch��5#      
������ $��5q�5$      $	��200��6   $
��Left=�6)   .��6E   5&      5'      5(      