   M S B A M L   `   `   `  ����E  ACodeReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CodeReader.Scripts.ConvertersCodeReader.Scripts.Converters  5      7 clr-namespace:CodeReader.ScriptsCodeReader.Scripts  5	      K*clr-namespace:CodeReader.Scripts.BehaviorsCodeReader.Scripts.Behaviors  5
      'clr-namespace:CodeReader
CodeReader  5      S.clr-namespace:CodeReader.Scripts.View.Controls CodeReader.Scripts.View.Controls  5      /    )CodeReader.Scripts.View.Controls.CodeTree   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      6conv+clr-namespace:CodeReader.Scripts.Converters  5      M IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullD @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5      .model clr-namespace:CodeReader.Scripts   5	      8behav*clr-namespace:CodeReader.Scripts.Behaviors   5
      &localclr-namespace:CodeReader   5      ?controls.clr-namespace:CodeReader.Scripts.View.Controls   5      a ]GongSolutions.WPF.DragDrop, Version=2.0.0.0, Culture=neutral, PublicKeyToken=91f1945125b7a587ddurn:gong-wpf-dragdrop  5      -   5        6   0CodeReader.Scripts.View.Controls.BaseUserControl   Name$  CodeTreeControl��5         RegularFont#��[  5       � 	Resources 5        TreeItemContextMenu8   2CodeReader.Scripts.View.Controls.KeyBindedMenuItem �� 
TargetType �� BasedOn �� Property �� Value �� Source%  System.Windows.Markup.Reference �� Path �� UpdateSourceTrigger8   2CodeReader.Scripts.View.Controls.KeyBindedMenuItem	   Click
   MainText   TipText   ClickCommand �� Triggers �� Binding �� Value   MainForeground  MenuItemWithSubmenu8   2CodeReader.Scripts.Converters.TypeToImageConverter  TypeToSourceConverter8   2CodeReader.Scripts.Converters.InverseBoolConverter  BoolInverse��%�  &	       7   7m�7m�7  &	 �    &	 �    �� 5   
   8��  $	��170��5   2    5      ���� 5      '        "  6   8  .�5       ��  �@�DataContext 64   ��    *
mainGrid+$ DataContext��� 5"       � {� 62   �� *IsDefaultState+$ PropertyChanged=��� 5#       � ��$	 200��6.   5$      5&      .@�5)        $	 OpenMenuItem_Click��6)   $

 Open��5*   )   {�. 69     5-      $
 Open as root��5.   )   $ Ctrl+O��5/   )    5-   )   �� *OpenAsRootCommand+5/   )     52      $
 	Add child��53   )   $ Ctrl+N��54   )    52   )   �� *AddChildCommand+54   )     57      {�.  59   )   �� *UpdateRelationshipCommand+��5;      �� 5<      "  6   8  .�5=      ��  �@�DataContext 68   ��    *
mainGrid+$ DataContext�$ PropertyChanged=� 5?      �� 5@       6*   �� *IsDefaultState+ True5A   *   .a�5B   "   ��  �@ MainForeground
 �����6C   �� 5C   "    �@ MainText$ New relationship��6=   �� 5D   "    �@ TipText$ Ctrl+R��6<   5E      �� 5F       6*   �� *IsDefaultState+	 False5G   *   .a�5H   "   ��  �@ MainText$ Cancel operation��6=   �� 5I   "    �@ TipText$ 	Backspace��6<   �� 5J   "    �@ MainForeground
 �  ��6C   5K      5M      5P        5U      $
 Rename��5V   )   $ F2��5W   )    5U   )   �� *RenameCommand+5W   )     5Z      $
 Delete��5[   )   $	 Dlt��5\   )   
 �  �� 5Z   )   �� *DeleteCommand+5]   )     5`      8�� $

 Edit��5a   )   .@�5c        $	
 Cut��5d   )   $ Ctrl+X��5e   )    5c   -   �� *
CutCommand+5e   )     5h      $

 Copy��5i   )   $ Ctrl+C��5j   )   $��32��5k   )    5h   -   �� *CopyCommand+5k   )     5n      $
 Paste��5o   )   $ Ctrl+V��5p   )    5n   -   �� *PasteCommand+5p   )   5r      5t        5w   
   6$     5x   
   6$   5z      .��5}      � -   5         �Name$ mainGrid��5}      7   1CodeReader.Scripts.Behaviors.InputBindingBehavior%   PropagateInputBindingsToWindow . .+�5   
   �  � RowDefinitions 5�      �� 5�      $
