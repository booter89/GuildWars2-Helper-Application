   M S B A M L   `   `   `  ����P  LEnhanced Guild Wars 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:Enhanced_Guild_Wars_2.User_Controls.Converter-Enhanced_Guild_Wars_2.User_Controls.Converter  5      9    3Enhanced_Guild_Wars_2.User_Controls.CommerceListing   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pcoverter;clr-namespace:Enhanced_Guild_Wars_2.User_Controls.Converter     5      -   5        .��5
      � $	��400��6     � RowDefinitions  5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$  CommerceListingBuyDataGrid��5         AutoGenerateColumns .  $��0��5      $��0��6    
�������   CanUserSortColumns .    CanUserAddRows .     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6)      
IsReadOnly .    LeftDataGridHeaderStyle	   HeaderStyle#	 [  6H   
   Header
 5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��../Assets/Images/gold.png��6$   $��10��6G   $��10��6R   $��0q�6^   �� 5      $!��../Assets/Images/silver.png��6$   $��10��6I   $��10��6T   $��0q�6`   �� 5      $!��../Assets/Images/copper.png��6$   $��10��6I   $��10��6T   $��0q�6`   5         CellTemplate 5!      �� 5#      .R�5$      �� $ 
Horizontal=�6)   $��Center=�6B   $��Right=�6]   .+�5%   "   ��  ��Name$ CMLBuyGoldPriceImage��6=   $��0��6(   $��0��62   $��0q�6[   �� 5&   "   $��12(�5'   4   $��Serif)�6B   ���#E68A00$
��Bold"�6j   $��2,0,5,0q�6|   ��5&   ,   �� *
value.gold+5'   |   �� 5(   "   $ CMLBuySilverPriceImage��6=   $��0��6(   $��0��62   6=   �� 5)   "   $��12(�5*   4   $��Serif)�6B   ���#787878$
��Bold"�6j   $��2,0,5,0q�6|   ��5)   ,   �� *value.silver+5*   |   �� 5+   "   $ CMLBuyCopperPriceImage��6=   $��0��6(   $��0��62   6=   �� 5,   "   $��12(�5-   4   $��Serif)�6B   ���#D47F46$
��Bold"�6j   $��2,0,0,0q�6|   ��5,   ,   �� *value.copper+5-   |   5.       �� Triggers 50      �� 51   "    �� Value$ False��6y    �� Binding 6.   �� *
value.gold+  IsNullConverter �� 	Converter# [ .a�52   &   ��  �� 
TargetName$ CMLBuyGoldPriceImage��6a    �� Property � �� �� Value$ ../Assets/Images/gold.png��6?   6a   �� 53   &   $ CMLBuyGoldPriceImage��6I    � ��$ 14��6>   6I   �� 54   &   $ CMLBuyGoldPriceImage��6J    � ��$ 14��6?   6J   55   #   �� 56   "   $ False��6{    6.   �� *value.silver+# [ .a�57   &   �� $ CMLBuySilverPriceImage��6c    � ��$! ../Assets/Images/silver.png��6?   6c   �� 58   &   $ CMLBuySilverPriceImage��6I    � ��$ 14��6>   6I   �� 59   &   $ CMLBuySilverPriceImage��6J    � ��$ 14��6?   6J   5:   #   �� 5;   "   $ False��6{    6.   �� *value.copper+# [ .a�5<   &   �� $ CMLBuyCopperPriceImage��6c    � ��$! ../Assets/Images/copper.png��6?   6c   �� 5=   &   $ CMLBuyCopperPriceImage��6I    � ��$ 14��6>   6I   �� 5>   &   $ CMLBuyCopperPriceImage��6J    � ��$ 14��6?   6J   5?   #   5B      5D        5F      $
 Auto 6)    .   RightDataGridHeaderStyle#	 [ 6H   
 5G      �� 5H      $��Demand��6$    5J      �� 5K      .R�5L      �� $��14(�6B   $��Serif)�6P   $
��Bold"�6c   $��Center=�5M   (   $��Right=�6C   $��5,0,5,0q�6_   ��5L   (   �� *
quantity+5M   _   5N      5P        5R      $
 Auto 6)    . #	 [ 6H   
 5S      �� 5T      $��Buyers��6$    5V      �� 5W      .R�5X      �� $��14(�6B   $��Serif)�6P   $
��Bold"�6c   $��Center=�5Y   (   $��Right=�6C   $��5,0,5,0q�6_   ��5X   (   �� *
listings+5Y   _   5[      5]      5`        5b   
   -   5        $! CommerceListingSellDataGrid��5b       .  $��0��5c      $��2��6    
