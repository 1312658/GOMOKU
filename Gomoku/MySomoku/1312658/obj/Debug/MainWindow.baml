   M S B A M L   `   `   `  ����B  >1312658, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:_1312658_1312658  5   	       _1312658.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:_1312658     5   	   -   5          �Name$  MyGomoku��5   	    � Title$ MyGomoku��5   	   $��600.695��6   $��813.723��6+   
����������	#FFF9F9F9.��5	      � -   5         �Name$ MySomoku��5	       � ColumnDefinitions 5
   
   �� 5      $	��22* �6   �� 5      $
��240* �6   �� 5      $
��141* �6   .+�5   
   � -   5        $ 	Gird_Caro��5      $��	0,34,0,45q�6"   $��1��65    5      �� 5       � RowDefinitions 5      �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5      $	��40* �6    �� 5       $	��40* �6    �� 5!      $	��40* �6    �� 5"      $	��40* �6    �� 5#      $	��11* �6    �� 5$      $��0* �6    .+�5'         _1312658.My_Row  -   5          Name$ 	my_Row_R1��5'         Y$ 1��6.   $
��Auto��64   $
��Auto��6A     5(      -   5        $ 	my_Row_R2��5(      $ 2��6.   $
��Auto��65   $
��Auto��6B   $��1��6P     5)      -   5        $ 	my_Row_R3��5)      $ 3��6.   $
��Auto��64   $
��Auto��6A   $��2��6O     5*      -   5        $ 	my_Row_R4��5*      $ 4��6.   $
��Auto��64   $
��Auto��6A   $��3��6O     5+      -   5        $ 	my_Row_R5��5+      $ 5��6.   $
��Auto��65   $
��Auto��6B   $��4��6P     5,      -	   5        $ 	my_Row_R6��5,      $ 6��6.   $
��Auto��64   $
��Auto��6A   $��5��6O     5-      -
   5        $ 	my_Row_R7��5-      $ 7��6.   $
��Auto��65   $
��Auto��6B   $��6��6P     5.      -   5        $ 	my_Row_R8��5.      $ 8��6.   $
��Auto��65   $
��Auto��6B   $��7��6P     5/      -   5        $ 	my_Row_R9��5/      $ 9��6.   $
��Auto��65   $
��Auto��6B   $��8��6P     50      -   5        $ 
my_Row_R10��50      $ 10��6/   $
��Auto��67   $
��Auto��6D   $��9��6R     51      -   5        $ 
my_Row_R11��51      $ 11��6/   $
��Auto��66   $
��Auto��6C   $��10��6Q     52      -   5        $ 
my_Row_R12��52      $ 12��6/   $
��Auto��67   $
��Auto��6D   $��11��6R   53      � 55   
   -   5        $ 	Grid_Chat��55      $��2��6"   $��	0,34,0,45q�62    57      �� 58      $
��193* �6#   �� 59      $	��89* �6#    5<      �� 5=      $��0 �6    �� 5>      $	��49* �6    �� 5?      $	��42* �6    �� 5@      $	��54* �6    �� 5A      $
��289* �6    �� 5B      $	��46* �6    �� 5C      $	��11* �6    .+�5F      �� $��
10,1,90,10q�6   $��13.333(�6(   $��
Your Name:��6:   $
��Bold"�6O   $��2��6a   �� 5G      -   5         ��Name$ txt_Your_Name��5G      $��	93,1,0,10q�6-   $��17.333(�6@   $
��Bold"�6R   $��
Anh Tuấn��6d   $��2��6t   �� 5H      -   5         ��Name$ 	btn_Chane��5H      $��1��6(   $��	5,1,12,11q�68   $��17.333(�6K   $��Chane��6]   $
��Bold"�6m   $��2��6�   �� 5I      -   5        	 ��Name$	 lbl_KhungChat��5I      ���	#FF4F6FB4
 J� RenderTransformOrigin$
 0.5,0.5&�6B   $��8,1,10,0q�6b   $��3��6t   $��3��6�   $��2��6�   �� 5J      $��4��6   
�������$��	10,0,12,2q�64   $��2��6G   $��2��6X   �� 5K      $��Picture/Chat.ico��6   $��8,1,0,0q�6.   $��3��6?   $
��Left=�6L   $��61��6g   �� 5L      $�� Chat/History��6   $��24(�6,   $��Segoe UI Black)�6:   $��	69,1,10,1q�6V   $��3��6i   $��2��6v   �� 5M      -   5        $ txt_Chat��5M       �� 
IsReadOnly . $��	10,0,12,4q�6<   $��4��6O   $��2��6\   $��14.667(�6p   �� 5N      -   5        $ txt_Input_Chat��5N      $��	18,0,1,10q�6.   $��5��6A   $��17.333(�6N   �� 5O      -   5        $ btn_Send��5O      $��5��6'   $
��Send��64   $��14(�6C   $
��Bold"�6Q   
���   �$��	0,0,20,10q�6v   ���	#FFDAD456$��1��6�   6�   5P      5Q      5R      