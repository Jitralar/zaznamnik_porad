   M S B A M L   `   `   `  ����  aplikace_zaznamnik-porad4    .aplikace_zaznamnik_porad.NovyBodProgramuWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Nový bod programu��5   	   $	��200��6#   $	��300��60   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Název:��6-   $��Center=�6>   �� 5   
   $��0��6   $��1��6   $��5q�6k   ��6/   �� *Nazev+ �� UpdateSourceTrigger$ PropertyChanged=�6k   �� 5   
   $��1��6   $��0��6   $��Text k jednání:��6-   $��Center=�6G   �� 5   
   $��1��6   $��1��6   $��5q�6j   ��6/   �� *Text+$ PropertyChanged=�6j   �� 5   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��5q�6k   .+�5      �� $��	Vytvořit��6   $��80��6(   $��5q�63   ��6>   �� *SaveCommand+�� 5      $��Zrušit��6   $��80��6&   $��5q�61   ��6<   �� *CancelCommand+5      5      5      