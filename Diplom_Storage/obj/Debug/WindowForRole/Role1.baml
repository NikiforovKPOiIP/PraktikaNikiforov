   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Diplom_Storage.WindowForRoleDiplom_Storage.WindowForRole  5   	   E AFluentWPF, Version=0.10.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5   	   (    "Diplom_Storage.WindowForRole.Role1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Diplom_Storage.WindowForRole     5   	   Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
������ $	��800��5   	   $
��1200��6     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   )  #SourceChord.FluentWPF.AcrylicWindow   Enabled .    AcrylicWindowStyle$
 None=�5   	      AcrylicAccentState$ 
BlurBehind=�5   	    � AllowsTransparency . .��5      � 
������  J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 300Q�6   	 � ColumnDefinitions	 5   
   �� 5      $	��251 �6   6.   �� 5      6!   
 � RowDefinitions
 5   
   �� 5      $��35 �6   6*   �� 5      6   .+�5   
   � $��2��6   $��2��6    ���#1E1F226L   � 5    
   -   5         �Name$ Gridmain��5    2   $��2��6   $��2��6    .+�5!       � -   5          �Name$ FrmRole1��5!        � NavigationUIVisibility$ Hidden=�6&   5"      �� 5#   
   -   5        $��2��5#      
������ 
������ $	��Top=�6Z   $��35��5$   /   ._�5%      � -   5        $	 top��5%   "   $��30��6   .+�5&      �� -   5         ��Name$
 Exit��5&      $��Right=�6'    %  !CustomMaterialDesignFlatButtonRed#��[  6C   $��27��6~   $��50��6�   $��0 0 10 0q�6�    J� Opacity$	 0.8Q�6�   .��5'      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�6.   $��25��6?   $��25��6J   $��Center=�6V   $��Center=�6q   
�������6�   5(      �� 5)      -   5        $ Minimize��5)      $��Right=�6+   $��Center=�6G    + 'CustomMaterialDesignFlatButtonLightGrey#��[ 6b   $��27��6�   $��50��6�   $��0 0 70 0q�6�   $	 0.8Q�6�   .��5*        $ WindowMinimize=�6.   $��25��6D   $��25��6O   $��Center=�6[   $��Center=�6v   
�������6�   5+      5,      5-      � 5.   
   -   5        $ Menugrid��5.      $��Center=�6"   $	��250��6?   $��2��6K   *  $SourceChord.FluentWPF.PointerTracker   Enabled .  ���#101114$y�Visible=�6�   .+�5/      �� $��10q�6    � Cursor$  ��6%   .+�50      	� -   5         	�Name$	 Acc��50      $��50��6+     
menuButton#��[ 68   
�������$��0 0 0 10q�6p   $
 Hand��6�   .��51      ��  �� Orientation$ 
Horizontal=�6!   $	��216��6:   $��10 0 0 0q�6F   .+�52      A� -	   5         A�Name$ avarole��52   "   $��30��63   $��30��6>   53      �� 54      $ Vertical=�6%   $��5 0 0 0q�6<   .+�55      �� -
   5         ��Name$ UserName��55   (   $��12(�6:   $��Calibri)�6H   6_   �� 56      -   5        $ UserRole��56   (   $��12(�6:   ���#101114���#FFFFFF$��Calibri)�6r   $	��105��6�   $
��Left=�6�   Должность6�   57      58      59      	� 5:      -   5        $
 Main��5:      $��45��6,   #��[ 69   
�������.��5;      �� $ 
Horizontal=�6!   $	��216��6:   .+�5<        $
 Home=�62   $��25��6>   $��25��6J   
�������$��0 0 0 0q�6h   6|   �� 5=      $��Главная��6$   $��Center=�63   $��10 0 0 0q�6N   
�������6`   5>      5?      	� 5@      -   5        $ Users��5@      $��45��6-   #��[ 6:   
�������.��5A      �� $ 
Horizontal=�6!   $	��216��6:   .+�5B        $
 User=�62   $��25��6>   $��25��6J   
�������$��0 0 0 0q�6h   6|   �� 5C      $��Пользователи��6$   $��Center=�68   $��10 0 0 0q�6S   
�������6e   5D      5E      	� 5F      -   5        $ Tovar��5F   *   $��45��6   #��[ 69   
�������.��5G      �� $ 
Horizontal=�6!   $	��216��6:   .+�5H        $ TreasureChest=�62   $��25��6G   $��25��6S   
�������$��0 0 0 0q�6q   6�   �� 5I      $��Товары��6$   $��Center=�62   $��10 0 0 0q�6M   
�������6_   5J      5K      	� 5L      -   5        $��45��5L      #��[ 6+   
�������$
 Hand��6}   .��5M      �� $ 
Horizontal=�6!   $	��216��6:   .+�5N        $ Package=�62   $��25��6A   $��25��6M   
�������$��0 0 0 0q�6k   6   �� 5O      $��
Склад��6$   $��Center=�61   $��10 0 0 0q�6L   
�������6^   5P      5Q      	� 5R      -   5        $ Zakaz��5R      $��45��6-   #��[ 6:   
�������.��5S      �� $ 
Horizontal=�6!   $	��216��6:   .+�5T        $  OrderBoolDescendingVariant=�62   $��25��6T   $��25��6`   
�������$��0 0 0 0q�6~   6�   �� 5U      $��
Заказ��6$   $��Center=�61   $��10 0 0 0q�6L   
�������6^   5V      5W      	� 5X      -   5        $ 	Operation��5X      $��45��61   #��[ 6>   
�������.��5Y      �� $ 
Horizontal=�6!   $	��216��6:   .+�5Z        $	 Cog=�62   $��25��6=   $��25��6I   
�������$��0 0 0 0q�6g   6{   �� 5[      $��Операции��6$   $��Center=�64   $��10 0 0 0q�6O   
�������6a   5\      5]      	� 5^      -   5        $ Report��5^      $��45��6.   #��[ 6;   
�������.��5_      �� $ 
Horizontal=�6!   $	��216��6:   .+�5`        $
 File=�62   $��25��6>   $��25��6J   
�������$��0 0 0 0q�6h   6|   �� 5a      $��Отчёты��6$   $��Center=�62   $��10 0 0 0q�6M   
�������6_   5b      5c      5d      �� 5e      $��10q�6   $��Bottom=�6%   .+�5f      	� -   5        $��45��5f      #��[ 6+   
�������.��5g      �� $ 
Horizontal=�6!   $	��216��6:   .+�5h        $ TuneVertical=�62   $��25��6F   $��25��6R   
�������$��0 0 0 0q�6p   6�   �� 5i      $��Настройки��6$   $��Center=�65   $��10 0 0 0q�6P   
�������6b   5j      5k      	� 5l      -   5        $ ExitAcc��5l      $��45��6/   #��[ 6<   
�������.��5m      �� $ 
Horizontal=�6!   $	��216��6:   .+�5n        $ Logout=�62   $��25��6@   $��25��6L   
�������$��0 0 0 0q�6j   6~   �� 5o      $��
Выйти��6$   $��Center=�61   $��10 0 0 0q�6L   
�������6^   5p      5q      5r      5s      5t      5u      