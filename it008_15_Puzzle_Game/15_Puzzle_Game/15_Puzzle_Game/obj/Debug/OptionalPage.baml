   M S B A M L   `   `   `  ����I  ESliding_Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_15_Puzzle_Game_15_Puzzle_Game  5      E'clr-namespace:_15_Puzzle_Game.ViewModel_15_Puzzle_Game.ViewModel  5      "    _15_Puzzle_Game.OptionalPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:_15_Puzzle_Game     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      7	viewmodel'clr-namespace:_15_Puzzle_Game.ViewModel  5         MaterialDesignBody#���   5
        N� 
Background  �#e6f5fc 
 MainVM � DataContext# [ 5       N� Title$ OptionalPage��5       � 	Resources 5       �� 
TargetType  
ImageStyle �� Property �� Value �� Triggers :� RoutedEvent	 �� TargetProperty
 W� From	 W� To g� Duration��%d  &	       �� 5   
   " ��6   �5      �� 5       �@J�RenderTransformOrigin$ 0.5,0.5&�6:    5      :� 5      $ UIElement.MouseEnter��6   .[�5      �� .��5      �� .��5      W� $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6.   $
 1X�5   &   $
 1.05X�6/   $ 0:0:0.1D�69   W� 5      $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6.   $
 1X�5   &   $
 1.05X�6/   $ 0:0:0.1D�69   5       5!      5"      :� 5%      $ UIElement.MouseLeave��6   .[�5&      �� .��5'      �� .��5(      W� $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6.   $

 1.05X�5)   "   $ 1X�6.   $ 0:0:0.2D�65   W� 5*      $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6.   $

 1.05X�5+   "   $ 1X�6.   $ 0:0:0.2D�65   5,      5-      5.      50      51      .��52      � 
������  � RowDefinitions 53   
   �� 54      $��* �6   6)   �� 55      $��3* �6   6*   .+�58   
   � $��0��6    � ColumnDefinitions 59      �� 5:      $��1* �6#   60   �� 5;      $
��1.5* �6#   62   .+�5>      � $��0��6    5?      �� 5@      $��1* �6'   64   �� 5A      $��4* �6'   64   .+�5D      �� -   5         & "MaterialDesignFloatingActionButton#��[ 5D      $��Center=�5E      $	��Top=�5F      $��14q�5G      ���#0e5898$��50��5I      $��50��5J      .��5L      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6.   $��30��5M   .   $��30��5N   .   
�������5O   .   5P      � 5R      $��1��6    5S      �� 5T      6*   �� 5U      6*   .+�5X      �� $��0��6     �� TextAlignment$ Center=�5Z       $��Center=�5[       $��Center=�5\         mainFont#��[ 5]       $��50(�5^       ��5Y       �� *
username+5^   0   � 5_      $��1��6    5`      �� 5a      $��* �6/   6;   �� 5b      $��* �6/   6;   .+�5d        $
 Cash=�62   $��Right=�5e   2   $��0 0 15 0q�5f   2   $��Center=�5g   2   $��70��5h   2   $��70��5i   2   6?   �� 5j      $��1��6$   $ Center=�5l   $   $��20 0 0 0q�5m   $   $��60(�5n   $   #��[ 5o   $   $
��Left=�5p   $   $	��Top=�5q   $   ��5k   $   �� *	usermoney+ �� StringFormat$
 {0}$��5q   >   5r      5u      5v      � 5y      $��1��6    5z      �� 5{      $��1* �6$   62   �� 5|      $
��0.8* �6$   64    5~      �� 5      $��1* �6'   64   �� 5�      $
��1.5* �6'   66   .+�5�      �� -   5         ��Name$ SettingButton��5�      $��1��5�      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndeterminate .    IsIndicatorVisible .    Value$ -1Q�5�      #��[ 5�      ���#0e5898$��Right=�5�      $	��Top=�5�      $��16q�5�      $��0q�5�      ��5�      �� *SettingCommand+.��5�        $ DotsHorizontal=�6.   
�������5�   3   5�      � 5�      $��1��6   $��1��5�      .+�5�      �� -   5        $ 	AddButton��5�      {�.  $��50��5�      $	��100��5�      $	��Add��5�      $��Center=�5�      $��Center=�5�      $��14q�5�      #��[ 5�      $��30(�5�      6E   �� 5�      -   5        $ DeleteButton��5�      {�.  $��50��5�      $	��100��5�      $��Delete��5�      $��Center=�5�      $��Center=�5�      $��0 0 14 0q�5�      #��[ 5�      $��30(�5�      5�   :   �� 5�      -   5        $ 
EditButton��5�      $��50��5�      $	��100��5�      $
��Edit��5�      $��Center=�5�      $��Center=�5�      $��0q�5�      #��[ 5�      $��30(�5�      5�   8   5�      �� 5�      -   5         ��Name$ SampleImage��5�      $��0��5�      $��2��5�      $��10q�5�      $	��150��5�      $	��250��5�      $
��Left=�5�      65   �� 5�      -   5         ��Name$ 	StatusBtn��5�      $��1��5�      $��0��5�      $ Center=�5�      $��50��5�      $	��330��5�      $��Center=�5�      $
��Left=�5�      #��[ 5�      $��40(�5�      6,   5�      5�      � 5�   
   $��1��6   .+�5�      �� ���#1791f8$��3q�5�       �� CornerRadius$ 20��5�      $��180 15 180 15q�5�      $��1��5�      ._�5�      �� 1  +MaterialDesignThemes.Wpf.ScrollViewerAssist   IsAutoHideEnabled .    BubbleVerticalScroll . $��10q�5�      .��5�      � -   5        $��MainWrappanel��5�        � Orientation$ 
Horizontal=�5�       6;   5�      5�      5�      5�      5�      