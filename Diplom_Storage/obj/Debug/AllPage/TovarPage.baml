   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5      &     Diplom_Storage.AllPage.TovarPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0local$clr-namespace:Diplom_Storage.AllPage  5      -   5        .��5      � }�.   � RowDefinitions  5   
   �� 5      6   �� 5      $	��100 �6   6+   .+�5   
   �� -   5         ��Name$ 
BackBackUP��5   %   $��2��6    J� Opacity$	 0.3Q�69   $	��Top=�6G   $	��600��6_    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$	 150Q�6   5      � 5   
   $��2��6   $��
30 35 30 0q�6    .+�5      �� $
��Left=�6   $	��Top=�64    � Cursor$  ��6L   .+�5      �� -   5         ��Name$ 	SearchBar��5      $
��Left=�5      $	��Top=�6)   $	��500��5      $��45��6   ���#303030$��1q�5   "   ���#7F7F7F._�5      � .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�62   $��35��6@   $��35��6L   ���#C4C4C4$��5 0 0 0q�6l   $��Center=�6}   6�   �� 5      -   5         ��Name$ 	searchBox��5   #   	 �� TextWrapping$
	 Wrap=�6[   $�� ��6o   
 �� TextAlignment$

 Left=�5      $��Center=�6,   $��25(�6H   
�������$��45 0 0 0q�6i   $��0q�6|   $��Calibri)�6�   5      5       &   System.Windows.Controls.DataGrid  5!      -   5          Name$ 	TovarTabl��5!         DataGridRowStyle   RowStyle# �   5"        DataGridCellStyle   	CellStyle# �  6D     MaterialDesignDataGrid#��[ 6t      
IsReadOnly . $	��534��5#   )   $	��885��66   $��1 10 1 0q�6B   $��Center=�6T   ���#303030$��1q�5$      ���#7F7F7F6@   � 5%      $	��120��6   .+�5&      ��  �� Orientation$ 
Horizontal=�6!   .+�5'      �� $
��Left=�6%   $	��110��6@   $	��500��6M   .+�5(      �� $��2��6)   $ 
Horizontal=�6:   $
��Left=�6S   $	��Top=�6n   $��40��6�   $	��500��6�   $��0 15 0 0q�6�   .+�5)   "   �� -   5         ��Name$ PlusUser��5)   )   $��15(�6<   $	��220��6J   $��Добавить��6V   
�������  ButtonAccentRevealStyle#��[ 6|   $��1q�6�   
�������6�   �� 5*   "   -   5        $ Redact��5*   )   $��15(�69   $	��220��6G   $��60 0 0 0q�6S   $"��Редактирование��6e   
�������#��[ 6�   $��1q�6�   
�������6�   5+      �� 5,      -   5        $ Delete��5,   %   $��0 10 0 0q�65   $��Bottom=�6G   $��Center=�6b   $��40��6   $	��220��6�   $��15(�6�   $��Удалить��6�   
�������#��[ 6�   $��1q�6�   
�������6#  5-      �� 5.      $��0 5 0 0q�6%   .+�5/      �� -	   5        $ 
KartTovara��5/   %   $��	30 15 0 0q�69   $	��Top=�6L   $��Center=�6d   $��40��6�   $	��220��6�   $��15(�6�   $��Карта Товара��6�   
�������#��[ 6�   $��1q�50   !   
�������6I   �� 51      -
   5         ��Name$ 	TovarName��51   k   $��Right=�6%   $��30��6A   $	��220��6M   $��0 10 0 0q�6Y   
�������$��20(�6�    �� TextAlignment$ Center=�6�   6�   52      � 53      $��	10 20 0 0q�6   .+�54      �� -   5        $ 	UserBlock��54   S   $	��100��6%   $	��100��62   
������ $��0 0 0 0q�6f   6y   �� 55      -   5        $ UserBlockForma��55   5   $	��100��6%   ��56      �� 57   "    �� ImageSource$$ /Resources/backforuserpage.png��6-   59      5:      5;      5<      5=      5>      5?      5@      