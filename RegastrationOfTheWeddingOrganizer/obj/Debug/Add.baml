   M S B A M L   `   `   `  ����\  XRegastrationOfTheWeddingOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:RegastrationOfTheWeddingOrganizer!RegastrationOfTheWeddingOrganizer  5   	   +    %RegastrationOfTheWeddingOrganizer.Add   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:RegastrationOfTheWeddingOrganizer     5   	   -   5        ���#00BFFF���#FF8000  � Title$1  +Добавление свадьбы в БД��5   5   $	��450��6U   $	��800��6b    � Icon$z tC:\Users\Artem\Desktop\C#\RegastrationOfTheWeddingOrganizer\RegastrationOfTheWeddingOrganizer\bin\Debug\img\logo.gif��6�   .��5	      � .+�5
   
   �� .@�5      �� $��Начало��6   .��5      � ���#00BFFF � ColumnDefinitions 5      �� 5      .+�5      �� ���#FF8000$%��Название свадьбы��62   $
��Left=�6M   $��	34,54,0,0q�6h   $	��Top=�6{   �� 5      ���#FF8000$*��$Дата начала свадьбы��62   $
��Left=�6P   $��
34,122,0,0q�6k   $	��Top=�6   �� 5      ���#FF8000$(��"Дата конца свадьбы��62   $
��Left=�6O   $��34,0,0,0q�6j   $��Center=�6|   �� 5      -   5         ��Name$ WeddingNameBox��5   4   ���#FF8000$
��Left=�6L   $��
229,58,0,0q�6g    �� TextWrapping$
 Wrap=�6{   $��Свадьба��6�   $	��Top=�6�   $	��120��6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ WeddingStartBox��5   R   ���#FF8000   SelectedDateFormat$ Short=�67   $
��Left=�6k   $��229,124,0,0q�6�      Text$  ��6�   $	��Top=�6�   $	��120��6�   6�     5      -   5        $ WeddingEndBox��5   R   ���#FF8000$ Short=�67   $
��Left=�6i   $��229,190,0,0q�6�   $  ��6�   $	��Top=�6�   $	��120��6�   6�   5      5      �� 5      $��
Жених��6   .��5      � ���#00BFFF.+�5      �� -   5         ��Name$ MailHaircutBox��5   5   ���#FF8000$
��Left=�6M   $��	99,70,0,0q�6h   $	��Top=�6{   $	��182��6�   $��1��6�   	 �� SelectedIndex$	 0��6�   6�   �� 5      -   5        $ MailMakeupBox��5   5   ���#FF8000$
��Left=�6L   $��
99,141,0,0q�6g   $	��Top=�6{   $	��182��6�   $��1��6�   $	 0��6�   6�   �� 5      -   5        $ MailSuitBox��5   5   ���#FF8000$
��Left=�6J   $��
99,224,0,0q�6e   $	��Top=�6y   $	��182��6�   $��1��6�   $	 0��6�   6�   �� 5      -   5        $ MailRingBox��5   5   ���#FF8000$
��Left=�6J   $��
99,307,0,0q�6e   $	��Top=�6y   $	��182��6�   $��1��6�   $	 0��6�   6�   �� 5      ���#FF8000$��Стрижка��62   $
��Left=�6D   $��7,68,0,0q�6_   $	��Top=�6q   $��2��6�   �� 5      ���#FF8000$��Макияж��62   $
��Left=�6C   $��	7,139,0,0q�6^   $	��Top=�6q   $��2��6�   �� 5       ���#FF8000$��Костюм��62   $
��Left=�6C   $��
10,222,0,0q�6^   $	��Top=�6r   $��2��6�   �� 5!      ���#FF8000$��Кольцо��62   $
��Left=�6C   $��
10,303,0,0q�6^   $	��Top=�6r   $��2��6�   �� 5"      ���#FF8000$��1��62   $$��Цена на стрижку: ��6B   $
��Left=�6^   $��
317,67,0,0q�6y   $	��Top=�6�   �� 5#      ���#FF8000$��1��62   $"��Цена на макияж: ��6B   $
��Left=�6]   $��317,139,0,0q�6x   $	��Top=�6�   �� 5$      ���#FF8000$��1��62   $"��Цена на костюм: ��6B   $
��Left=�6]   $��315,222,0,0q�6x   $	��Top=�6�   �� 5%      ���#FF8000$��1��62   $"��Цена на кольцо: ��6B   $
��Left=�6]   $��317,303,0,0q�6x   $	��Top=�6�   �� 5&      -	   5        
 ��Name$
 MaleHaircutCost��5&   B   ���#FF8000$��1��62   $��0��6[   $
��Left=�6g   $��
415,67,0,0q�6�   $	��Top=�6�   �� 5'      -
   5        $
 MaleMakeupCost��5'   B   ���#FF8000$��1��62   $��0��6[   $
��Left=�6g   $��416,139,0,0q�6�   $	��Top=�6�   �� 5(      -   5        $
 MaleSuitCost��5(   B   ���#FF8000$��1��62   $��0��6X   $
��Left=�6d   $��415,222,0,0q�6   $	��Top=�6�   �� 5)      -   5        $
 MaleRingCost��5)   B   ���#FF8000$��1��62   $��0��6X   $
��Left=�6d   $��415,303,0,0q�6   $	��Top=�6�   5*      5+      �� 5,      $��Невеста��6   .��5-      � ���#00BFFF.+�5/      �� -   5        $ FemailHaircutBox��5/   5   ���#FF8000$
��Left=�6O   $��	99,70,0,0q�6j   $	��Top=�6}   $	��182��6�   $	 0��6�   6�   �� 50      -   5        $ FemailMakeupBox��50   5   ���#FF8000$
��Left=�6N   $��
99,141,0,0q�6i   $	��Top=�6}   $	��182��6�   $	 0��6�   6�   �� 51      -   5        $ FemailSuitBox��51   5   ���#FF8000$
��Left=�6L   $��
99,224,0,0q�6g   $	��Top=�6{   $	��182��6�   $	 0��6�   6�   �� 52      -   5        $ FemailRingBox��52   5   ���#FF8000$
��Left=�6L   $��
99,307,0,0q�6g   $	��Top=�6{   $	��182��6�   $	 0��6�   6�   �� 53      ���#FF8000$��Стрижка��62   $
��Left=�6D   $��7,68,0,0q�6_   $	��Top=�6q   �� 54      ���#FF8000$��Макияж��62   $
��Left=�6C   $��	7,139,0,0q�6^   $	��Top=�6q   �� 55      ���#FF8000$��Костюм��62   $
��Left=�6C   $��
10,224,0,0q�6^   $	��Top=�6r   �� 56      ���#FF8000$��Кольцо��62   $
��Left=�6C   $��
10,307,0,0q�6^   $	��Top=�6r   �� 57      ���#FF8000$$��Цена на стрижку: ��62   $
��Left=�6N   $��
317,67,0,0q�6i   $	��Top=�6}   �� 58      ���#FF8000$"��Цена на макияж: ��62   $
��Left=�6M   $��317,139,0,0q�6h   $	��Top=�6}   �� 59      ���#FF8000$"��Цена на костюм: ��62   $
��Left=�6M   $��317,222,0,0q�6h   $	��Top=�6}   �� 5:      ���#FF8000$"��Цена на кольцо: ��62   $
��Left=�6M   $��317,303,0,0q�6h   $	��Top=�6}   �� 5;      -   5        $
 FemaleHaircutCost��5;   2   ���#FF8000$��0��6M   $
��Left=�6Y   $��
415,67,0,0q�6t   $	��Top=�6�   �� 5<      -   5        $
 FemaleMakeupCost��5<   2   ���#FF8000$��0��6M   $
��Left=�6Y   $��415,139,0,0q�6t   $	��Top=�6�   �� 5=      -   5        $
 FemaleSuitCost��5=   2   ���#FF8000$��0��6J   $
��Left=�6V   $��415,222,0,0q�6q   $	��Top=�6�   �� 5>      -   5        $
 FemaleRingCost��5>   2   ���#FF8000$��0��6J   $
��Left=�6V   $��415,303,0,0q�6q   $	��Top=�6�   5?      5@      �� 5A      $��Развлечения��6   .��5B      � ���#00BFFF.+�5C      �� ���#FF8000$��Тамада��62   $
��Left=�6C   $��	34,55,0,0q�6^   $	��Top=�6q   �� 5D      ���#FF8000$��Шеф-повар��62   $
��Left=�6F   $��
34,124,0,0q�6a   $	��Top=�6u   �� 5E      ���#FF8000$��Диджей��62   $
��Left=�6C   $��
34,198,0,0q�6^   $	��Top=�6r   �� 5F      -   5        $! EntertainmentToastmasterBox��5F   5   ���#FF8000$
��Left=�6Z   $��
157,58,0,0q�6u    �� Text$  ��6�   $	��Top=�6�   $	��120��6�   $��1��6�   $	 0��6�   6�   �� 5G      -   5        $ EntertainmentChefBox��5G   5   ���#FF8000$
��Left=�6S   $��157,126,0,0q�6n   $  ��6�   $	��Top=�6�   $	��120��6�   $��1��6�   $	 0��6�   6�   �� 5H      -   5        $ EntertainmentDJBox��5H   4   ���#FF8000$
��Left=�6P   $��157,198,0,0q�6k   $  ��6�   $	��Top=�6�   $	��120��6�   $��1��6�   $	 0��6�   6�   �� 5I      ���#FF8000$"��Цена на тамаду: ��62   $
��Left=�6M   $��
285,57,0,0q�6h   $	��Top=�6|   �� 5J      ���#FF8000$"��Цена на повара: ��62   $
��Left=�6M   $��285,125,0,0q�6h   $	��Top=�6}   �� 5K      ���#FF8000$"��Цена на диджея: ��62   $
��Left=�6M   $��285,196,0,0q�6h   $	��Top=�6}   �� 5L      -   5        $
 ToastmasterCost��5L   2   ���#FF8000$��0��6K   $
��Left=�6W   $��
382,58,0,0q�6r   $	��Top=�6�   �� 5M      -   5        $
 ChefCost��5M   2   ���#FF8000$��0��6E   $
��Left=�6Q   $��379,126,0,0q�6l   $	��Top=�6�   �� 5N      -   5        $
 DJCost��5N   2   ���#FF8000$��0��6B   $
��Left=�6N   $��378,197,0,0q�6i   $	��Top=�6~   5O      5P      �� 5Q      $��Банкет��6   .��5R      � ���#00BFFF.+�5S      �� ���#FF8000$7��1Количество еды на человека��62   $
��Left=�6W   $��	34,54,0,0q�6r   $	��Top=�6�   �� 5T      ���#FF8000$'��!Количество гостей��62   $
��Left=�6N   $��
34,122,0,0q�6i   $	��Top=�6}   �� 5U      ���#FF8000$��Цена за еду��62   $
��Left=�6H   $��34,0,0,0q�6c   $��Center=�6u   �� 5V      -   5        $ WeddingFoodQualityBox��5V   5   ���#FF8000$
��Left=�6T   $��
229,58,0,0q�6o   $  ��6�   $	��Top=�6�   $	��120��6�   $	 0��6  .@�5W      �� ���#FF8000$��Мало��6=   �� 5X      ���#FF8000$��Нормально��6=   �� 5Y      ���#FF8000$��
Много��6=   5Z      �� 5[      -   5        $ WeddingGuestNumberBox��5[   4   ���#FF8000$
��Left=�6S   $��229,126,0,0q�6n   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   6�   �� 5\      -   5        $
 WeddingFoodCostBox��5\   2   ���#FF8000$��0��6N   $
��Left=�6Z   $��	229,0,0,0q�6u   $��Center=�6�   $	��120��6�   5]      5^      �� 5_      $��Результат��6   .��5`      � -   5        ���#00BFFF.+�5a      �� -   5         ��Name$ 	ResultBox��5a   6   ���#FF8000$��Center=�6I   $��0,10,0,0q�6f   $
��Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��310��6�   $	��774��6�   �� 5b      -    5        ���#FF8000���#CC99FE$��
Назад��5b   H   $
��Left=�6X   $��
10,358,0,0q�6s   $	��Top=�6�   $��25��6�   $��91��6�   6�   �� 5c      -!   5        ���#FF8000���#CC99FE$��Добавить в БД��5c   G   $
��Left=�6_   $��685,358,0,0q�6z   $	��Top=�6�   $��25��6�   $��91��6�   6�   5d      5e      5f      5h      5i      