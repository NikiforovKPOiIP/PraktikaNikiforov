   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5   	   %    Diplom_Storage.AllPage.AddTovar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Diplom_Storage.AllPage     5   	     � Title$  EditKartaWindow��5      $	��450��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��0��6   $��Категория:��6-   �� 5   
   -   5         ��Name$ ComboBoxTcategory��5   L   $��1��6   $��1��6     �� Text 60   �� *
first_name+6L   �� 5   
   $��2��6   $��0��6   $��Название��6-   �� 5    
   -   5         ��Name$ tname��5    /   $��2��6   $��1��6   6/   �� 5!   
   $��3��6   $��0��6   $��Серия:��6-   �� 5"   
   -   5        $ ComboBoxSeria��5"   L   $��3��6   $��1��6     60   �� *
patronymic+6L   �� 5#   
   $��4��6   $��0��6   $��Поставщик:��6-   �� 5$   
   -   5        $ ComboBoxSupp��5$   G   $��4��6   $��1��6     60   �� *phone+6G   �� 5%   
   $��5��6   $��0��6   $��Статус:��6-   �� 5&   
   -   5        $ ComboBoxStatus��5&   G   $��5��6   $��1��6     60   �� *phone+6G   �� 5'   
   $��6��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   .+�5(      �� -   5        $
��Save��5(      $	��100��6$   $��5q�60   6;   �� 5)      -   5        $��Cancel��5)      $	��100��6&   $��5q�62   6=   5*      5+      5,      