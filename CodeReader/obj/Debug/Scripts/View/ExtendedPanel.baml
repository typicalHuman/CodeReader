   M S B A M L   `   `   `  ����E  ACodeReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CodeReader
CodeReader  5      M+clr-namespace:CodeReader.Scripts.ExtensionsCodeReader.Scripts.Extensions  5
      M+clr-namespace:CodeReader.Scripts.ConvertersCodeReader.Scripts.Converters  5      K*clr-namespace:CodeReader.Scripts.ViewModelCodeReader.Scripts.ViewModel  5      B >CodeBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:CodeBox;assembly=CodeBoxCodeBox 5      +    %CodeReader.Scripts.View.ExtendedPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:CodeReader     5      M IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullD @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      5ext+clr-namespace:CodeReader.Scripts.Extensions  5
      6conv+clr-namespace:CodeReader.Scripts.Converters  5      3vm*clr-namespace:CodeReader.Scripts.ViewModel  5      4codeBox&clr-namespace:CodeBox;assembly=CodeBox  5      -   5        $��ExtendedPanelControl��5         RegularFont#��[  5         CodeReader.App    extendedPanelVM � DataContext# Z  5       � 	Resources 5       �� BasedOn �� 
TargetType  EditorContextMenu �� Property �� Value �� Source%  System.Windows.Markup.Reference �� Path.  (System.Windows.Interactivity.Interaction	   Triggers/  )System.Windows.Interactivity.EventTrigger
   	EventName.  (System.Windows.Interactivity.TriggerBase   Actions6  0System.Windows.Interactivity.InvokeCommandAction   Command   CommandParameter �� UpdateSourceTrigger  MainTextStyle  
TipTBStyle)   #CodeReader.Scripts.ViewModel.MainVM 
 mainVM8   2CodeReader.Scripts.Converters.TypeToImageConverter  TypeToSourceConverter��%�  '��       7��&	 @     7   7m�&	 }    &	 �    �� 5   
   8   " ��6A   .�5      -   5        5      �� 5   
   8��  $	��200��5   0    5      ���� 5      'm�       " m�6   8  .�5      ��  �@�DataContext 64   ��    *extendedPanel+$ DataContext�5       5"      .@�5%      m� 	 5&        5'      $
 Click��6%   . 5(         60   �� *CreateNewChildCommand+ 5)   0   ��    *cbc+$ SelectedText�$ PropertyChanged=�5+      ��5-      � 5.      .+�5/      �� $��Create new child��6$   #���  6<   �� 50      $��Ctrl+Shift+C��6$   #���  68   51      53      57        5;   
   6     5<   
   6$   5=      .��5?      � -   5         �Name$ extendedPanel��5?      $��1��6"    5@      ��  � RowDefinitions 5B   
   �� 5C      $
��130* �6   �� 5D      $��10 �6   �� 5E      $
��341* �6   .+�5H   
   �  5I      �� 5J      $
��Auto �6    $��40��6.   �� 5K      $��* �6    .+�5N      ��  �� Orientation$ Vertical=�6   .+�5O      �  � ColumnDefinitions 5Q      �� 5R      $
��Auto �6+   �� 5S      $
��Auto �6+   �� 5T      $
��Auto �6+   .+�5X      �� $ 
Horizontal=�6!   .+�5Y      �� $
��Name��6$   $��5q�60   $��Center=�6;   $��17(�5Z      $
��Left=�6*   �� 5[      -   5         ��Name$ labelBox��5^   "   
������ $��Stretch=�5]   "   |�. $	��150��5a   "   $	��150��5b   "   #��[  5c   "   $	��5 5q�5d   "   ��5[   "   �� *CurrentComponent.Label+$ PropertyChanged=�2	   ,CodeReader.Scripts.Extensions.FocusExtension 	  	IsFocused 5`   "   �� *IsLabelBoxFocused+$ PropertyChanged=�.��5d   /    J� InputBindings 5e      �� 5f   "   
 �� Key$ Return��6-    �� Command 6:   �� *FocusOnCodeCommand+ �� CommandParameter 5g   -   ��  �� ElementName$	 cbc��.��5h   5   5i      5j      �� 5m      $ 
