   M S B A M L   `   `   `  ����I  EDiplom_Storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Diplom_StorageDiplom_Storage  5      E AFluentWPF, Version=0.10.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5      E ABlurWindow, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null=-clr-namespace:TianXiaTech;assembly=BlurWindowTianXiaTech 5      R NClosedXML, Version=0.100.3.0, Culture=neutral, PublicKeyToken=fd1eb21b62ae805bD0clr-namespace:ClosedXML.Excel;assembly=ClosedXMLClosedXML.Excel 5	      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5          Diplom_Storage.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:Diplom_Storage     5      Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5      Jmedia8using:Microsoft.UI.Xaml.Media;assembly=Microsoft.UI.Xaml     5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >
blurwindow-clr-namespace:TianXiaTech;assembly=BlurWindow  5      ;clxl0clr-namespace:ClosedXML.Excel;assembly=ClosedXML  5	      RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5        �� 	Resources  5       �� MergedDictionaries �� Source   Neon �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   Opacity	 �� Triggers
 P� Property P� Value  SelectedRowStyle)  #System.Windows.Controls.DataGridRow  ButtonStyleWin10 J� SnapsToDevicePixels �� StrokeDashArray % !CustomMaterialDesignFlatButtonRed  MaterialDesignFlatButton �� BasedOn �� 	Resources  Key �� Color + 'CustomMaterialDesignFlatButtonLightGrey  DataGridCellStyle*  $System.Windows.Controls.DataGridCell �� RelativeSource �� 
TargetType �� AncestorType&   System.Windows.Controls.DataGrid ^� 
Conditions �� Binding �� Value  DataGridRowStyle ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility:  4System.Windows.Controls.Primitives.DataGridRowHeader7	  1System.Windows.Controls.DataGridHeadersVisibility
 	  Row �� ConverterParameter!   HeadersVisibilityConverter �� 	Converter=
  7System.Windows.Controls.Primitives.DataGridColumnHeader &	 "MaterialDesignDataGridColumnHeader 
 
menuButton  �� CornerRadius�� 5   
    5      �� 5      $E ?pack://application:,,,/FluentWPF;component/Styles/Controls.xaml?�6%   �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   %�  &	        &	 G    &	     &	 �    7  &	 }    7  &	 5    &	     '
  k    7 	 &	
 �    �� 5      " ��6!   .�5      ��  �@J�Effect 5        5      $ 0Q�6+   $ Transparent��6:   $ 0Q�6N   5      	 5      P� 5      
 �@J�IsMouseOver . . �5      ��  �@J�Effect 5        5   "   $ 20Q�63   $ White��6C   $	 0.9Q�6Q   5!      5"      5$      �� 5%      "  6-   .�5&      ��  � ��
 ���� 60   �� 5'       � ��$ 1q�64   	 5(      P� 5)      
 �@ 
IsSelected . . �5*      ��  � ��
 ��  �68   5+      5-      �� 5.      .�5/      ��  � �� 51      �� 52      .R�53      �� $��2q�6(    . #��� ��6N   $��1��6�   $	 1 2R�6�   54      56      57      �� 58      8   " ��5:       5;      ����5<      PrimaryHueMidBrushColor #FF404C��6E   �� 5=      PrimaryHueMidBrush $ #FF404C��6A   5>      5?      �� 5@      8   " ��5B       5C      ����5D      PrimaryHueMidBrushColor #999999��6E   �� 5E      PrimaryHueMidBrush $ #999999��6A   5F      5G      �� 5H      "  6.   .�5I      ��  � ��
 ���� 6/   �� 5J       � ��
 ���� 60   �� 5K       � ��
 �����6/   �� 5L       � �� 6,   �� *" (wpf:DataGridAssist.CellPadding)+ �� *Self+�� 5M       � �� 5N      �� 5O      "  6*   .R�5P      � .+�5Q   "   �� #��z��6)   #��z��6S   #��z��6    . 6�   �� 5R   "   #��z��63   # z 6V   5S      5T      5V      �� 5W       �@=�ErrorTemplate 6=   Z� 	 5X      P� 5Y      
 �@J�IsKeyboardFocusWithin . . �5Z      ��  � �� 68   �� *.,(wpf:DataGridAssist.SelectedCellBorderBrush)+ �� "  5[      ^� 5\       5]      �� 5^       6(   �� *
IsSelected+ �� *Self+ True6m   �� 5_       6(   �� *IsMouseOver+ �� "  	 False6�   .0�5a      ��  � ��
 ���� 67   5b      P� 5c      
 � {� .  . �5d      ��  �@J�Opacity$	 .56Q�64   5e      5g      �� 5h      "  6-   .�5i      ��  � ��
 ���� 6/   �� 5j       �@J�SnapsToDevicePixels . 68   �� 5k       � �� 5l      �� 5m      "  6*   .R�5n      �� $ 
DGR_Border��6%   #��z��69   #��z��6c   #��z��6�    . ._�5o   "      5p   &   �� 5q   *   $
��Auto �6;   �� 5r   *   $��* �6;    5t   &   �� 5u   *   $��* �68   �� 5v   *   $
��Auto �68   .+�5x   &     $��1��6=   #��z 6M   # z 6w     5y   &   $��1��6?   $��1��6O   #y�z 6\     5z   &   $��0��68   $��2��6H   $��0��6Y   y�6f   �� *HeadersVisibility+# Z # Z  �� "  5{   #   5|      5}      5      �� 5�       �@=�ErrorTemplate 6=   Z� �� 5�       �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      �� ���#d50000$��2,0,0,0q�6=   $��!��6N   $��Center=�6W   5�      5�      	 5�      P� 5�      
 �@ 
IsSelected . . �5�      ��  � ��$ 1q�6<   �� 5�       � ��
 �����68   �� 5�       � �� �#45454567   5�      P� 5�      
 �@J�IsMouseOver . . �5�      ��  � ��$ 2q�6<   �� 5�       � ��
 �����68   �� 5�       � �� �#45454567   5�      P� 5�      
 �@ 	IsNewItem . . �5�      ��  � �� 63   �� *NewItemMargin+ �� "  5�      5�      �� 5�      " 
 6   8   .�5�      ��  � ��
 �����6/   5�      �� 5�      " 	�6'   .�5�      ��  � ��
 ���� 6/   �� 5�       � ��
 �����6/   �� 5�       � �� 5�      �� 5�      " 	�6*   .R�5�      �� #��z��6%   ���#36373A$  3��5�   3   ._�5�   "   �� $
��Left=�63   $��Center=�6N   5�      5�      5�      	 5�      P� 5�      
 �@J�IsMouseOver . . �5�      ��  � �� �#40414367   �� 5�       � ��
 �����67   5�      P� 5�      
 �@d�	IsChecked$
 TrueY�63   . �5�      ��  � �� �#58595B67   �� 5�       � ��
 �����67   �� 5�       � ��
 �����68   5�      5�      5�      5�      