   M S B A M L   `   `   `  ����B  >1312658, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_1312658.Views_1312658.Views  5   	       _1312658.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_1312658.Views     5   	   -   5          �Name$  MyGomoku��5   	    � Title$ MyGomoku��5	   	   $��698.195��6   $��1158.723��6+   
����������	#FF9B9898 � WindowStyle$
 None=�6g    � WindowStartupLocation$ CenterScreen=�6z   .��5
      � -   5         �Name$ MySomoku��5
       � ColumnDefinitions 5   
   �� 5      $
��262* �6   �� 5      $
��141* �6   .+�5   
   �� -   5         ��Name$ 	btn_Pause��5      $��0,0,675,631q�6%   $��20(�6:   $
��Bold"�6H   .��5      �� $��49��6   $��63��6%   .+�5      �� $��Picture/Pause.png��6   $��46��63   $	��3,0q�6?    J� RenderTransformOrigin$ 0.5,0.5&�6L   5      5      �� 5   
   -   5         ��Name$ label��5      $,��&    Gomoku Five in a row - multiplayer��6   $
��Left=�6P   $��
-70,33,0,0q�6k   $	��Top=�6   $
��1221��6�   $��Yu Gothic UI Semibold)�6�   $��70(�6�   $	��111��6�   $ 0.5,0.5&�6�   $��2��6  5      � 5   
   -   5        $ 	Gird_Caro��5      $��20,150,30,22q�6"   	 � RowDefinitions	 5      �� 5       5      �� 5      .+�5         _1312658.Views.ChessBoard  -   5        
  Name$
 ChessBoardMain��5      $
��Auto��67   $
��Auto��6D   $��0,0,0,1q�6R   ��5       �� 5!       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5"      �  � Color$ Black��6'    � Offset$ 0Q�65   � 5#      $ 	#FFF7F7F7��6'   $ 1Q�69   5$      5&      5'      � 5)   
   -   5        $ 	Grid_Chat��5)      $��1��6"   $��30,144,10,23q�62   	 5*      �� 5+       5-      �� 5.      $
��271* �6#   �� 5/      $	��11* �6#   .+�51         _1312658.Views.use_Chat  -   5          Name$ ChatMain��51      $��	0,53,10,0q�60   $
��Auto��6C   $��2��6Q   $
��Auto��6e   52      53      54      