   M S B A M L   `   `   `  ����M  IQuanLyCuaHangDaQuy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems2QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems  5   	   M+clr-namespace:QuanLyCuaHangDaQuy.ViewModelsQuanLyCuaHangDaQuy.ViewModels  5	   N   1    +QuanLyCuaHangDaQuy.Views.Staff.CheckOutBill   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Rlocal@clr-namespace:QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6S   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   4vm+clr-namespace:QuanLyCuaHangDaQuy.ViewModels  6N   -   5          �Name$  BillListImportedClose��5   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	   $��762.66��5   	   $
��1000��6   $
��Lato)�6&    � DataContext 5      2   ,QuanLyCuaHangDaQuy.ViewModels.CheckOutBillVM  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      � -   5         �Name$ print��5      	 � RowDefinitions	 5   
   �� 5      $	��219 �6   6+   �� 5      $��38 �6   6*   �� 5      $��* �6   6)   �� 5      $	��150 �6   6+   
 � ColumnDefinitions
 5   
   �� 5      $��29 �6   6,   �� 5      $��* �6   6+   �� 5       $��29 �6   6,   .+�5"   
   �� -   5         ��Name$ Closee��5)      $��2��5"      $��-30,13,13,0q�5#      $	��Top=�5$      $��Right=�5%      $��40��5&      $��0q�5'      $��40��5(      
������ $��0q�5+       5,        5-      $ Click��6!   . 5.      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ Close��6e      TargetObject 6*   ��  �� ElementName$ BillListImportedClose��6e   5/      .��51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   ���#BCBCBC$��Center=�53   &   $��Center=�54   &   $��40��55   &   $��40��56   &   57      �� 58   
   -   5        $��1��58      $��Bottom=�59      $��50��5:      $��Right=�5;      $��0 0 0 10q�5<      
������ $��1q�5>      
���   �$��0q�5@      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5B      .��5E        $ Printer=�6&   $��32��5F   &   $��50��5G   &   5H      �� 5I   
   $��0��5J      $��	0 17 0 56q�5K      $	��146��5L      $��1��5M      $"��/Resources\Image\madlife.png��5N      65   �� 5O   
   $��1��6   $��1��5P      ���#5858585R      &	   System.Windows.Controls.DataGrid	  5S   
   $��1��5T      $��2��5U      $��1��5V      {�.  
������ $
��auto��5Z       	  AutoGenerateColumns .  ��5X      �� *ListCartBill+ 	  Columns 5]      0
  *System.Windows.Controls.DataGridTextColumn
  5^      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *No+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   
  5_      $ Category��6%   $ * 67    6A   �� *
Category+$ TwoWay=�$ PropertyChanged=�6�   
  5`      $ Product��6%   $ * 66    6@   �� *	Product+$ TwoWay=�$ PropertyChanged=�6�   
  5a      $ Quantity��6%   $ 85 67    6B   �� *
Quantity+$ TwoWay=�$ PropertyChanged=�6�   
  5b      $
 Unit��6%   $	 150 63    6?   �� *Unit+$ TwoWay=�$ PropertyChanged=�6�   
  5c      $ 
Unit price��6%   $	 150 69    6E   �� *	UnitPrice+$ TwoWay=�$ PropertyChanged=�6�   
  5d      $ Amount��6%   $	 150 65    6A   �� *Amount+$ TwoWay=�$ PropertyChanged=�6�    � 	Resources 5f      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�  '        '  :    �� 5g      "  6   .�5h      ��  � ��$ Center=�6<   6M   �� 5i       � ��$ 38��6/   6<   �� 5j       � �� �#5858586E   �� 5k       � ��
 �����6C   �� 5l       � ��$
 Lato)�63   �� 5m       � ��$ 18(�61   �� 5n       � ��$
 Bold"�63   5o      �� 5p      "  6   .�5q      ��  � ��
 �   �6C   �� 5r       � ��$ 13(�61   �� 5s       � ��$ Center=�6<   �� 5t       � ��$ 34��6/   �� 5u       � ��$ Center=�6:   �� 5v       � ��$ 0,13,0,0q�6/   �� 5w       � {� . 62   �� 5x       � ��$ 0q�68   �� 5y       � ��
 ���� 63   5z      5{      5}      �� 5   
    �� Orientation$ Vertical=�6   $��0��5�      $��1��5�      .+�5�      �� $��PURCHASE RECEIPT��6   $��37.24(�5�      $��	0 30 0 27q�5�      $
��Lato)�5�      
���   �5�      �� 5�      $��24(�5�      $
��Lato)�5�      $��0 0 0 10q�5�      
���   ���5�      �� *ID+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��24(�5�      $
��Lato)�5�      
���   ���5�      �� *Today+$ TwoWay=�$ PropertyChanged=�5�      5�      5�      5�      