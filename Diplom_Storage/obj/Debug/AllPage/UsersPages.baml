   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5      '    !Diplom_Storage.AllPage.UsersPages   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0local$clr-namespace:Diplom_Storage.AllPage  5      -   5        .��5      � }�.   � RowDefinitions  5   
   �� 5      6   �� 5      $	��100 �6   6+   .+�5   
   �� -   5         ��Name$ 
BackBackUP��5   %   $��2��6    J� Opacity$	 0.3Q�69   $	��Top=�6G   $	��600��6_    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$	 150Q�6   5      � 5   
   $��2��6   $��
30 35 30 0q�6    .+�5      �� $
��Left=�6   $	��Top=�64    � Cursor$  ��6L   .+�5      �� -   5         ��Name$ 	SearchBar��5      $
��Left=�5      $	��Top=�6)   $	��500��5      $��45��6   ���#303030$��1q�5   "   ���#7F7F7F._�5      � .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�62   $��35��6@   $��35��6L   ���#C4C4C4$��5 0 0 0q�6l   $��Center=�6}   6�   �� 5      -   5         ��Name$ 	searchBox��5   #   	 �� TextWrapping$
	 Wrap=�6[   $�� ��6o   
 �� TextAlignment$

 Left=�5      $��Center=�6,   $��25(�6H   
�������$��45 0 0 0q�6i   $��0q�6|   $��Calibri)�6�   5      5       &   System.Windows.Controls.DataGrid  5!      -   5          Name$ UserTabl��5!         DataGridRowStyle   RowStyle# �   5"        DataGridCellStyle   	CellStyle# �  6D     MaterialDesignDataGrid#��[ 6t      
IsReadOnly . $	��534��5#   )   $	��500��66   $��0 10 0 0q�6B   $
��Left=�6T   ���#303030$��1q�5$      ���#7F7F7F6@   �� 5%      $��2��6    �� Orientation$ 
Horizontal=�6.   $
��Left=�6G   $��Bottom=�6b   $��40��6}   $	��500��6�   $��0 25 0 0q�6�   .+�5&      �� -   5         ��Name$ PlusUser��5&      $��15(�6/   $	��220��6=   $��Добавить��6I   
�������  ButtonAccentRevealStyle#��[ 6o   $��1q�6�   
�������6�   �� 5'      -   5        $ Redact��5'      $��15(�6-   $	��220��6;   $��60 0 0 0q�6G   $"��Редактирование��6Y   
�������#��[ 6�   $��1q�6�   
�������6�   5(      �� 5)      -   5        $ Delete��5)      $��0 10 0 0q�6)   $��40��6;   $	��220��6G   $��15(�6S   $��Удалить��6a   
�������#��[ 6�   $��1q�6�   
�������6�   5*      � 5+      .+�5,      �� -	   5        $ 	UserBlock��5,   ~   $	��350��6   $	��350��6*   $	��Top=�66   $��Right=�6N   
������ 6�   �� 5-      -
   5        $ UserBlockForma��5-   l   $	��350��6   $	��350��6*   $	��Top=�66   $��Right=�6N   ��5.      �� 5/       �� ImageSource$$ /Resources/backforuserpage.png��6%   51      �� 52      $	��Top=�6   $
��Left=�64   $	��350��6O   $��35��6[   $��539,360,0,0q�6g   
������� �� TextAlignment$ Center=�6�   $��25(�6�   ��53      `� 54       �� StringFormat$ {0} {1}��6'   .1�55      ��  �� Path$ 
first_name�6&   �� 56      $ 
patronymic�6&   57      59      �� 5:      -   5        $ UserCard��5<      $	��Top=�5:      $
��Left=�61   $	��350��6L   $��40��6X   $��539,400,0,0q�5;      
�������#��[ 5<      $)��#Карта Пользователя��6J   $��15(�6g   $  ��6u   6�   5=      5>      5?      5@      