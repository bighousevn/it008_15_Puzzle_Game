   M S B A M L   `   `   `  ����I  ESliding_Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_15_Puzzle_Game_15_Puzzle_Game  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a�gclr-namespace:MaterialDesignThemes.Wpf.Converters.CircularProgressBar;assembly=MaterialDesignThemes.Wpf7MaterialDesignThemes.Wpf.Converters.CircularProgressBar 5   	   E'clr-namespace:_15_Puzzle_Game.ViewModel_15_Puzzle_Game.ViewModel  5	   	   !    _15_Puzzle_Game.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:_15_Puzzle_Game     5   	   ypopupgclr-namespace:MaterialDesignThemes.Wpf.Converters.CircularProgressBar;assembly=MaterialDesignThemes.Wpf     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   7	viewmodel'clr-namespace:_15_Puzzle_Game.ViewModel  5	   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��loginWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5   	     MaterialDesignWindow#��[ 5   	     LoginVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ LoginWindow��5   	   $	��675��5   	   $
��1200��5   	    J� RenderTransformOrigin$ 0.5,0.5&�5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   [�5      �� 5       .��5!      �� 	 g� 	BeginTime$	 0X�6!   
 g� Duration$
 ForeverD�5"   !   .��5#      W�  �� 
TargetName$ loginWindow��6*    �� TargetProperty$ (Window.Opacity)�5$   *    W� From$ 0X�5%   *   	 W� To$ 1X�5&   *   $	 0:0:0X�5'   *   $
 0:0:1.5D�5(   *   6?   5)      5*      5,      ��5.      �� 5/   
    �� ImageSource$! Picture/BackGroundLogin.jpg��6   .��51      �  � ColumnDefinitions 52   
   �� 53      6!   �� 54      6!   .+�57   
   � $��0��6    � RowDefinitions 58      �� 59      $��1* �6    6.   �� 5:      $
��1.5* �6    60   .+�5=      � $��0��6    5>      �� 5?      6&   �� 5@      6&   .+�5C      �� $��0��6   $�� Sliding��5D       �� TextAlignment$
 Left=�5E      $��WrapWithOverflow=�5F        mainFont#��[ 5G      $	��120(�5H      ���#8b3bda$
��Bold"�5J      60   �� 5L      $��1��6   $��
    Puzzle��5M      $ Center=�5N      $��WrapWithOverflow=�5O      #��[ 5P      $	��120(�5Q      ���#8b3bda$
��Bold"�5S      60   5T      #  MaterialDesignThemes.Wpf.Card  5V      $��1��6"   $	��400��5W   "   $	��500��5X   "   
������ .��5Z      � $��	15 0 15 0q�6    5[      �� 5\      $
��0.8* �6(   68   �� 5]      $
��0.8* �6(   68   �� 5^      $
��0.4* �6(   68   �� 5_      $��1* �6(   66   .+�5b      �� $��0��6   $��90��5c      
������ $��2q�5e      ._�5f      � .+�5g      �� -   5         ��Name$ NameTextBox��5g   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��5i   &    % !MaterialDesignFloatingHintTextBox#��[ 5j   &   #��[ 5k   &   $��45(�5l   &   
�������$	��100��5n   &   
������ $��10q�5p   &   ��5h   &   �� *
UserName+ �� Mode$ TwoWay=�5p   5   5q      5r      � 5t      $��1��6   $��90��5u      .+�5v      G� -   5         G�Name$ LoginPasswordBox��5v   &   $ Password��5w   &   #��[ 5x   &    ) %MaterialDesignFloatingHintPasswordBox#��[ 5y   &   $��45(�5z   &   
�������
������ $��90��5}   &   $��10q�5~   &   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5�   "      	EventName$ PasswordChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *PasswordChangedCommand+   CommandParameter 5�   <   ��  �� ElementName$ LoginPasswordBox��5�   #   5�      �� 5�      -   5        $ TextBlockPassWord��5�   "   $ Password��5�   "   #��[ 5�   "   #��[ 5�   "   $��45(�5�   "   $y�	Collapsed=�5�   "   
�������$��90��5�   "   $��Center=�5�   "   
������ $��10q�5�   "   ��5�   "   �� *
Password+$ TwoWay=�5�   1   d� 5�      -   5         d� 	IsChecked$ FalseY�5�   '    ) %MaterialDesignFlatPrimaryToggleButton#��[ 5�   '   $��Right=�5�   '   $��Center=�5�   '   ��5�   '   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$	 Eye=�   Size$ 21X�5�      5�      � 5�      $��2��6   .+�5�      �� -   5          ��Name$  Register��5�   $   
������ $��Don't have an account?��5�   $   #��[ 5�   $   $��26(�5�   $   $
��Left=�5�   $   $��Center=�5�   $   
����  ���5�      �� 5�   "   ! �� 
TargetType"! ��6(   " �� Triggers" 5�   &   P� 5�   *   # P� Property# �@J�IsMouseOver$ P� Value$ . . �5�   .   �� % �� Property% � ��& �� Value$
& Bold"�6K   6Z   �� 5�   .   % � ��$& Italic$�6J   6[   �� 5�   .   % � ��& �#0e58986]   �� 5�   .   % � ��
& ���� 6a   5�   +   5�   #    5�        5�   "   $ 	MouseDown��61   . 5�   &      6<   �� *RegisterWindowCommand+ 5�   <   �� $ Register��5�   #   5�      �� 5�      -   5        $  Forgot��5�   $   
������ $��Forgot password?��5�   $   #��[ 5�   $   $��26(�5�   $   $��Right=�5�   $   $��Center=�5�   $   
����  � 5�        5�   "   $ 	MouseDown��61   . 5�   &      6<   �� *ForgotPasswordWindowCommand+ 5�   <   �� $ Register��5�   '   5�   #   ��5�      �� 5�   "   "! ��6(   " 5�   &   P� 5�   *   # �@J�IsMouseOver$ . . �5�   .   �� % � ��$
& Bold"�6K   6Z   �� 5�   .   % � ��$& Italic$�6J   6[   �� 5�   .   % � ��& �#0e58986]   �� 5�   .   % � ��
& ���� 6a   5�   +   5�   #   5�      5�      � 5�      $��3��6   .+�5�      �� $��Login��6!    # MaterialDesignRaisedLightButton#��[ 5�   !   $	��123��5�   !   $	��308��5�   !   $
��Bold"�5�   !   #��[ 5�   !   $	��100(�5�   !   
������ 
������ ���#e753e2$��Center=�5�   !   $	��Top=�5�   !   $��Center=�5�   !   $	��Top=�5�   !   ��5�   !   �� *LoginCommand+��5�   !   �� $ loginWindow��5�      5�      5�      5�      �� 5�   
   $��1��6   
������ 
������ $	��100��5�      $	��100��5�      $��Right=�5�      $	��Top=�5�      $��	0 70 18 0q�5�      ��5�      �� *ExitCommand+��5�      �� ' �� RelativeSource' �� ( �� AncestorType$( WindowL�.��5�      '	  !MaterialDesignThemes.Wpf.PackIcon	  ) 	  Kind$) ExitRun=�6&   ���#8b3bda$��Center=�5�   &   $��Center=�5�   &   $��80��5�   &   $��80��5�   &   63   5�      �� 5�   
   $��0��6   "
  WpfAnimatedGif.ImageBehavior* 
  AnimatedSource$* Picture/Like.gif��5�      $	��130��5      $	��130��5     $��Right=�5     $ 0.5,0.5&�5     $��0,136,425,409q�60   5     5     5     