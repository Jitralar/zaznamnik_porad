   M S B A M L   `   `   `  ����  aplikace_zaznamnik-porad.    (aplikace_zaznamnik_porad.HlasovaniWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Hlasovat��5   	   $	��300��6   $	��400��6'   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $��112.04��6*   �� 5	      $
��Auto �6   $��31.96��6*   �� 5
      $
��Auto �6   $��31.96��6*   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Bod programu:��6    $��Center=�68   $��2��6S   $��26��6g   $��	0,0,288,0q�6s   �� 5   
   $��0��6   $��1��6     �� DisplayMemberPath$ Nazev��5      $��5,5,5,5q�5   L   ��5   0   �� *BodyProgramu+ �� SelectedItem 5      �� *VybranyBodProgramu+ �� Mode$ TwoWay=�6L   �� 5   
   $��1��6   $��0��6   $��Text k jednání:��6-   $��Center=�6G   $��2��6b   $��26��6v   $��	0,0,288,0q�6�   �� 5   
   $��1��6   $��1��6!   $��5,5,5,5q�6Z   $
��Wrap=�6k   ��61   �� *VybranyBodProgramu.Text+6k   �� 5   
   $��2��6   $��0��6   $��Hlasující osoba:��6-   $��Center=�6H   $��2��6c   $��26��6w   $��	0,0,288,0q�6�   �� 5   
   $��2��6   $��1��6    $ Jmeno��5      $��5,5,5,5q�5    F   ��5   0   �� *PritomneOsoby+ 5       �� *VybranaOsoba+$ TwoWay=�6F   �� 5#   
   $��3��6   $��0��6   $��Hlasování:��6-   $��Center=�6B   $��2��6]   $��26��6q   $��	0,0,288,0q�6}   �� 5$   
   $��3��6   $��1��6    $��5,5,5,5q�5%   J   ��5$   0   �� *MoznostiHlasovani+ 5%      �� *VybraneHlasovani+$ TwoWay=�6J   �� 5(   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0,5,0,5q�6X   $��1��6i   $	��180��6y   .+�5)      �� $��OK��6   $��80��6"   $��5q�6-   ��68   �� *SaveCommand+�� 5*      $��Cancel��6   $��80��6&   $��5q�61   ��6<   �� *CancelCommand+5+      5,      5-      