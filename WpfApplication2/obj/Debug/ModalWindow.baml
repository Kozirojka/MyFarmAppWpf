   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   !    WpfApplication2.ModalWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   /localclr-namespace:WpfApplication2     5   	     � Icon$N  HC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\icons\swords.png��5   	   
������� � Title$ ModalWindow��5
   	   $	��450��6   $	��300��6*   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��10q�6"    �� Orientation$ 
Horizontal=�6.   $
��Left=�6G   $	��Top=�6b   .+�5      �� -   5        $��50��5      $��50��6    .��5      r� -   5         r�Name$ firstMediaElement��5       r� Source$M GC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\Gifs\ridder.gif?�5       r� LoadedBehavior$
 Play=�5       r� UnloadedBehavior$
 Stop=�5      $��50��5      $��50��5       r� Stretch$
 Fill=�5      5      5       �� 5!      $��Knight��6   $
��Bold"�6&   $��Center=�68   $��10,0,0,0q�6S   5"      �� 5%   
   $��1��6   $��10q�6"   $ 
Horizontal=�6.   $
��Left=�6G   $	��Top=�6b   .+�5&      �� -   5        $��50��5&      $��50��6    .��5'      r� -   5        $ secondMediaElement��5'      $M GC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\Gifs\archer.gif?�5(      $
 Play=�5)      $
 Stop=�5*      $��50��5+      $��50��5,      $
 Fill=�5-      5.      5/      �� 50      $��Archer��6   $
��Bold"�6&   $��Center=�68   $��10,0,0,0q�6S   51      �� 54   
   $��2��6   $��10q�6"   $ 
Horizontal=�6.   $
��Left=�6G   $	��Top=�6b   .+�55      �� -   5        $��50��55      $��50��6    .��56      r� -   5        $ thirdMediaElement��56      $M GC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\Gifs\kZ9CIA.gif?�57      $
 Play=�58      $
 Stop=�59      $��50��5:      $��50��5;      $
 Fill=�5<      5=      5>      �� 5?      $��Son of Anarchy��6   $
��Bold"�6.   $��Center=�6@   $��10,0,0,0q�6[   5@      �� 5B   
   $��3��6   $��10q�6"   $ 
Horizontal=�6.   $
��Left=�6G   $	��Top=�6b   .+�5C      �� -   5        $��50��5C      $��50��6    .��5D      r� -   5        $ fourhtMediaElement��5D      $S MC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\inviroment\carrot.png?�5E      $
 Play=�5F      $
 Stop=�5G      $��50��5H      $��50��5I      $
 Fill=�5J      5K      5L      �� 5M      $��Son of Anarchy��6   $
��Bold"�6.   $��Center=�6@   $��10,0,0,0q�6[   5N      �� 5O   
   $��4��6   $��10q�6"   $ 
Horizontal=�6.   $
��Left=�6G   $	��Top=�6b   .+�5P      �� -	   5        $��50��5P      $��50��6    .��5Q      r� -
   5        $ FivthMediaElement��5Q      $I CC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\1546691.png?�5R      $
 Play=�5S      $
 Stop=�5T      $��50��5U      $��50��5V      $
 Fill=�5W      5X      5Y      �� 5Z      $��Angar��6   $
��Bold"�6%   $��Center=�67   $��10,0,0,0q�6R   5[      �� 5^   
   $��5��6   $��10q�6"   $ 
Horizontal=�6.   $
��Left=�6G   $	��Top=�6b   .+�5_      �� -   5        $��50��5_      $��50��6    .��5`      r� -   5        $ SixMediaElement��5`      $R LC:\Users\Kostya\Desktop\WpfApplication2\WpfApplication2\other\tractorPNG.png?�5a      $
 Play=�5b      $
 Stop=�5c      $��50��5d      $��50��5e      $
 Fill=�5f      5g      5h      �� 5i      $��Son of Anarchy��6   $
��Bold"�6.   $��Center=�6@   $��10,0,0,0q�6[   5j      5k      5l      