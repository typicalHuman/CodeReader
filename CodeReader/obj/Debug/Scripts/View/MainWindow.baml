   M S B A M L   `   `   `  ����E  ACodeReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CodeReader
CodeReader  5   	   L HNotifications.Wpf, Version=0.1.1.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Notifications.Wpf.Controls;assembly=Notifications.WpfNotifications.Wpf.Controls 5   	   S.clr-namespace:CodeReader.Scripts.View.Controls CodeReader.Scripts.View.Controls  5	   	   C&clr-namespace:CodeReader.Scripts.EnumsCodeReader.Scripts.Enums  5
   	   M+clr-namespace:CodeReader.Scripts.ConvertersCodeReader.Scripts.Converters  5   	   K*clr-namespace:CodeReader.Scripts.BehaviorsCodeReader.Scripts.Behaviors  5   	       CodeReader.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   $localclr-namespace:CodeReader  5   	   WnotificationsCclr-namespace:Notifications.Wpf.Controls;assembly=Notifications.Wpf  5   	   =controls.clr-namespace:CodeReader.Scripts.View.Controls  5	   	   2enums&clr-namespace:CodeReader.Scripts.Enums  5
   	   6conv+clr-namespace:CodeReader.Scripts.Converters  5   	   M IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullD @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   8behav*clr-namespace:CodeReader.Scripts.Behaviors   5   	   ���#007acb$	��1.2q�5   	     � Title$  
CodeReader��5   	   $	��450��6   $	��850��6,      CodeReader.App   mainVM � DataContext# Z 5   	   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .   ModernWpf.ThemeManager   IsThemeAware . !  ModernWpf.Controls.TitleBar   ExtendViewIntoTitleBar . $	��450��5   	   $	��800��6    � 
ResizeMode$ CanResizeWithGrip=�5   	      WindowWithThemes#��[  5   	    � 	Resources 5      D   >CodeReader.Scripts.Converters.IsTextSameWithEnumValueConverter  IsSameTextEnum��%   &	         5   
   60   5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5       .+�5$   
   � $��1��6   	 � ColumnDefinitions	 5%      �� 5&      $
��auto �6#   �� 5'      $��* �6#   .+�5)      o� $	��5 0q�6   $��35��6!   $	��Top=�6-   $
��Left=�5*       5+      8   2CodeReader.Scripts.View.Controls.KeyBindedMenuItem
 �� 
TargetType �� BasedOn  BaseMenuStyle �� Property �� Value  CodeControl �� Triggers'   !CodeReader.Scripts.Enums.ViewMode   Main �� Value �� Binding �� UpdateSourceTrigger��%�  &	       7m�'  �     7  &	 �     7  �� 5,      "
  6   8   .�5-      ��  �@ MainFontSize$ 12��69   �� 5.       �@ ContentMargin$ 3 0 3 0q�6:   5/      �� 50      "
  6   8   6o   �� 51      "
  6   8    53      �� 54      # Z 6l    6*   �� *
ViewMode+$ PropertyChanged=�.a�55   "   ��  � {� .  6>   56      58      59      .@�5:           MainText$
 File��6-   .@�5;        $	 New��61      TipText$ Ctrl+Shift+N��5<   -   $	��140��5>   -      ClickCommand 5=   -   �� *NewProjectCommand+5>   -     5?      $
 Open��61   $ Ctrl+Shift+O��5A   -    5B   -   �� *OpenCommand+  5C      $
 Save��61   $ Ctrl+S��5D   -   #��[ 5E   -    5F   -   �� *SaveCommand+  5G      $ Save as��61   $ Ctrl+Shift+S��5H   -   #��[ 5I   -    5J   -   �� *SaveAsCommand+�� 5K        5L      $
 Exit��61      MainForeground
 �  �� 5N   -   �� *ExitCommand+5O        5P      $
 Edit��6-   #��[ 6=   .@�5Q        $
 Undo��61   $ Ctrl+Z��5R   -   #��[ 5S   -   $	��130��5U   -    5T   -   �� *UndoCommand+5U   -     5V      $
 Redo��61   $ Ctrl+Y��5W   -   #��[ 5X   -    5Y   -   �� *RedoCommand+5Z        5[      $
 Code��6-   #��[ 6=   .@�5\        $ Import code��61    5]   -   �� *ImportCodeCommand+  5^      $ Change default language��61     MenuItemWithSubmenu#��[ 5_   -      MainFontSize$ 12��5`   -    5a       �� RelativeSource �� Mode �� Path `� 	Converter��%k  '        7m�7  �� 5b      "
  6$   8   .�5c   "   ��  �@m�IsCheckable . 6@   �� 5d   "    �@ MainFontSize$ 12��6A   �� 5e   "    �@ ContentMargin$ 0q�6B   �� 5f   "    �@ ClickCommand 6A   �� *ChangeDefaultLanguageCommand+�� 5g   "    �@ ClickCommandParameter 6J   ��  �� $
 Self=�$ MainText� 5i   "   �� 5j   &    True62    5k   *   `� 5l   .   8  .1�5m   2   �� $ MainText�6:    6J   �� $
 Self=��� 5n   2   $ DefaultLanguage�6:   5o   /   .a�5q   *   ��  �@m�	IsChecked . 6F   5r   '   5t      5u      .@�5v        $ CSharp��65     5w      $	 CPP��65     5x      $ C��65     5y      $ Python��65     5z      $ JS��65     5{      $	 PHP��65     5|      $ Assembly��65   5}        5~      $ 12��6]    62   �� *ChangeModeCommand+��5      �� 5�      "
  6$   # [Bm�6L    5�   "   �� 5�   &      Default# Z 6s    62   �� *
