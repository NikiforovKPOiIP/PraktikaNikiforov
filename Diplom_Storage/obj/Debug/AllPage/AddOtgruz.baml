   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5   	   &     Diplom_Storage.AllPage.AddOtgruz   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Diplom_Storage.AllPage     5   	     � Title$  	AddOtgruz��5   	   $	��450��6   $	��800��6(   .��5	      � $��10q�6   
������� � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $"��Выберите товар:��6   $��0 0 5 0q�6+   $��0��6<   $��0��6I   $��Center=�6Y   �� 5   
   -   5         ��Name$ ProductComboBox��5   0   $��0��6   $��2��6     �� DisplayMemberPath$
 Name��6j   ��6J   �� *	Product+6j   �� 5   
   $��Количество:��6   $��0 10 5 0q�6'   $��1��69   $��0��6F   $��Center=�6V   �� 5   
   -   5         ��Name$ QuantityTextBox��5      $��1��6+   $��1��68   $��Center=�6H   �� 5   
   -   5         ��Name$ 
SaveButton��5      $��Сохранить��6%   $��0 20 0 0q�69   $��2��6K   $��2��6X   $��Center=�6l   $��Center=�6�   6�   5      5      