��Auto �6    �� 5�      -   5         �Name$ 
controlRow��5�   .   $
��Auto �6    6.   �� 5�      .+�5�      �� $��40��6   $��Stretch=�6%   $
��Back��5�      #��[  5�      $��0��5�      $��
10 10 0 10q�6&   .  (System.Windows.Interactivity.Interaction   Triggers 5�      /	  )System.Windows.Interactivity.EventTrigger	  5�       	  	EventName$ Click��6%   .
  (System.Windows.Interactivity.TriggerBase 
  Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *BackCommand+5�      ��5�      �� 5�      " ��6     AccentButtonStyle# [ 60    5�      �� 5�       6*   �� *IsSingleRootOpen+$ PropertyChanged=� True5�   ?   .a�5�   "   ��  � y�$ Visible=�6?   5�      �� 5�       6*   �� *IsSingleRootOpen+$ PropertyChanged=�	 False5�   ?   .a�5�   "   ��  � y�$ 	Collapsed=�6?   5�      5�      5�      � 5�      -   5        $��Stretch=�5�      $��10 0 0 0q�5�      $��1��6%    � ColumnDefinitions 5�      �� 5�      -   5        $ firstColumn��5�   '   �� 5�      $��10 �6'   �� 5�      .+�5�      �� $��40��6   $��	Add child��5�      $��Stretch=�5�      #��[  5�      {�5�      �� *IsDefaultState+$ PropertyChanged=� 5�      	  5�      $ Click��6)   . 5�         64   �� *AddChildCommand+5�      ��5�      �� 5�      " ��6    # [B��64    5�      �� 5�   "    6.   �� *IsSingleRootOpen+$ PropertyChanged=� True5�   ?   .a�5�   &   ��  � ��$ 3��6H   5�   #   �� 5�   "    6.   �� *IsSingleRootOpen+$ PropertyChanged=�	 False5�   ?   .a�5�   &   ��  � ��$ 1��6H   5�   #   5�      5�      �� 5�      $��40��6   $
��Auto��5�      $��Stretch=�5�      $��
Add parent��5�      #��[  5�      $��2��5�      {�5�      �� *IsDefaultState+$ PropertyChanged=���5�      �� 5�      " ��6    # [ 64    5�      �� 5�   "    6.   �� *IsSingleRootOpen+$ PropertyChanged=�	 False5�   ?   .a�5�   &   ��  � y�$ Visible=�6C   5�   #   �� 5�   "    6.   �� *IsSingleRootOpen+$ PropertyChanged=� True5�   ?   .a�5�   &   ��  � y�$ 	Collapsed=�6C   5�   #   5�       5�      	  5�      $ Click��6)   . 5�         64   �� *AddParentCommand+5�      5�      5�      R� 5�      -   5        $��codeTree��5�      $��2��6'    K� ZIndex$ 2��64   $��0 10 0 0q�5�      $��0q�6)   )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDragSource .    IsDropTarget .  J� 	AllowDrop .    DropHandler 5�      ��  �� ElementName$ mainGrid��$ DataContext�  � DataContext  5�      ��    CodeReader.App!   mainVM# Z!  5�      " �� DataType&    CodeReader.Scripts.CodeComponent# �� ItemsSource$ �� Mode% �� Orientation& �� BitmapScalingMode' �� 	Converter( ��Name  TransparentTextBox1  +ModernWpf.Controls.Primitives.TextBoxHelper)   IsDeleteButtonVisible* �� 
IsReadOnly+   Name��%H  (��       5�   /   *, +)7  7   7  7  �� 6   ""  6/   # 6W   �� *
Children+$ PropertyChanged=�$$ TwoWay=�.R�5�      � .+�5�      �� $% 
Horizontal=�6)   .+�5�   "   �� $��0,0,5,0q�6(   $��Center=�69   $& HighQuality=�5�   $   ��5�   '   �� $ ComponentType�8'   $ PropertyChanged=�5�   #   �� 5�   "   $( nameBox��5�   *   8�� $��15(�5�   $   $��Center=�5�   *   8�� ) .  ��5�   *   �� *Label+* 5�   *   ��    $+ mainGrid��$  DataContext.IsDefaultState�8'  .��5  N   5  #   5     5     5     5     ��5	     �� 5
     " Q�6   # [BQ�5     .�5     -   5        �� 5      �@�ContextMenu# �  68   �� 5      �@Q�
IsSelected 67   �� *
IsOpened+$ PropertyChanged=�5     5     5     , J� InputBindings, 5  
   �� 5     
- �� Key$- F2��6   . �� Command. 6"   �� *RenameCommand+�� 5     / �� 	Modifiers$
/ Ctrlf�6   $- P��6*   . 63   �� *AddParentCommand+�� 5     $	- Esc��6   . 6#   �� *BackCommand+�� 5     $- Delete��6   . 6&   �� *DeleteCommand+�� 5     $
- Down��6   . 6$   �� *SelectNextCommand+�� 5     $- Up��6   . 6"   �� *SelectPrevCommand+�� 5      $
/ Ctrlf�6O   $- N��6`   0 �� CommandTarget0 6   �� $ CodeTreeControl��. 6h   �� *AddChildCommand+�� 5!     $
/ Ctrlf�6O   $- C��6`   0 6   �� $ CodeTreeControl��. 6h   �� *CopyCommand+�� 5"     $
/ Ctrlf�6O   $- V��6`   0 6   �� $ CodeTreeControl��. 6h   �� *PasteCommand+�� 5#     $
/ Ctrlf�6O   $- X��6`   0 6   �� $ CodeTreeControl��. 6h   �� *
CutCommand+�� 5$     $
/ Ctrlf�6O   $- O��6`   0 6   �� $ CodeTreeControl��. 6h   �� *OpenAsRootCommand+�� 5%     $
/ Ctrlf�6O   $- R��6`   0 6   �� $ CodeTreeControl��. 6h   �� *UpdateRelationshipCommand+�� 5&     $- 	Backspace��6O   0 6   �� $ CodeTreeControl��. 6_   �� *CancelRelationshipModeCommand+5)     5*     