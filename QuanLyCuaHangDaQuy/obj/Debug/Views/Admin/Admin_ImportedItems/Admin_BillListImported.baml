   M S B A M L   `   `   `  ����M  IQuanLyCuaHangDaQuy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems2QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems  5   	   M+clr-namespace:QuanLyCuaHangDaQuy.ViewModelsQuanLyCuaHangDaQuy.ViewModels  5   	   O    IQuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems.Admin_BillListImported   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Rlocal@clr-namespace:QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   4vm+clr-namespace:QuanLyCuaHangDaQuy.ViewModels  5   	   -   5          �Name$  BillListImportedClose��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��762.66��5   	   $
��1000��6    � DataContext 5      <   6QuanLyCuaHangDaQuy.ViewModels.Admin_BillListImportedVM  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      � -   5         �Name$ print��5      	 � RowDefinitions	 5   
   �� 5      $	��219 �6   6+   �� 5      $��38 �6   6*   �� 5      $��* �6   6)   �� 5      $��90 �6   6*   
 � ColumnDefinitions
 5   
   �� 5       $��15 �6   6,   �� 5!      $��* �6   6+   �� 5"      $��15 �6   6,   .+�5$   
   �� -   5         ��Name$ Closee��5+      $��2��5$      $��-30,13,13,0q�5%      $	��Top=�5&      $��Right=�5'      $��40��5(      $��0q�5)      $��40��5*      
������ $��0q�5-       5.        5/      $ Click��6!   . 50      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ Close��6e      TargetObject 6*   ��  �� ElementName$ BillListImportedClose��6e   51      .��53      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   ���#BCBCBC$��Center=�55   &   $��Center=�56   &   $��40��57   &   $��40��58   &   59      �� 5:   
   -   5        $��1��5:      $��Bottom=�5;      $��50��5<      $��Right=�5=      $��0 0 0 10q�5>      
������ $��1q�5@      
���   �$��0q�5B      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5D      .��5G        $ Printer=�6&   $��32��5H   &   $��50��5I   &   5J      �� 5K   
   $��0��5L      $��	0 17 0 56q�5M      $	��146��5N      $��1��5O      $"��/Resources\Image\madlife.png��5P      65   �� 5Q   
   $��1��6   $��1��5R      ���#5858585T      &	   System.Windows.Controls.DataGrid	  5U   
   $��1��5V      $��2��5W      $��1��5X      {�.  
������ $
��auto��5\       	  AutoGenerateColumns .  ��5Z      �� *BillListItemImport+ 	  Columns 5_      0
  *System.Windows.Controls.DataGridTextColumn
  5`      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *No+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   
  5a      $ Category��6%   $ * 67    6A   �� *
Category+$ TwoWay=�$ PropertyChanged=�6�   
  5b      $ Product��6%   $ * 66    6@   �� *	Product+$ TwoWay=�$ PropertyChanged=�6�   
  5c      $ Quantity��6%   $ 85 67    6B   �� *
Quantity+$ TwoWay=�$ PropertyChanged=�6�   
  5d      $
 Unit��6%   $	 150 63    6?   �� *Unit+$ TwoWay=�$ PropertyChanged=�6�   
  5e      $ 
Unit price��6%   $	 150 69    6E   �� *	UnitPrice+$ TwoWay=�$ PropertyChanged=�6�   
  5f      $ Amount��6%   $	 150 65    6A   �� *Amount+$ TwoWay=�$ PropertyChanged=�6�    � 	Resources 5h      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�  '        '  :    �� 5i      "  6   .�5j      ��  � ��$ Center=�6<   6M   �� 5k       � ��$ 38��6/   6<   �� 5l       � �� �#5858586E   �� 5m       � ��
 �����6C   �� 5n       � ��$
 Lato)�63   �� 5o       � ��$ 18(�61   �� 5p       � ��$
 Bold"�63   5q      �� 5r      "  6   .�5s      ��  � ��
 �   �6C   �� 5t       � ��$ 13(�61   �� 5u       � ��$ Center=�6<   �� 5v       � ��$ 34��6/   �� 5w       � ��$ Center=�6:   �� 5x       � ��$ 0,13,0,0q�6/   �� 5y       � {� . 62   �� 5z       � ��$ 0q�68   �� 5{       � ��
 ���� 63   5|      5}      5      �� 5�   
    �� Orientation$ Vertical=�6   $��0��5�      $��1��5�      .+�5�      �� $��PURCHASE RECEIPT��6   $��37.24(�5�      $��	0 30 0 27q�5�      $
��Lato)�5�      
���   �5�      �� 5�      $��24(�5�      $
��Lato)�5�      $��0 0 0 10q�5�      
���   ���5�      �� *ID+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��24(�5�      $
��Lato)�5�      
���   ���5�      �� *Today+$ TwoWay=�$ PropertyChanged=�5�      5�      �� 5�   
   $ Vertical=�6   $��0��5�      $��Right=�5�      $��0 0 50 0q�5�      $��1��5�      .+�5�      �� $��	Provider:��6   $��20(�5�      $��	0 45 0 15q�5�      $
��Lato)�5�      ���#EEEEEE$��Right=�5�      
���   �5�      �� 5�      $��25(�5�      $
��Lato)�5�      $��SemiBold"�5�      $��Right=�5�      $��0 0 0 14q�5�      
���   ���5�      �� *Name+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��18(�5�      $��Right=�5�      $
��Lato)�5�      $��0 0 0 5q�5�      
���   ���5�      �� *Adress+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��18(�5�      $��Right=�5�      $
��Lato)�5�      
���   ���5�      �� *Phone+$ TwoWay=�$ PropertyChanged=�5�      5�      5�      5�      