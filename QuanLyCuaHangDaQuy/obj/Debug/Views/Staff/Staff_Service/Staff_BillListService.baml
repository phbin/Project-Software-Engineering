   M S B A M L   `   `   `  ����M  IQuanLyCuaHangDaQuy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:QuanLyCuaHangDaQuy.Views.Staff.Staff_Service,QuanLyCuaHangDaQuy.Views.Staff.Staff_Service  5   	   M+clr-namespace:QuanLyCuaHangDaQuy.ViewModelsQuanLyCuaHangDaQuy.ViewModels  5   �   H    BQuanLyCuaHangDaQuy.Views.Staff.Staff_Service.Staff_BillListService   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:QuanLyCuaHangDaQuy.Views.Staff.Staff_Service     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6T   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   4vm+clr-namespace:QuanLyCuaHangDaQuy.ViewModels  6�   -   5          �Name$  BillListReceiptClose��5
   	    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5   	   $��762.66��5   	   $
��1000��6    � DataContext 5      ;   5QuanLyCuaHangDaQuy.ViewModels.Staff_BillListServiceVM  5   
   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      � -   5         �Name$ print��5      	 � RowDefinitions	 5   
   �� 5      $	��219 �6   6+   �� 5      $��38 �6   6*   �� 5      $��* �6   6)   �� 5      $��90 �6   6*   
 � ColumnDefinitions
 5   
   �� 5      $��15 �6   6,   �� 5      $��* �6   6+   �� 5       $��15 �6   6,   .+�5"   
   �� -   5         ��Name$ Closee��5)      $��2��5"      $��-30,13,13,0q�5#      $	��Top=�5$      $��Right=�5%      $��40��5&      $��0q�5'      $��40��5(      
������ $��0q�5+       5,        5-      $ Click��6!   . 5.      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ Close��6d      TargetObject 6*   ��  �� ElementName$ BillListReceiptClose��6d   5/      .��51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   ���#BCBCBC$��Center=�53   &   $��Center=�54   &   $��40��55   &   $��40��56   &   57      �� 58   
   -   5        $��1��58      $��Bottom=�59      $��50��5:      $��Right=�5;      $��0 0 0 10q�5<      
������ $��1q�5>      
���   �$��0q�5@      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5B      .��5E        $ Printer=�6&   $��32��5F   &   $��50��5G   &   5H      �� 5I   
   $��0��5J      $��	0 17 0 56q�5K      $	��146��5L      $��1��5M      $"��/Resources\Image\madlife.png��5N      65   �� 5O   
   $��1��6   $��1��5P      ���#5858585R      &	   System.Windows.Controls.DataGrid	  5S   
   $��1��5T      $��2��5U      $��1��5V      {�.  
������ $
��auto��5Z       	  AutoGenerateColumns .  ��5X      �� *ListBillService+ 	  Columns 5]      0
  *System.Windows.Controls.DataGridTextColumn
  5^      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *No+6X   
  5_      $ Service��6%   $ 75 66    6A   �� *	Service+6a   
  5`      $ 
Unit Price��6%   $	 110 69    6E   �� *	UnitPrice+6f   
  5a      $ Price discounted��6%   $	 140 6?    6K   �� *PriceDiscounted+6s   
  5b      $ Quantity��6%   $ 75 67    6B   �� *
Quantity+6c   
  5c      $ Amount��6%   $	 100 65    6A   �� *Amount+6_   
  5d      $ Pre pay��6%   $	 100 66    6B   �� *Prepay+6a   
  5e      $ Remain��6%   $	 100 65    6A   �� *Remain+6_   
  5f      $ Return date��6%   $	 100 6:    6F   �� *
ReturnDate+6i   
  5g      $ Status��6%   $ 70 65    6@   �� *Stt+6[    � 	Resources 5k      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�  '        '  ;    �� 5l      "  6   .�5m      ��  � ��$ Center=�6<   6M   �� 5n       � ��$ 38��6/   6<   �� 5o       � �� �#5858586E   �� 5p       � ��
 �����6C   �� 5q       � ��$  Lato)�63   �� 5r       � ��$ 18(�61   �� 5s       � ��$
 Bold"�63   5t      �� 5u      "  6   .�5v      ��  � ��
 �   �6C   �� 5w       � ��$ 13(�61   �� 5x       � ��$ Center=�6<   �� 5y       � ��$ 34��6/   �� 5z       � ��$ Center=�6:   �� 5{       � ��$ 0,13,0,0q�6/   �� 5|       � {� . 62   �� 5}       � ��$ 0q�68   �� 5~       � ��
 ���� 63   5      5�      5�      �� 5�   
    �� Orientation$ Vertical=�6   $��3��5�      $��1��5�      .+�5�      �� $��24(�5�      $��0 15 0 7q�5�      $
��Lato)�5�      
���   ���5�      �� *TotalPrepay+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�      �� 5�      $��24(�5�      $
��Lato)�5�      
���   ���5�      �� *TotalRemain+$ TwoWay=�$ PropertyChanged=�5�      5�      �� 5�   
   $ Vertical=�6   $��0��5�      $��1��5�      .+�5�      �� $��RECEIPT��6   $��37.24(�5�      $��	0 30 0 27q�5�      $
��Lato)�5�      
���   �5�      �� 5�      $��24(�5�      $
��Lato)�5�      $��0 0 0 10q�5�      
���   ���5�      �� *ID+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��24(�5�      $
��Lato)�5�      
���   ���5�      �� *Today+$ TwoWay=�$ PropertyChanged=�5�      5�      �� 5�   
   $ Vertical=�6   $��0��5�      $��Right=�5�      $��0 0 50 0q�5�      $��1��5�      .+�5�      �� $��Invoice to:��6   $��20(�5�      $��	0 45 0 15q�5�      $
��Lato)�5�      ���#EEEEEE$��Right=�5�      
���   �5�      �� 5�      $��25(�5�      $
��Lato)�5�      $��SemiBold"�5�      $��Right=�5�      $��0 0 0 10q�5�      
���   ���5�      �� *NameCustomer+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��24(�5�      $��Right=�5�      $
��Lato)�5�      
���   ���5�      �� *Phone+$ TwoWay=�$ PropertyChanged=�5�      5�      5�      5�      