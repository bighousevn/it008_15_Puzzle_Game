   M S B A M L   `   `   `  ����I  ESliding_Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_15_Puzzle_Game_15_Puzzle_Game  5      E'clr-namespace:_15_Puzzle_Game.ViewModel_15_Puzzle_Game.ViewModel  5          _15_Puzzle_Game.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:_15_Puzzle_Game     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      7	viewmodel'clr-namespace:_15_Puzzle_Game.ViewModel  5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5        MaterialDesignPaper N� 
Background# �  5       
 MainVM � DataContext# [ 5      $��Stretch=�5      $��Stretch=�5      .��5      � ��5   
   �� 5       �� ImageSource$$ Picture/MainPageBackGround.jpg��6    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   �  � ColumnDefinitions 5      �� 5       $��1* �6#   60   �� 5!      $
��1.5* �6#   62   �� 5"      $��1* �6#   60   .+�5%      � $��1��6    5&      �� 5'      6&   �� 5(      6&   .+�5+      �� $��0��6   $��Sliding��5,      $��Italic$�5-        mainFont#��[ 5.      $	��150(�5/      $
��Bold"�50      $
��Left=�51      $	��Top=�52      ���#a261e153      �� 55      $��1��6   $��Puzzle��56      $	��150(�57      #��[ 58      $
��Bold"�59      $��Italic$�5:      $��Right=�5;      $��Center=�5<      ���#a261e15=   3   5>      �� 5@      -   5        
������ 
������ $	��100��5B      $	��100��5C      $
��Left=�5D      $	��Top=�5E      $��
10 100 0 0q�5F      .��5H      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ SwapHorizontal=�6*   $��80��5I   *   $��80��5J   *   ���#8b3bda J� RenderTransformOrigin$ 0.5,0.5&�5L   *   $��Center=�5M   *   $��Center=�5N   *   5O      5P      �� 5R      $��2��6   
������ 
������ $	��100��5U      $	��100��5V      $��Right=�5W      $	��Top=�5X      $��	0 10 10 0q�5Y       & "MaterialDesignFloatingActionButton#��[ 5Z      ��5[      �� *SettingCommand+.��5\        $ Settings=�6*   $��80��5]   *   $��80��5^   *   ���#8b3bda$��Center=�5`   *   $��Center=�5a   *   6G   5b      �� 5d      -   5        $��2��5d      
������ 
������ $	��100��5g      $	��100��5h      $��Right=�5i      $	��Top=�5j      $��
0 120 10 0q�5k      #��[ 5l      .��5n        $ 	LockReset=�6*   $��80��5o   *   $��80��5p   *   ���#8b3bda$��Center=�5r   *   $��Center=�5s   *   6G   5t      5u      � 5w   
   $��1��6    5x      �� 5y      $��1* �6    6.   �� 5z      $
��3.5* �6    60   .+�5|      �� -   5        
������ $��
Let's play��5}      #��[ 5~      $��40(�5      $��50��5�      $	��300��5�       �� Padding$ 0q�5�      	 �� TextAlignment$	 Center=�5�      ���#8b3bda$��0 8 0 0q�5�      ��5�      �� 5�      
 �� 
TargetType"
 ��6    �� Triggers 5�      P� 5�       P� Property �@J�IsMouseOver P� Value . . �5�   "   ��  �� Property � �� �� Value$
 Bold"�6?   6N   �� 5�   "    � ��$ Italic$�6>   6O   �� 5�   "    � �� �#0e58986Q   �� 5�   "    � ��
 ���� 6U   5�      5�      5�      5�      5�      5�      