ViewMode+$ PropertyChanged=�.a�5�   *   ��  �@ MainText$ References mode��6E   5�   '   �� 5�   &      
References# Z 6t    62   �� *
ViewMode+$ PropertyChanged=�.a�5�   *   ��  �@ MainText$ Default mode��6E   5�   '   5�      5�      5�        5�      $ Windows��6-   .@�5�        $ Set file association��61    5�   -   �� *SetFileAssociationCommand+5�      5�      �� 5�      -   5         ��Name$ 	searchBox��5�   .   $��20��5�      $	��Top=�6"   $��2 1 10 0q�6:   $��0q�5�      1  +ModernWpf.Controls.Primitives.ControlHelper   PlaceholderText$ Search��5�        GridSplitterGray    PlaceholderForeground#  [ 5�      $��1��5�      !   CornerRadius$! 10��5�      $��Stretch=�5�      |�. ��5�      �� *
SearchText+$ PropertyChanged=�.��6[   ��5�      �� 5�      "
 ��6     	SearchBox# [ 61    5�      �� 5�      # Z 6l    6*   �� *
ViewMode+$ PropertyChanged=�.a�5�   "   ��  � y�$ 	Collapsed=�6?   5�      5�      .��5�   !   .	  (System.Windows.Interactivity.Interaction" 	  Triggers" 5�      /
  )System.Windows.Interactivity.EventTrigger
  5�      # 
  	EventName$# KeyUp��6%   .  (System.Windows.Interactivity.TriggerBase$   Actions.$ 5�      6  0System.Windows.Interactivity.InvokeCommandAction  %   Command% 60   �� *SearchElementCommand+5�      .��5�   *   & J� InputBindings& 5�      �� 5�      
' �� Key$' Enter��6!   ( �� Command( 6-   �� *OpenFirstFoundCommand+.��5�   )   5�      5�      1  +Notifications.Wpf.Controls.NotificationArea  5�   
   -   5        )  Name$) NotificationsArea��5�   *   * K� ZIndex$* 4��6G   +   Position$+ BottomRight=�5�   *   ,   MaxItems$, 1��6A   $��2��6N   ]� 5�   
   
������ .+�5�      �� - �� Orientation$- 
Horizontal=�6   
������ .+�5�      2  ,ModernWpf.Controls.Primitives.TitleBarButton  $��38��6$   $��60��60   $��Bottom=�5�       $	��2 0q�6;   . � ToolTip$
. Home��5�   $   " 5�      
  5�      $# Click��6)   .$ 5�        % 64   �� *HomeCommand+5�      .��5�      �� -   5        / ��Name$/ TitleGifImage��5�      0 �� BitmapScalingMode$0 HighQuality=�5�      $-��'pack://application:,,,/Images/house.png��5�      5�      5�      �� 5�      $��25(�6   $��
CodeReader��6*     	TitleFont#��[ 5�      $��	10 0 0 -5q�5�      $��Bottom=�6,   5�      %  ModernWpf.Controls.ToggleSwitch  5�      1   	OnContent$1 	Dark mode��6   2   
OffContent$2 
Light mode��64   '  !System.Windows.Shell.WindowChrome3   IsHitTestVisibleInChrome3 . $	��Top=�5�      $��	0 0 170 0q�66   $��Right=�5�        RegularFont#��[ 6:   4   IsOn4 5�      �� *IsDarkModeEnabled+$ PropertyChanged=�5�      5�        ModernWpf.Controls.Frame  5�   
   -   5        5  Name$5 Frame1��5�   =   $��2��6   6  � Source$6 Pages\MainPage.xaml?�6    7   1CodeReader.Scripts.Behaviors.InputBindingBehavior%7   PropagateInputBindingsToWindow7 . & 5�      �� 5�      8 �� 	Modifiers$8 
Ctrl+Shiftf�6   $' N��64   ( 6<   �� *NewProjectCommand+9 �� CommandTarget9 5�      �� : �� ElementName$: MainGrid���� 5�      $8 
Ctrl+Shiftf�6   $' O��64   ( 6<   �� *OpenCommand+�� 5�      $
8 Ctrlf�6   $' F��6.   ( 66   �� *SearchCommand+; �� CommandParameter; 6X   �� $: 	searchBox��5�      & 5�   
   �� 5�      $
8 Ctrlf�6   $' S��6*   ( 62   �� *SaveCommand+�� 5�      $8 
Ctrl+Shiftf�6   $' S��60   ( 68   �� *SaveAsCommand+�� 5�      $
8 Ctrlf�6   $' Z��6*   ( 62   �� *UndoCommand+�� 5�      $
8 Ctrlf�6   $' Y��6*   ( 62   �� *RedoCommand+5�      5�      