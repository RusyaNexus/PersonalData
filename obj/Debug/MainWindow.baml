   M S B A M L   `   `   `  ����G  CPersonalData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PersonalData.ConvertorsPersonalData.Convertors  5   	       PersonalData.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <
converters%clr-namespace:PersonalData.Convertors     5   	     � Title$+  %Персональные данные��5   	    � Icon$ favicon.ico��5	   	   $	��700��5
   	   $	��700��5   	   $	��850��5   	   $	��850��5   	    � 
ResizeMode$ CanMinimize=�5   	    � 	Resources 5      8   2PersonalData.Convertors.SexEnumTypeToListConverter   SexEnumTypeToListConverter��%   &	          5   
   60   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��
textFilter��5       �� 	MaxLength$ 30��6I   � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
lvAccounts��5         
IsReadOnly .    AutoGenerateColumns .     Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 auto 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Id+  5"      $	 Фамилия��6)   $

 auto 6:    6G   �� *	Surname+  5#      $	 Имя��6)   $

 auto 66    6C   �� *Name+  5$      $	 Отчество��6)   $

 auto 6;    6H   �� *
MiddleName+  5%      $	 Пол��6)   $

 auto 66    6C   �� *Gender+ �� 	Converter# [    5&      $	 Дата рождения��6)   $

 auto 6@    6M   �� *
Birthday+ �� StringFormat$ 
yyyy-MM-dd��  5'      $	 
Почта��6)   $

 auto 68      
Foreground
 ��  � 6E   �� *Email+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5(         CellTemplate 5)      �� 5*      .R�5+   "   �� -   5        $��0q�5+   )   $��Изменить��6>    � DataContext 6e   �� 5,      5.        5/       50      �� 51      .R�52   "   �� -   5        $��0q�52   )   $��X��6>    6`   �� 53      55         RowDetailsTemplate 57      �� 58      .R�59      �� $��0q�6!   
������� �� Padding$ 10q�6Q   ._�5:      ��  �� Orientation$ Vertical=�6)   .+�5;   "   �� $ 
Horizontal=�6-   .+�5<   &   �� $��12(�60   $��Страна: ��6>   $��Center=�6N   �� 5=   &   $��16(�60   
���p�$��Center=�6q   ��6X   �� *	Country+6q   5>   #   �� 5?   "   $ 
Horizontal=�6-   .+�5@   &   �� $��12(�60   $��Область: ��6>   $��Center=�6O   �� 5A   &   $��16(�60   
���p�$��Center=�6p   ��6X   �� *Region+6p   5B   #   �� 5C   "   $ 
Horizontal=�6-   .+�5D   &   �� $��12(�60   $��Город: ��6>   $��Center=�6M   �� 5E   &   $��16(�60   
���p�$��Center=�6n   ��6X   �� *City+6n   5F   #   �� 5G   "   $ 
Horizontal=�6-   .+�5H   &   �� $��12(�60   $��Адрес: ��6>   $��Center=�6M   �� 5I   &   $��16(�60   
���p�$��Center=�6q   ��6X   �� *	Address+6q   5J   #   �� 5K   "   $ 
Horizontal=�6-   .+�5L   &   �� $��12(�60   $��Откуда узнал: ��6>   $��Center=�6T   �� 5M   &   $��16(�60   
���p�$��Center=�6q   ��6X   �� *	AsFound+6q   5N   #   �� 5O   "   $ 
Horizontal=�6-   .+�5P   &   �� $��12(�60   $��Телефоны: ��6>   $	��Top=�6P   �� 5Q   &   $��16(�6.   
���p�$	��Top=�6t   ��6V   �� *Phone+6t   5R   #   5S      5T      5U      5W      5X      � 5Z   
   $��2��6   .+�5[      �� -   5        $��	NewClient��5[      $��Новый клиент��5\      5]      5^      5`      5a      