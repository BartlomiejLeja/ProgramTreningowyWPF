   M S B A M L   `   `   `  ����O  KProgramTreningowyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProgramTreningowyWPF.ViewsProgramTreningowyWPF.Views  5      0    *ProgramTreningowyWPF.Views.DzienTreningowy   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProgramTreningowyWPF.Views     5      P LPrism.Wpf, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . $
��Auto��5
      $
��Auto��6    � 	Resources 5         ApplicationButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType J� Opacity J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value �� 	Resources  Key �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value �� Triggers :� RoutedEvent ��Name  up  down��%.  &	        7  7  �� 5   
   " ��6/   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      A� ���	#FFE6EAEE$	 0.7Q�67   
���   �$��3��6T   �� 5      #��z��6/   ��. # z 6�   #��z��6�   5       5      P� 5      	 �@J�	IsFocused
 . 6;   P� 5      	 �@��IsDefaulted
 . 6=   P� 5      	 �@J�IsMouseOver
 . 6=   P� 5      	 � ��
 . 6;   P� 5      	 � {�
 .  6;   5      5       5      ���� 5      up .��5       U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�64   .\�5!        $ 0:0:0.5��6/   $	 1.2Q�6A   5"      U� 5#      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�64   .\�5$        $ 0:0:0.5��6/   $	 1.2Q�6A   5%      5&      �� 5'      down .��5(      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�64   .\�5)        $ 0��6/   $	 1.2Q�6;     5*      $ 0:0:0.5��6/   $ 1Q�6A   5+      U� 5,      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�64   .\�5-        $ 0��6/   $	 1.2Q�6;     5.      $ 0:0:0.5��6/   $ 1Q�6A   5/      50      51       52      :� 53      $ UIElement.MouseEnter��6   .[�54      �� $ up_BeginStoryboard��6&   8��  6B   55      :� 56      $ UIElement.MouseLeave��6   .[�57      �� $ down_BeginStoryboard��6&   8�� 6D   58      5:      5;      .��5@      (� $��Center=�6   $��Center=�6+   .��5A   
   � $��Stretch=�6   $��Stretch=�6/   $
��Auto��6K    � RowDefinitions 5B      �� 5C      $��40 �6    �� 5D      $
��Auto �6    �� 5E      $
��Auto �6    �� 5F      $
��Auto �6    �� 5G      $
��Auto �6    �� 5H      $
��Auto �6    �� 5I      $��40 �6    �� 5J      $��40 �6     � ColumnDefinitions 5M      �� 5N      $	��200 �6#   �� 5O      $	��200 �6#   �� 5P      $	��200 �6#   .+�5R      �� -   5         ��Name$ label��5R      $
��Data��6#   
�������$
��Bold"�6F   $��0��6X   $��1��6h   $��10(�6u    J� RenderTransformOrigin$ 2.842,0.639&�6�   $��50,0,0,0q�6�   �� 5S      -   5        $ label1��5S      $
��Waga��6$   $��10(�63   $
��Bold"�6A   
�������$��0��6f   $��2��6v   $
��Left=�6�   $��50,0,0,0q�6�   $
��36.6��6�   �� 5T      -   5        $ label2��5T      $��
Opis diety��6$   $��10(�69   $
��Bold"�6G   
�������$��0��6l   $��3��6|   $��50,0,92.5,0q�6�   �� 5U      -   5        $ label3��5U      $��Opis Suplementacji��6$   $��10(�6A   $
��Bold"�6O   
�������$��0��6t   $��4��6�   $��50,0,49.727,0q�6�   �� 5V      -   5        $ label4��5V      $��Opis Cwiczeń��6$   $��10(�6;   $
��Bold"�6I   
�������$��0��6n   $��5��6~   $��50,1.85,78.107,0q�6�   $��31.31��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5X      -   5          Name$ DataPickerUserControl��5X   �   $	 0.5Q�6   $��1��6(   $��1��68      SelectedDate 5Y      �� *SelectedDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5Z      -   5         ��Name$ TextBoxWaga��5Z   �   $��1��6   $��2��6&   $	 0.5Q�63   ��6�   �� *Wage+$ TwoWay=�$ PropertyChanged=�6�   �� 5[      -   5         ��Name$ RichTextBoxSuplementacja��5[      $	 0.5Q�6=   $��1��6K   $��4��6[   . �5\      /� .T�5]      J� .*�6    .*�5^      �� �6   �� *Suplementation+$ TwoWay=�$ PropertyChanged=�5_      5`      5a      �� 5b      -	   5        $ RichTextBoxCwiczenia��5b      $	 0.5Q�69   $��1��6G   $��5��6W   $	��Top=�6�   . �5c      /� .T�5d      J� .*�6    .*�5e      �� �6   �� *	WorkOut+$ TwoWay=�$ PropertyChanged=�5f      5g      5h      �� 5i      -
   5        $ RichTextBoxDieta��5i      $	 0.5Q�65   $��1��6C   $��3��6S   . �5j      /� .T�5k      J� .*�6    .*�5l      �� �6   �� *Diete+$ TwoWay=�$ PropertyChanged=�5m      5n      5o      �� 5q      -   5         ��Name$ AddDay��5q      $��1��6(   $��11��68   #���   6F   $��Dodaj dzień��5r      $ 0.5,0.5&�6I   ��6.   �� *AddDay+z�5s      V� 5t      .~�5u      �� �� 5v      �� 5w      T� 5x      5y      5{      �� 5}      -   5        $ AddPhoto��5}      $��0��6(   $��11��68   #���   6F   $��Dodaj zdjęcie��5~      $ 0.5,0.5&�6K   ��6.   �� *
AddPhoto+z�5      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      5�      5�      