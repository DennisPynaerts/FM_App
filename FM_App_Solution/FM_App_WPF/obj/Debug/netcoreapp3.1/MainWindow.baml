   M S B A M L   `   `   `  ����E  AFM_App_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FM_App_WPF
FM_App_WPF  5   	       FM_App_WPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:FM_App_WPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	Forza App��5	   	   $	��600��6   $	��800��6(   .��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ lstClass��5      $��0��6$   $��2��64   $��0��6H   $��5��6U   $��5q�6f   6s   �� 5!   
   -   5         ��Name$ txtSearchTerm��5!   q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Track��6   $��0��6@   $��2��6M   $��2��6]    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Center=�6�   $��Verdana)�6�   $��5q�6
  ��6�   Z�  �� 
CaretBrush 6  Z�  �� SelectionBrush 6+  Z� �� 5#   
   $��2��6   $��2��6&   $��1��6:    �� Orientation$ 
Horizontal=�6G   $��Stretch=�6`   .+�5$      	� -   5        	 	�Name$	 rbDay��5$   5   
 	� 	GroupName$
 
grpWeather��6   $	��Day��6D   $��	20,5,20,5q�6R    d� 	IsChecked$
 TrueY�6e   
���   ���6�   Z� 	� 5%      -   5        $	 rbRain��5%   5   $
 
grpWeather��6   $
��Rain��6E   $��	20,5,20,5q�6T   
���   ���6z   Z� 	� 5&      -   5        $	 rbNight��5&   5   $
 
grpWeather��6   $��Night��6F   $��	20,5,20,5q�6V   
���   ���6|   Z� 5'      �� 5)   
   -   5         ��Name$ 	btnSearch��5)      $��Search��6$   $��2��65   $��2��6B   $��2��6R   $��5q�6f   6q   �� 5+   
   -   5         ��Name$ 	cmbTracks��5+      $��3��6&   $��2��63   $��2��6C   $��5q�6W   6d   �� 5,   
   -   5        $ cmbCars��5,      $��4��6$   $��2��61   $��2��6A   $��5q�6U   6b   �� 5.   
   $ 
Horizontal=�6   $��6��6.   $��0��6;   $��4��6K   $��Center=�6_   .+�5/      �� -	   5        $ txtManufacturer��5/   D   $ Manufacturer��6   #��[  6]   $��Center=�6�   $��Verdana)�6�   $��5,5,5,5q�6�   $��Stretch=�6   $	��180��6E  ��6�   Z�  6�   Z�  6  Z� 6E  �� 50      -
   5        $ txtModel��50   =   $ Model��6   #��[  6O   $��Center=�6�   $��Verdana)�6�   $��5q�6�   $	��180��6  ��6�   Z�  6�   Z�  6�   Z� 6  �� 51      -   5        $ txtHandling��51   @   $ Handling��6   #��[  6U   $��Center=�6�   $��Verdana)�6�   $��5q�6�   $	��180��6  ��6�   Z�  6�   Z�  6�   Z� 6  �� 52      -   5        $ txtPI��52   :   $ PI��6   #��[  6I   $��Center=�6�   $��Verdana)�6�   $��5q�6�   $	��180��6  ��6�   Z�  6�   Z�  6�   Z� 6  54      �� 56   
   -   5        $ btnClear��56      $��	Clear All��6#   $��7��67   $��0��6D   $��2��6T   $��5q�6h   6�   �� 57   
   -   5        $ btnSubmitCar��57      $��
Submit Car��6'   $��7��6<   $��2��6I   $��2��6Y   $��5q�6m   6�   �� 58   
   -   5        $ btnDeleteCar��58      $��
Delete Car��6'   $��8��6<   $��2��6I   $��2��6Y   $��5q�6m   6�   �� 5:   
   -   5        $ 
txtLaptime��5:   �   $! Laptime (Format: 00.00.000)��6   $��9��6O   $��0��6\   $��2��6l   #��[  6�   $��Center=�6�   $��Verdana)�6   $��5q�6  ��6�   Z�  6!  Z�  67  Z� �� 5;   
   -   5        $ btnSubmitLaptime��5;      $��Submit Laptime��6+   $��9��6D   $��2��6Q   $��2��6a   $��5q�6u   6�   �� 5=   
   -   5        $ btnLeaderboard��5=      $��Show Leaderboard��6)   $��10��6D   $��0��6R   $��4��6b   $��5q�6v   6�   5>      5?      