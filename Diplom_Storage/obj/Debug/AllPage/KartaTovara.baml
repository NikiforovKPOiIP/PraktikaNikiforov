   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Diplom_Storage.AllPageDiplom_Storage.AllPage  5      (    "Diplom_Storage.AllPage.KartaTovara   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Diplom_Storage.AllPage     5        � 	Resources  5	         MyImage �� 	UriSource��%?   &	        �� 5
   
   $! /Resources/redactsquear.png?�6&   5      .��5      � .+�5   
   �� ��5      �� 5      6    5      �� 5   
   -   5         ��Name$ 
TovarPhoto��5      $	��250��6(   $	��250��65   $	��Top=�6B   $
��Left=�6Z   $��	40 40 0 0q�5      
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 5Q�6#      	Direction$	 250Q�63      
BlurRadius$ 10Q�6C      Opacity$	 0.9Q�6S   5      �� 5   
   -   5        $ TovarPhotoRedact��5      $	��250��6.   $	��250��6;   $	��Top=�6G   $
��Left=�6_   $��	40 40 0 0q�5      ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value

 ���� 6-    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      �� 	 � ��
 5    "   �� 5!   &    �� ImageSource$! /Resources/redactsquear.png��61    j� Stretch$ Uniform=�6[    j� 
AlignmentX$ Center=�6n    j� 
AlignmentY$ Center=�6�   5#      5$      5&      5(      �� 5)   
   -   5        $��45��5)      $
��Left=�6   $ ��Редактировать��68   $��1q�6P   
�������
�������$��15(�6�   $	��200��6�   $��65,330,0,375q�6�    ! MaterialDesignFlatLightButton#��[ 6�   6	  � 5*   
   $	��370��6   $��Right=�6   $��
0 40 250 0q�68    � Cursor$  ��6L   .+�5,      �� $
��Left=�6   $	��Top=�63   $��50��6K   $��30(�6W   $��Calibri)�6e   $#��Данные о товаре:��6{   
���������5.      }�  }� Location$ 	Underline=�6%   50      �� 51      $
��Left=�6   $	��150��64   $��0 50 0 0q�6@   .+�52      ��  �� TextAlignment$
 Left=�6   $��Название: ��62   
�������$��30��6W   $��20(�6c   $
��Bold"�6q   $��Calibri)�6�   6�   �� 53      $
 Left=�6   $��Категория: ��63   
�������$��30��6Y   $��20(�6e   $
��Bold"�6s   $��Calibri)�6�   6�   �� 54      $
 Left=�6   $��Серия: ��63   
�������$��30��6U   $��20(�6a   $
��Bold"�6o   $��Calibri)�6�   6�   �� 55      $
 Left=�6   $��Поставщик: ��63   
�������$��30��6Y   $��20(�6e   $
��Bold"�6s   $��Calibri)�6�   6�   56      �� 57      $��Right=�6   $	��200��65   $��0 50 0 0q�6A   .+�58      �� -   5         ��Name$
 Name��58      
�������$��30��6T   $��20(�6`   $��Calibri)�6n   ��6+   �� *Name+6�   �� 59      -   5        $ Category��59      
�������$��30��6`   $��20(�6l   $��Calibri)�6z   ��6.   �� *Category.Name+6�   �� 5:      -   5        $ Seria��5:      
�������$��30��6Z   $��20(�6f   $��Calibri)�6t   ��6+   �� *
Seria.Name+6�   �� 5;      -   5        $ 
Postavchik��5;      
�������$��30��6^   $��20(�6j   $��Calibri)�6x   ��60   �� *	SUPP.Name+6�   �� 5<      -   5        $ Status��5<      
�������$��30��6b   $��20(�6n   $��Calibri)�6|   ��6,   �� *MinimalKolvo.Name+6�   5=      5>      5?      5@      