   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5   	   &     Diplom_Storage.AllPage.AddToUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Diplom_Storage.AllPage     5   	     � Title$  	AddToUser��5   	   $	��450��6   $	��800��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Логин:��6   $��10q�6"   $��Center=�6.   $��0��6I   $��0��6V   �� 5   
   -   5         ��Name$ LoginTextBox��5      $��10q�6(   $��0��64   $��1��6A   �� 5   
   $��Пароль:��6   $��10q�6#   $��Center=�6/   $��1��6J   $��0��6W   �� 5   
   -   5        $ PasswordTextBox��5      $��10q�6+   $��1��67   $��1��6D   �� 5   
   $��	Роль:��6   $��10q�6!   $��Center=�6-   $��2��6H   $��0��6U   �� 5   
   -   5         ��Name$ RoleComboBox��5      $��10q�6)   $��2��65   $��1��6B    �� DisplayMemberPath$
 name��5   1   ��6   �� *roles+61   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��10q�6J   $��3��6V   $��1��6c   .+�5       �� -   5         ��Name$ SaveUserButton��5       $��Сохранить��6-   $��5q�6A   5!      �� 5"      -   5        $ CancelButton��5"      $��Отмена��6+   $��5q�6<   5#      5$      5%      5&      