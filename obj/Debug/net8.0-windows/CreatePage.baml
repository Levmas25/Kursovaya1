   M S B A M L   `   `   `  ����E  AKursovaya1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kursovaya1
Kursovaya1  5          Kursovaya1.CreatePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Kursovaya1  5        N� Title$  
CreatePage��5
      .��5      � -   5         �Name$
 main��5      .+�5   
   �� -   5         ��Name$ backBtn��5      $��
Назад��6"      MaterialDesignRaisedButton#���   62   $
��Left=�5   '   $	��Top=�6B   $��16q�6Z   �� 5   
   $��16q�6   .+�5      �� -   5         ��Name$ 	DataPanel��5      $	��200��6,   .+�5      �� -   5         ��Name$ fullName��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите ФИО��5        MaterialDesignTextBox#���  5      $��0,0,0,8q�5      ��5      �� *
FullName+ �� Mode$ OneWay=�5      �� 5      -   5        $ group��5      $! Введите группу��5      #���  5      $��0,0,0,8q�5      ��5      �� *Group+$ TwoWay=�5      �� 5      -   5        $ 
discipline��5      $) #Введите дисциплину��5      #���  5      $��0,0,0,8q�5       ��5      �� *
Discipline+$ TwoWay=�5       (  "System.Windows.Controls.DatePicker  5!      -   5          Name$
 date��5!        MaterialDesignDatePicker#���  5#   !   $��0,0,0,8q�5$   !      SelectedDate 5"   !   �� *
DateTime+$ OneWay=�5$   !   �� 5%      -   5        $
 mark��5%      $! Введите оценку��5&      #���  5(      $��0,0,0,8q�5)      ��5'      �� *Mark+$ TwoWay=�5)      5*      �� 5+      -	   5        $ saveBtn��5+      $��Сохранить��5,      #���   5-      $��Right=�5/      50      52      53      