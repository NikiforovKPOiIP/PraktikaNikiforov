   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5   	   )    #Diplom_Storage.AllPage.EditUserKab2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Diplom_Storage.AllPage     5   	   -   5          � Title$  EditUserKab��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
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
   �� $��1��6   $��0��6   $��First Name:��6-   �� 5   
   -   5         ��Name$ fname��5   K   $��1��6   $��1��6   ��6/   �� *
first_name+6K   �� 5   
   $��2��6   $��0��6   $��
Last Name:��6-   �� 5    
   -   5        $ lname��5    J   $��2��6   $��1��6   ��6/   �� *	last_name+6J   �� 5!   
   $��3��6   $��0��6   $��Patronymic:��6-   �� 5"   
   -   5        $ patron��5"   K   $��3��6   $��1��6   ��6/   �� *
patronymic+6K   �� 5#   
   $��4��6   $��0��6   $��Phone:��6-   �� 5$   
   -   5        $ phoneus��5$   F   $��4��6   $��1��6   ��6/   �� *phone+6F   �� 5%   
   $��5��6   $��0��6   $��Email:��6-   �� 5&   
   -   5        $
 mail��5&   F   $��5��6   $��1��6   ��6/   �� *email+6F   �� 5'   
   $��6��6   $��0��6   $��Date of Birth:��6-   (  "System.Windows.Controls.DatePicker  5(   
   -   5          Name$ dr��5(   Y   $��6��6   $��1��6"      SelectedDate 62   �� *date_of_birth+6Y   �� 5)   
   -   5        $��7��5)      $��1��6   $
��Save��6.   6=   �� 5*   
   -	   5        $��8��5*      $��1��6   $��Cancel��6.   6?   5+      5,      