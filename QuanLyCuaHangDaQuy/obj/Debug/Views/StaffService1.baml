   M S B A M L   `   `   `  ����M  IQuanLyCuaHangDaQuy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:QuanLyCuaHangDaQuy.ViewsQuanLyCuaHangDaQuy.Views  5   	   ,    &QuanLyCuaHangDaQuy.Views.StaffService1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:QuanLyCuaHangDaQuy.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	     � Title$  Service��5
   	   $
��1080��6   $��783.96��6&    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      �  � RowDefinitions 5   
   �� 5      $��65.25 �6   6-   �� 5      $��702.75 �6   6.   .+�5   
   � $��0��6   5      � 5   
   $��1��6   .+�5      � $��702.75��6   .+�5      �� $
��1080��6   $��172.5��5      $	��Top=�5      $%��\Resources\Image\CoverImage.png��5       5!      � 5$      $
��1080��6   .+�5%      �� .��5&      � $
��1080��6   $��530.25��5'      $��Bottom=�5(      .+�5*      � $��262.5��6#   $��257.25��5+      $��96.75,59.25,720.75,213.75q�5,      .+�5-   "   �� $��262.5��6*   $��257.25��5.      ���#FCC871$��0q�50      ��51      �� *test+54   #   �� 55   "   $��72��6(   $��72��56      $��95.25,41.25,95.25,144q�57      $!��\Resources\Image\Repair.png��58      5:   #   �� 5;   "   $
��Lato)�6,   $
��28.5(�5<       ���#ffffff$��84,144.75,83.5,78.5q�5?       $��REPAIR��5@       5B   #   �� 5C   "   $
��Lato)�6,   $
��8.25(�5D       $S��MMôn lái dashs asd asdfa salkasf ádd asjkdfas asdkjas safdlkjsajgm, olsdfms��5E       ���#ffffff$��67.5,198.75,68,38.5q�5H       $
��Wrap=�5I       5K   #   5L      � 5M      $��262.5��6#   $��257.25��5N      $ ��420.75,59.25,396.75,213.75q�5O      .+�5P   "   �� $��262.5��6*   $��257.25��5Q      ���#EEEEEE$��0q�5S      5T   #   �� 5U   "   $��72��6(   $��72��5V      $��95.25,41.25,95.25,144q�5W      $#��\Resources\Image\Painting.png��5X      5Z   #   �� 5[   "   $
��Lato)�6,   $
��28.5(�5\       $��PAINTING��5]       ���#000000$��66,144.75,65.5,78.5q�5_       5a   #   �� 5b   "   $
��Lato)�6,   $
��8.25(�5c       $S��MMôn lái dashs asd asdfa salkasf ádd asjkdfas asdkjas safdlkjsajgm, olsdfms��5d       ���#000000$��67.5,198.75,68,38.5q�5g       $
��Wrap=�5h       5j   #   5l      � 5m      $��262.5��6#   $��257.25��5n      $��744.75,59.25,72.75,213.75q�5o      $��Bottom=�5p      .+�5q   "   �� $��262.5��6*   $��257.25��5r      ���#FCC871$��0q�5t      5u   #   �� 5v   "   $��72��6(   $��72��5w      $��95.25,41.25,95.25,144q�5x      $$��\Resources\Image\Polishing.png��5y      5{   #   �� 5|   "   $
��Lato)�6,   $
��28.5(�5}       $��	POLISHING��5~       ���#ffffff$��57,144.75,56.5,78.5q�5�       5�   #   �� 5�   "   $
��Lato)�6,   $
��8.25(�5�       $S��MMôn lái dashs asd asdfa salkasf ádd asjkdfas asdkjas safdlkjsajgm, olsdfms��5�       ���#ffffff$��67.5,198.75,68,38.5q�5�       $
��Wrap=�5�       5�   #   5�      � 5�      $��262.5��6#   $��257.25��5�      $��96.75,375.75,720.75,0q�5�      .+�5�   "   �� $��262.5��6*   $��257.25��5�      ���#EEEEEE$��0q�5�      5�   #   �� 5�   "   $��72��6(   $��72��5�      $��95.25,41.25,95.25,144q�5�      $!��\Resources\Image\Repair.png��5�      5�   #   �� 5�   "   $
��Lato)�6,   $
��28.5(�5�       $��REPAIR��5�       ���#000000$��84,144.75,83.5,78.5q�5�       5�   #   �� 5�   "   $
��Lato)�6,   $
��8.25(�5�       $S��MMôn lái dashs asd asdfa salkasf ádd asjkdfas asdkjas safdlkjsajgm, olsdfms��5�       ���#000000$��67.5,198.75,68,38.5q�5�       $
��Wrap=�5�       5�   #   5�      � 5�      $��262.5��6#   $��257.25��5�      $��420.75,375.75,396.75,0q�5�      .+�5�   "   �� $��262.5��6*   $��257.25��5�      ���#FCC871$��0q�5�      5�   #   �� 5�   "   $��72��6(   $��72��5�      $��95.25,41.25,95.25,144q�5�      $#��\Resources\Image\Painting.png��5�      5�   #   �� 5�   "   $
��Lato)�6,   $
��28.5(�5�       $��PAINTING��5�       ���#ffffff$��66,144.75,65.5,78.5q�5�       5�   #   �� 5�   "   $
��Lato)�6,   $
��8.25(�5�       $S��MMôn lái dashs asd asdfa salkasf ádd asjkdfas asdkjas safdlkjsajgm, olsdfms��5�       ���#ffffff$��67.5,198.75,68,38.5q�5�       $
��Wrap=�5�       5�   #   5�      � 5�      $��262.5��6#   $��257.25��5�      $��744.75,375.75,72.75,0q�5�      .+�5�   "   �� $��262.5��6*   $��257.25��5�      ���#EEEEEE$��0q�5�      5�   #   �� 5�   "   $��72��6(   $��72��5�      $��95.25,41.25,95.25,144q�5�      $$��\Resources\Image\Polishing.png��5�      5�   #   �� 5�   "   $
��Lato)�6,   $
��28.5(�5�       $��	POLISHING��5�   !   ���#000000$��57,144.75,56.5,78.5q�5�       5�   #   �� 5�   "   $
��Lato)�6,   $
��8.25(�5�       $S��MMôn lái dashs asd asdfa salkasf ádd asjkdfas asdkjas safdlkjsajgm, olsdfms��5�       ���#000000$��67.5,198.75,68,38.5q�5�       $
��Wrap=�5�       5�   #   5�      5�      5�      5�      5�      5�      5�      5�      