Horizontal=�6!   $��1��6:   .+�5n      �� $
��Type��6$   $��5q�60   $��Center=�6;   $��17(�5o      �� 5p        TransparentTextBox2
  ,ModernWpf.Controls.Primitives.ComboBoxHelper 
  TextBoxStyle# [ 5r         CodeComponentCmbBox#��[ 5s      $	��150��6L    �� Text 5p   #   �� * CurrentComponent.ComponentType+$ PropertyChanged=���5q      ��   	typesEnum# [ ��5t      �� 5u   "   .R�5v   &   � .+�5w   *   �� ��64   �� �� 5x   *   $��Right=�60   ��6L   �� $ .�$ PropertyChanged=� �� 	Converter# [ 5z   '   5{   #   5}      5~      �� 5�      $ 
Horizontal=�6!   $��2��6:   .+�5�      �� $��Language��6$   $��5q�64   $��Center=�6?   $��17(�5�      �� 5�      #��[ 5�   +   # [ 5�   +    �� SelectedItem 5�   #   �� *CurrentComponent.Language+$ PropertyChanged=���5�   +   ��  	 	langsEnum# [	 5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $��20 �6$   �� 5�      $��* �6$   .+�5�      �� $��Description��6   $��5 0 0 1q�6/   $��Bottom=�6@   $��0��5�      $��17(�5�      �� 5�      -   5        $��tbDesc��5�      
������ $��17(�5�      $��1��6$   #��[  5�      $	��5 0q�5�       �� TextWrapping$
 Wrap=�5�      ��5�      �� *CurrentComponent.Description+$ PropertyChanged=�5�      5�      5�      �� 5�   
   -   5        $��Splitter��5�   8   $��5 0 5 0q�5�       �� ResizeDirection$
 Rows=�6)    
 GridSplitterGray#��[
 5�        �� ShowsPreview  . $��1��5�   +   $��Stretch=�5�      $��Center=�6/   ��5�      �� 5�      ! �� 
TargetType"! ��6"   .R�5�      �� #��z��6   $��3��5�   !   $��0 1 0 0q�5�      " �� CornerRadius$" 3��5�      5�      5�      5�        CodeBox.CodeBoxControl  5�   
   -   5        $	��cbc��5�   !   $��3��5�   !   $��2��5�   !   $��5 2 5 5q�5�   !   $
��Auto=�5�   !   # � ContextMenu## �  5�   !   $   ProgrammingLanguage$ 5�   !   �� *CurrentComponent.Language+$ PropertyChanged=�%   Text% 5�   !   �� *CurrentComponent.Code+$ PropertyChanged=�&   UndoOperations& 5�   !   �� *CurrentComponent.History+$ PropertyChanged=�'   IndentationStrategy' 5�   !   �� *IndentStrategy+$ PropertyChanged=�( �� Mode$( OneWayToSource=�.% 6�   .% 5�   !   ��5�      �� 5�      "  5�      ) �� Triggers) 5�      �� 5�      * �� Binding* 6&   �� +   mainVM# Z+ $ IsDarkModeEnabled�, �� Value, True5�   6   .a�5�      ��  �@ DefaultTheme$ 	DarkTheme=�6=   5�      �� 5�      * 6&   �� # Z+ $ IsDarkModeEnabled�	, False5�   6   .a�5�      ��  �@ DefaultTheme$ 
LightTheme=�6=   5�      5�      .% 5�   ,   .% 5�      .% 5�   (    5�      �� 5�      - �� 	Modifiers$- 
Ctrl+Shiftf�6   $ C��64    6<   �� *CreateNewChildCommand+ 6f   �� $	 cbc��$ SelectedText��� 5�      $
- Ctrlf�6   $ B��6.    66   �� *BeautifyCommand+. �� CommandTarget. 5�      �� $	 cbc��.% 5�   4   .% 5�      5�      5�      ��5�      �� 5�   
   " >�6   # [B>�6)   ) 5�      �� 5�      * 6   �� *CurrentComponent+$ PropertyChanged=�, 5�      Z� .a�5�      ��  � y�$ 	Collapsed=�63   5�      5�      5�      