   M S B A M L   `   `   `  ����E  AKursovaya1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kursovaya1
Kursovaya1  5          Kursovaya1.MainPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Kursovaya1  5      -   5          N� ShowsNavigationUI$  False��5
       N� Title$ MainPage��5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��8q�6.   .+�5      �� .+�5      �� -   5         ��Name$ fullNameSearchBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите ФИО��65   $��0,0,0,8q�6b      MaterialDesignTextBox#���   6s   �� 5      -   5         ��Name$ addBtn��5      $��Добавить��6)     MaterialDesignRaisedButton#���  6<   6q   5      5       �� 5"   
   $ 
Horizontal=�6   $��1��6.   $��8q�6>   .+�5#      �� .+�5$      �� -   5        $ groupSearchBox��5$      $! Введите группу��62   $��0,0,0,8q�6b   #���   6s   �� 5%      -   5        $ editBtn��5%      $ ��Редактировать��6*   #���  6B   6w   5&      5'      �� 5)   
   $ 
Horizontal=�6   $��2��6.   $��8q�6>   .+�5*      �� $��Период��6   $	��Top=�6%   $��0,0,8,0q�6=   �� 5+      .+�5,      (  "System.Windows.Controls.DatePicker  -   5          Name$ fromDateSearchBox��5,      $ С��68   $��20,0,0,0q�6[     MaterialDesignDatePicker#���  5-      $��0,0,0,8q�6P   �� 5.      -   5        $ 	deleteBtn��5.      $��Удалить��6,   #���  6>   
���  ��$��3,3,3,3q�6�   6�   5/      50      �� 52   
   $ 
Horizontal=�6   $��3��6.   $��8q�6>   .+�53      �� .+�54        -   5        $ toDateSearchBox��54      $
 По��66   $��20,0,0,0q�6Z   #���  55      $��0,0,0,8q�6P   �� 56      -	   5        $ 	searchBtn��56      $��
Поиск��6,   #���  6<   6q   57      58      &   System.Windows.Controls.DataGrid  5;   
   -
   5        	  Name$	 TestGrid��5;      $��2��6%   $��4��62   $��8q�6F   
   AutoGenerateColumns$
 False��6Q      CanUserAddRows$ False��6m      CanUserDeleteRows$ False��5<         CanUserReorderColumns$ False��6-      
IsReadOnly$
 True��6K     MaterialDesignDataGrid#���  5=         Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      -   5        studentName��,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��5?   :   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
FullName+ �� Mode$ OneWay=�  5@      -   5        	group��$ Группа��5@   4    6D   �� *Group+  5A      -   5        
discipline��$ Дисциплина��5A   9    6M   �� *
Discipline+  5B      -   5        date��$ Дата��5B   3    6A   �� *
StringDate+  5C      -   5        mark��$ Оценка��5C   3    6C   �� *Mark+5E      �� 5G   
   -   5        $ vedomostBtn��5G      $��3��6&   $��2��66   $��Bottom=�6C   $��Right=�6^   $'��!Создать ведомость��5H      #���  6-   6b   5I      5J      