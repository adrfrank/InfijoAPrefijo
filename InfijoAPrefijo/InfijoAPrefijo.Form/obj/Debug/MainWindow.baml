   M S B A M L   `   `   `  ����N  JInfijoAPrefijo.Form, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:InfijoAPrefijo.Form.ViewModelsInfijoAPrefijo.Form.ViewModels  5   	   $    InfijoAPrefijo.Form.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   9vm,clr-namespace:InfijoAPrefijo.Form.ViewModels    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Infijo a prefijo��5   	   $	��350��6"   $	��525��6/   $��Center=�6;   $��Center=�6X    � 
ResizeMode$ NoResize=�6s    � ToolTip$ Infijo a prefijo��6�   ���	#FFB9EEFF$��14(�6�    � 	Resources 5      <   6InfijoAPrefijo.Form.ViewModels.InfixConverterViewModel   	ViewModel��%   &	          5   
   6%   5	      .��5
      � $��	0,0,0,-18q�6E    � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��153* �6   �� 5      $
��364* �6   .+�5   
   �� $��Infijo
��6   }�. $��Center=�6?   $��Center=�6\   $��0��6w   $��0��6�   $��0q�6�   $
��Bold"�6�   $��16(�6�   �� 5   
   $��	Prefijo
��6   $��Center=�6,   $��1��6I   $��32��6V   $��Center=�6b   $��0q�6}   $
��Bold"�6�   $��16(�6�   �� 5   
   $��1��6   $��0��6"   $��Center=�6R   $��67��6o   $��0q�6{    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��341��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   ��6/   �� *Infix+
 �� Mode$
 TwoWay=�6�   �� 5   
   $��1��6   $��Center=�6"   $��77��6d   $��0q�6p   $
 Wrap=�6{   $��Center=�6�   $	��344��6�   $��1��6�   ��6?   �� *Prefix+$
 OneWay=�6�   �� 5   
   $��	Convertir��6   $��1��6%   $��Center=�65   $��0q�6R   $��2��6]   $	��117��6j   $��43��6v   $��Center=�6�   $ 	Convertir��6�   ���	#FF23457F���	#FF172D52���	#FFECDFDF$��16(�6  ��6�   �� *	Convertir+6  5      5      