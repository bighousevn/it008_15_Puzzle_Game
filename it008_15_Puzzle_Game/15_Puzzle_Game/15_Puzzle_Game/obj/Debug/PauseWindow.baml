   M S B A M L   `   `   `  ����I  ESliding_Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_15_Puzzle_Game_15_Puzzle_Game  5   	   E'clr-namespace:_15_Puzzle_Game.ViewModel_15_Puzzle_Game.ViewModel  5   	   !    _15_Puzzle_Game.PauseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:_15_Puzzle_Game     5   	   =	viewmodel'clr-namespace:_15_Puzzle_Game.ViewModel     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5   	   
������  � WindowStyle$
 None=�5   	    
 MainVM � DataContext# [ 5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ PauseWindow��5   	   $	��300��6   $	��400��6*   .��5      �� 
�������$��5q�5        MaterialDesignPaper#���  5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��1.5* �6    60   �� 5      $��1* �6    6.   .+�5      �� $��0��6   $��
3, 0, 3, 0q�5      $5��/ARE YOU SURE      YOU WANT TO EXIT    THE GAME?��5        �� TextAlignment$ Center=�5!        mainFont#��[ 5"      $��50(�5#      $
��Bold"�5$      $
��Wrap=�5%      $��Center=�5&      $��Center=�5'      6-   � 5)      $��2��6    � ColumnDefinitions 5*      �� 5+      6)   �� 5,      6)   .+�5/      � $��0��6   $��80��50      $	��160��51      .+�52      �� -   5        +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 25��52       " MaterialDesignRaisedDarkButton#��[ 53      ���#e753df
������ $��80��56      .��58      �� $��OK��6$   $��60(�59   $   #��[ 5:   $   $��Center=�5;   $   $	��Top=�5<   $   $ Center=�5=   $   $��87��6;   
���   �5>   $   5?      5@      � 5A      $��1��6   $��80��5B      $	��160��5C      .+�5D      �� $	 25��6   #��[ 5E      $��80��5F      ���#e753df
������ ��5I      �� *CloseWindowCommand+��5J      �� 
 �� RelativeSource
 ��  �� AncestorType$ WindowL�.��5K      �� $��CANCEL��6$   $��50(�5L   $   #��[ 5M   $   $��Center=�5N   $   $	��Top=�5O   $   $ Center=�5P   $   $��62��6;   
���   �5Q   $   5R      5S      5T      5U      5V      5X      