   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Diplom_StorageDiplom_Storage  5   	       Diplom_Storage.AddToSklad   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Diplom_Storage     5   	     � Title$  
AddToSklad��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $	��ID:��6   $��5q�6   $��Center=�6*   �� 5   
   $��1��6   $��Количество:��6!   $��5q�64   $��Center=�6?   �� 5   
   -   5         ��Name$ IdLabel��5       $��1��6   $��5q�61   $��Center=�6<   �� 5   
   -   5        $ QuantityLabel��5   -   $��1��6   $��1��6   $��5q�6D   $��Center=�6O   �� 5   
   $��2��6   $,��&Добавить количество:��6!   $��5q�6=   $��Center=�6H   �� 5   
   -   5         ��Name$ AddQuantityTextBox��5   /   $��2��6   $��1��6   $��5q�6K   $��Center=�6V   �� 5   
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��5q�6g   .+�5      �� -   5        $��Отмена��5      $��5q�6&   61   �� 5      -   5        $
��ОК��5      $��5q�6"   6-   5      5       5!      