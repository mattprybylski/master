   M S B A M L   `   `   `  ����O  KMPAccountApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MPAccountApplication.ConverterMPAccountApplication.Converter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   AnimatedExpanderButtonTemp  �� 
TargetType ��Name �� Padding � ColumnDefinitions F�Name J� RenderTransformOrigin �� Angle ��Name �� Triggers	 P� Property
 P� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions �� 
TargetName �� Property �� Value  StretchyExpanderTemp �� 
TargetType d�Name � OverridesDefaultStyle d� 	IsChecked �� Path �� RelativeSource � LayoutTransform �� ScaleY�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;
converters,clr-namespace:MPAccountApplication.Converter  5      .sys&clr-namespace:System;assembly=mscorlib  5      %n
  &	        &	 �    7   �� 5      "  d�69   .R�5   
   �� $ ExpanderButtonBorder��6   #��z��5	      #��z��5
      #��z��5      # z��5      ._�5      �  5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� 
������ $��2��5       A� 5      $��Circle��6   $��0��5      
�������$��20��5      $��20��5      $��Center=�5      $��Center=�5      F� 5      $ Arrow��6   $��0��5      "����@B `� � �D @KL � z `� 	���	#FF666666$��2��5!      $��Center=�5"      $��Center=�5#      $ 0.5,0.5&�5$      z�5&      �� 5'      $ 0Q�6*   5)      �� 5*      $ HeaderContent��6#   $��1��5+   '   $��4,0,0,0q�5,   '   $��Content��5-   '   5.      5/       50   
   P� 52      	 �@d�	IsChecked$

 TrueY�53       54      �� 55      .��56      �� .��57      W� $ Arrow��6.   $4 .(Path.RenderTransform).(RotateTransform.Angle)�58   2    18059   2   $ 0:0:0.4D�5:   2   5;      5<       5>      �� 5?      .��5@      �� .��5A      W� $ Arrow��6.   $4 .(Path.RenderTransform).(RotateTransform.Angle)�5B   2    05C   2   $ 0:0:0.4D�5D   2   5E      5F      5H      P� 5K      	 �@J�IsMouseOver$

 true��5L   "   . �5M      �� $ Circle��5O   %    � �� �	#FF3C7FB1�� 5P      $ Arrow��5R   %    � �� �#2225S      P� 5T      	 � ��$

 true��5U   "   . �5V      �� $ Circle��5X   %    � �� �	#FF526C7B�� 5Y      $ Circle��5[   %    � ��$	 1.5��5Z   %   5[   %   �� 5\      $ Arrow��5^   %    � �� �	#FF0033665_      5a      �� 5c      " 9�6)   .�5d   
   ��  � �� 5e      �� 5f      "  9�6#   .R�5g      ]� .+�5h      d� $ ExpanderButton��6'   $	��Top=�5i      8��  #��z��5k      $
 True��5m      $��1.5,0q�5n       5l      �� $ 
IsExpanded� �� *TemplatedParent+5o      �� 5p      $ ExpanderContent��6+   $��Content��5q   #   $��Bottom=�5r   #    5t      �� 5u   "   $ 0Q�61   5w      5x       5y      P� 5z      	 �@9�
IsExpanded$

 True��68    5{      �� 5|   "   .��5}   &   �� .��5~   *   W� $ ExpanderContent��6:   $@ :(ContentPresenter.LayoutTransform).(ScaleTransform.ScaleY)�5   2    15�   2   $ 0:0:0.4D�5�   2   5�   '   5�   #    5�      �� 5�   "   .��5�   &   �� .��5�   *   W� $ ExpanderContent��6:   $@ :(ContentPresenter.LayoutTransform).(ScaleTransform.ScaleY)�5�   2    05�   2   $ 0:0:0.4D�5�   2   5�   '   5�   #   5�      5�      5�      5�      5�      