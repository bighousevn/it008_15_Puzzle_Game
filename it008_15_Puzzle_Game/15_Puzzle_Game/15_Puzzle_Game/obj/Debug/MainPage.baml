   M S B A M L   `   `   `  ����I  ESliding_Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_15_Puzzle_Game_15_Puzzle_Game  5      E'clr-namespace:_15_Puzzle_Game.ViewModel_15_Puzzle_Game.ViewModel  5	          _15_Puzzle_Game.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:_15_Puzzle_Game     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      7	viewmodel'clr-namespace:_15_Puzzle_Game.ViewModel  5	         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5        MaterialDesignPaper N� 
Background# �  5       
 MainVM � DataContext# [ 5      $��Stretch=�5      $��Stretch=�5      .��5      � ��5   
   �� 5       �� ImageSource$$ Picture/MainPageBackGround.jpg��6    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5    
   �  � ColumnDefinitions 5!      �� 5"      $��1* �6#   60   �� 5#      $
��1.5* �6#   62   �� 5$      $��1* �6#   60   .+�5'      �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Picture/FireWork.gif��6   $��1��5(      $��2��5)      $��	255,0,0,0q�6(   6=   �� 5*      $ Picture/FireWork.gif��6   $��0��5+      $��2��5,      $��	0,0,221,0q�6(   6=   � 5.      $��1��6    5/      �� 50      $��1* �6$   62   �� 51      $��2* �6$   62   �� 52      $��2* �6$   62   .+�55      �� $��0��6   $��Welcome to our game!��56        mainFont#��[ 57      $��45(�58      $
��Bold"�59      ���#0e5898$��Center=�5;      $��Center=�5<      ��5=      �� 5>       �� 
TargetType" ��6     �� Triggers 5?      :� 5@   "   	 :� RoutedEvent$	 Window.Loaded��6/   .[�5A   &   �� .��5B   *   �� 
 �� TargetProperty$
 (TextBlock.Text)�65   .��5C   .   ��  g� RepeatBehavior$ Forever��6L   .�5D   2   a�  �� KeyTime$ 0:0:0��6S    �� Value W6I   6e   a� 5E   2   $ 0:0:0.1��6T    We6I   6h   a� 5F   2   $ 0:0:0.2��6U    Wel6I   6i   a� 5G   2   $ 0:0:0.3��6V    Welc6I   6j   a� 5H   2   $ 0:0:0.4��6W   	 Welco6I   6k   a� 5I   2   $ 0:0:0.5��6X   
 Welcom6I   6l   a� 5J   2   $ 0:0:0.6��6Y    Welcome6I   6m   a� 5K   2   $ 0:0:0.7��6Z    Welcome 6I   6n   a� 5L   2   $ 0:0:0.8��6[    	Welcome t6I   6o   a� 5M   2   $ 0:0:0.9��6\    
Welcome to6I   6p   a� 5N   2   $ 0:0:1.1��6]    Welcome to 6I   6q   a� 5O   2   $ 0:0:1.2��6^    Welcome to o6I   6r   a� 5P   2   $ 0:0:1.3��6_    Welcome to ou6I   6s   a� 5Q   2   $ 0:0:1.4��6`    Welcome to our6I   6t   a� 5R   2   $ 0:0:1.5��6a    Welcome to our 6I   6u   a� 5S   2   $ 0:0:1.6��6b    Welcome to our g6I   6v   a� 5T   2   $ 0:0:1.7��6c    Welcome to our ga6I   6w   a� 5U   2   $ 0:0:1.8��6d    Welcome to our gam6I   6x   a� 5V   2   $ 0:0:1.9��6e    Welcome to our game6I   6y   a� 5W   2   $ 0:0:2��6f    Welcome to our game!6I   6x   a� 5X   2   $ 0:0:2.5��6f    Welcome to our game!6I   6z   5Y   /   5Z   +   5[   '   5\   #   5^      5`      �� 5b      $��1��6   $��Sliding��5c      $��Italic$�5d      #��[ 5e      $	��150(�5f      $��	0 -30 0 0q�5g      $
��Bold"�5h      $
��Left=�5i      $	��Top=�5j      ���#a261e15k      �� 5m      $��2��6   $��Puzzle��5n      $	��150(�5o      $��	0 -30 0 0q�5p      #��[ 5q      $
��Bold"�5r      $��Italic$�5s      $��Right=�5t      $��Center=�5u      ���#a261e15v   3   5w      �� 5y      -   5        
������ 
������ $	��100��5{      $	��100��5|      $
��Left=�5}      $	��Top=�5~      $��	10 10 0 0q�5      .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ SwapHorizontal=�6*   $��80��5�   *   $��80��5�   *   ���#8b3bda J� RenderTransformOrigin$ 0.5,0.5&�5�   *   $��Center=�5�   *   $��Center=�5�   *   5�      5�      �� 5�      $��0��6   
������ 
������ $	��100��5�      $	��100��5�      $
��Left=�5�      $	��Top=�5�      $��
10 100 0 0q�5�       & "MaterialDesignFloatingActionButton#��[ 5�      ��5�      �� *SettingCommand+.��5�        $ Settings=�6*   $��80��5�   *   $��80��5�   *   ���#8b3bda$��Center=�5�   *   $��Center=�5�   *   6G   5�      �� 5�      -   5        $��0��5�      
������ 
������ $	��100��5�      $	��100��5�      $
��Left=�5�      $	��Top=�5�      $��
10 200 0 0q�5�      #��[ 5�      .��5�        $ 	LockReset=�6*   $��80��5�   *   $��80��5�   *   ���#8b3bda$��Center=�5�   *   $��Center=�5�   *   6G   5�      � 5�      $��2��6    5�      �� 5�      $��2* �6$   62   �� 5�      $��1* �6$   62   �� 5�      6&   .+�5�      � $��0��6    5�      �� 5�      $��1* �6+   68   �� 5�      $
��1.3* �6+   6:   .+�5�        $
 Cash=�6.   $��60��5�   .   $��60��5�   .   $��0 0 10 7q�5�   .   $��Right=�5�   .   $	��Top=�5�   .   6H   �� 5�      $��1��6    #��[ 5�       $��70(�5�       $��
10 -16 0 0q�5�       $
��Left=�5�       $	��Top=�5�        �� TextAlignment$ Center=�5�       $	��100��5�       $��CharacterEllipsis=�5�       ��5�       �� *	usermoney+ �� StringFormat$
 {0}$��5�      5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $��1* �6    6.   �� 5�      $
��3.5* �6    60   .+�5�      �� -   5        
������ $��
Let's play��5�      #��[ 5�      $��40(�5�      $��50��5�      $	��300��5�       �� Padding$ 0q�5�      $ Center=�5�      ���#8b3bda$��0 8 0 0q�5�      ��5�      �� 5�      " ��6    5�      P� 5�       P� Property �@J�IsMouseOver P� Value . . �5�   "   ��  �� Property � �� �� Value$
 Bold"�6?   6N   �� 5�   "    � ��$ Italic$�6>   6O   �� 5�   "    � �� �#0e58986Q   �� 5�   "    � ��
 ���� 6U   5�      5�      5�      5�      5�      5�      