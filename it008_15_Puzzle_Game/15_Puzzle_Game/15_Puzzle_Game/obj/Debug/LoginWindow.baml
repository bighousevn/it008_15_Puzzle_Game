   M S B A M L   `   `   `  ����I  ESliding_Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_15_Puzzle_Game_15_Puzzle_Game  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a�gclr-namespace:MaterialDesignThemes.Wpf.Converters.CircularProgressBar;assembly=MaterialDesignThemes.Wpf7MaterialDesignThemes.Wpf.Converters.CircularProgressBar 5   	   E'clr-namespace:_15_Puzzle_Game.ViewModel_15_Puzzle_Game.ViewModel  5	   	   !    _15_Puzzle_Game.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:_15_Puzzle_Game     5   	   ypopupgclr-namespace:MaterialDesignThemes.Wpf.Converters.CircularProgressBar;assembly=MaterialDesignThemes.Wpf     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   7	viewmodel'clr-namespace:_15_Puzzle_Game.ViewModel  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��loginWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5   	     MaterialDesignWindow#��[ 5   	     LoginVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � ShowInTaskbar .   � Title$ LoginWindow��5   	   $	��675��5   	   $
��1200��6   ��5      �� 5   
    �� ImageSource$! Picture/BackGroundLogin.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5       6!   .+�5#   
   � $��0��6    � RowDefinitions 5$      �� 5%      $��1* �6    6.   �� 5&      $
��1.5* �6    60   .+�5)      � $��0��6    5*      �� 5+      6&   �� 5,      6&   .+�5/      �� $��0��6   $�� Sliding��50      	 �� TextAlignment$
	 Left=�51      $��WrapWithOverflow=�52        mainFont#��[ 53      $	��120(�54      ���#8b3bda$
��Bold"�56      60   �� 58      $��1��6   $��
    Puzzle��59      $	 Center=�5:      $��WrapWithOverflow=�5;      #��[ 5<      $	��120(�5=      ���#8b3bda$
��Bold"�5?      60   5@      #  MaterialDesignThemes.Wpf.Card  5B      $��1��6"   $	��400��5C   "   $	��500��5D   "   
������ .��5F      � $��	15 0 15 0q�6    5G      �� 5H      $
��0.8* �6(   68   �� 5I      $
��0.8* �6(   68   �� 5J      $
��0.4* �6(   68   �� 5K      $��1* �6(   66   .+�5N      �� $��0��6   $��90��5O      
������ $��2q�5Q      ._�5R      � .+�5S      �� -   5        
 ��Name$
 NameTextBox��5S   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��5U   &    % !MaterialDesignFloatingHintTextBox#��[ 5V   &   #��[ 5W   &   $��45(�5X   &   
�������$	��100��5Z   &   
������ $��10q�5\   &   ��5T   &   �� *
UserName+ �� Mode$ TwoWay=�5\   5   5]      5^      � 5`      $��1��6   $��90��5a      .+�5b      G� -   5         G�Name$ LoginPasswordBox��5b   &   $ Password��5c   &    ) %MaterialDesignFloatingHintPasswordBox#��[ 5d   &   #��[ 5e   &   $��45(�5f   &   
�������
������ $��90��5i   &   $��10q�5j   &   .  (System.Windows.Interactivity.Interaction   Triggers 5k      /  )System.Windows.Interactivity.EventTrigger  5l   "      	EventName$ PasswordChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5m   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *PasswordChangedCommand+   CommandParameter 5n   <   ��  �� ElementName$ LoginPasswordBox��5o   #   5q      5r      � 5t      $��2��6   .+�5u      �� -   5         ��Name$ Register��5u   $   
������ $��Don't have an account?��5w   $   #��[ 5x   $   $��26(�5y   $   $
��Left=�5z   $   $��Center=�5{   $   
����  ���5}      �� 5~   "    �� 
TargetType" ��6(    �� Triggers 5   &   P� 5�   *    P� Property �@J�IsMouseOver P� Value . . �5�   .   ��  �� Property � �� �� Value$
 Bold"�6K   6Z   �� 5�   .    � ��$ Italic$�6J   6[   �� 5�   .    � �� �#0e58986]   �� 5�   .    � ��
 ���� 6a   5�   +   5�   #    5�        5�   "   $ 	MouseDown��61   . 5�   &      6<   �� *RegisterWindowCommand+ 5�   <   �� $ Register��5�   #   5�      �� 5�      -   5        $ Forgot��5�   $   
������ $��Forgot password?��5�   $   #��[ 5�   $   $��26(�5�   $   $��Right=�5�   $   $��Center=�5�   $   
����  � 5�        5�   "   $ 	MouseDown��61   . 5�   &      6<   �� *ForgotPasswordWindowCommand+ 5�   <   �� $ Register��5�   '   5�   #   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��$
 Bold"�6K   6Z   �� 5�   .    � ��$ Italic$�6J   6[   �� 5�   .    � �� �#0e58986]   �� 5�   .    � ��
 ���� 6a   5�   +   5�   #   5�      5�      � 5�      $��3��6   .+�5�      �� $��Login��6!    # MaterialDesignRaisedLightButton#��[ 5�   !   $	��123��5�   !   $	��308��5�   !   $
��Bold"�5�   !   #��[ 5�   !   $	��100(�5�   !   
������ 
������ ���#e753e2$��Center=�5�   !   $	��Top=�5�   !   $��Center=�5�   !   $	��Top=�5�   !   ��5�   !   �� *LoginCommand+��5�   !   �� $ loginWindow��5�      5�      5�      5�      �� 5�   
   $��1��6   
������ 
������ $	��100��5�      $	��100��5�      $��Right=�5�      $	��Top=�5�      $��	0 70 18 0q�5�      ��5�      �� *ExitCommand+��5�      ��  �� RelativeSource ��  �� AncestorType$ WindowL�.��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ExitRun=�6&   ���#8b3bda$��Center=�5�   &   $��Center=�5�   &   $��80��5�   &   $��80��5�   &   63   5�      5�      5�      