������� .  .   5f        5g      $
 Auto 6)    . #	 [  6H   
 5h      �� 5i      $ 
Horizontal=�6%   .+�5j      �� $��../Assets/Images/gold.png��6$   $��10��6G   $��10��6R   $��0q�6^   �� 5k      $!��../Assets/Images/silver.png��6$   $��10��6I   $��10��6T   $��0q�6`   �� 5l      $!��../Assets/Images/copper.png��6$   $��10��6I   $��10��6T   $��0q�6`   5m       5o      �� 5q      .R�5r      �� $ 
Horizontal=�6)   $��Center=�6B   $��Right=�6]   .+�5s   "   �� $ CMLSellGoldPriceImage��6=   $��0��6(   $��0��62   $��0q�6\   �� 5t   "   $��12(�5u   4   $��Serif)�6B   ���#E68A00$
��Bold"�6j   $��2,0,5,0q�6|   ��5t   ,   �� *
value.gold+5u   |   �� 5v   "   $ CMLSellSilverPriceImage��6=   $��0��6(   $��0��62   6=   �� 5w   "   $��12(�5x   4   $��Serif)�6B   ���#787878$
��Bold"�6j   $��2,0,5,0q�6|   ��5w   ,   �� *value.silver+5x   |   �� 5y   "   $ CMLSellCopperPriceImage��6=   $��0��6(   $��0��62   6=   �� 5z   "   $��12(�5{   4   $��Serif)�6B   ���#D47F46$
��Bold"�6j   $��2,0,0,0q�6|   ��5z   ,   �� *value.copper+5{   |   5|       5~      �� 5   "   $ False��6y    6.   �� *
value.gold+# [ .a�5�   &   �� $ CMLSellGoldPriceImage��6a    � ��$ ../Assets/Images/gold.png��6?   6a   �� 5�   &   $ CMLSellGoldPriceImage��6I    � ��$ 14��6>   6I   �� 5�   &   $ CMLSellGoldPriceImage��6J    � ��$ 14��6?   6J   5�   #   �� 5�   "   $ False��6{    6.   �� *value.silver+# [ .a�5�   &   �� $ CMLSellSilverPriceImage��6c    � ��$! ../Assets/Images/silver.png��6?   6c   �� 5�   &   $ CMLSellSilverPriceImage��6I    � ��$ 14��6>   6I   �� 5�   &   $ CMLSellSilverPriceImage��6J    � ��$ 14��6?   6J   5�   #   �� 5�   "   $ False��6{    6.   �� *value.copper+# [ .a�5�   &   �� $ CMLSellCopperPriceImage��6c    � ��$! ../Assets/Images/copper.png��6?   6c   �� 5�   &   $ CMLSellCopperPriceImage��6I    � ��$ 14��6>   6I   �� 5�   &   $ CMLSellCopperPriceImage��6J    � ��$ 14��6?   6J   5�   #   5�      5�        5�      $
 Auto 6)    . #	 [ 6H   
 5�      �� 5�      $��Demand��6$    5�      �� 5�      .R�5�      �� $��14(�6B   $��Serif)�6P   $
��Bold"�6c   $��Center=�5�   (   $��Right=�6C   $��5,0,5,0q�6_   ��5�   (   �� *
quantity+5�   _   5�      5�        5�      $
 Auto 6)    . #	 [ 6H   
 5�      �� 5�      $��Sellers��6$    5�      �� 5�      .R�5�      �� $��14(�6B   $��Serif)�6P   $
��Bold"�6c   $��Center=�5�   (   $��Right=�6C   $��5,0,5,0q�6_   ��5�   (   �� *
listings+5�   _   5�      5�      5�      5�      5�      