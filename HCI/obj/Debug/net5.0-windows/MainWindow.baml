   M S B A M L   `   `   `  ����>  :HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HCI.help.helpProviderHCI.help.helpProvider  5   	   clr-namespace:HCIHCI  5   	       HCI.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3cmd#clr-namespace:HCI.help.helpProvider     5   	   #localclr-namespace:HCI     5   	     � 
ResizeMode$  CanMinimize=�5	   	    � Title$* $Vođenje evidencije o mapi događaja��5
   	   $	��560��64   $
��1200��6A   $��20(�6N    � WindowStartupLocation$ Manual=�6\   
 � Top$	 100��6{    � Left$	 100��6�    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<     5   
   -   5        $&  cmd:RoutedCommands.dodajDogadjaj��5      6�     5   
   -   5        $! cmd:RoutedCommands.dodajTip��5      6     5   
   -   5        $% cmd:RoutedCommands.dodajEntitet��5      6�     5   
   -   5        $( "cmd:RoutedCommands.tabelaDogadjaja��5      6�     5   
   -   5        $# cmd:RoutedCommands.tabelaTipa��5      6�     5   
   -   5        $' !cmd:RoutedCommands.tabelaEntiteta��5      6�     5   
   -   5        $ cmd:RoutedCommands.grafik��5      6y   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��171* �6   6.   �� 5      $
��226* �6   6.   �� 5      $
��803* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      �� 5      $��25 �6   .+�5!   
   �� $��0��6   $��1��6%   .+�5"      �� -	   5        $��55��5"      	 � ToolTip$	 Kreiraj dogadjaj��68   .��6S   	Kreiraj6\   �� 5#      -
   5        $��izmeni��5#      $��55��6#   $	 Izmeni dogadjaj��6D   .��6^   Izmeni6f   �� 5$      -   5        $��obrisi��5$      $��55��6#   $	 Obrisi dogadjaj��6D   .��6^   Obrisi6f   �� 5%      -   5        $��ocDogadjajListBox��5%      $	��296��6T   $��3q�6a   ��60   �� *ocDogadjaja+��5&      �� 5'      .R�5(      �� 
 �� Orientation$
 
Horizontal=�6%   	 6>   �� *Oznaka+.+�5)      �� $
��Fill=�6$   $��3q�63   $��25��6>   $��25��6J   ��6U   �� *
IkonicaS+	 5*   "   _� 5+   &   ��6.   �� *Oznaka+5-      �� 5.      $��3q�6(   $��16(�6J   ��63   �� *Naziv+6J   5/      50      52      54      �� 56   
   -   5        $��canvas��56   ,    K� ZIndex$ 1��6:   $��1��6K    J� 	AllowDrop$
 True��6�   $��3��6%  $��	171,0,0,0q�69  	 6   �� *Oznaka+.+�57      �� $ 0��6   $��images\mapa1.png��6%   $
��Fill=�6@   $	��474��6O   $
��1019��6\   58      o� 5:      $��0��6   $��0��6#   $��3��60   .@�5;      m� $��Kreiraj��6   $��16(�6(   $
��Bold"�66   .@�5<      m� -   5        $��Dogadjaj��5<   I   $��Novi dogadjaj��62    m� InputGestureText$ CTRL + D��6Y   $	 Kreiranje novog dogadjaja��6v   m� 5=      -   5        $	��Tip��5=   -   $��Novi tip��6   $ CTRL + T��68   $	 Kreiranje novog dogadjaja��6g   m� 5>      -   5        $��Etiketa��5>   1   $��Nova etiketa��6   $ CTRL + E��6W   $	 Kreiranje novog dogadjaja��6t   5?      m� 5@      $��_Tabela��6   $��16(�6(   $
��Bold"�66   .@�5A      m� -   5        $��Tabela_dogadjaja��5A   .   $��	Dogadjaja��6   $ ALT + D��6e   $	 Kreiranje novog dogadjaja��6�   m� 5B      -   5        $��Tabela_tipova��5B   +   $��Tipova��6   $ ALT + T��6]   $	 Kreiranje novog tipa��6x   m� 5C      -   5        $��Tabela_etiketa��5C   ,   $��Etiketa��6   $ ALT + E��6`   $	 Kreiranje nove etikete��6{   5D      m� 5E      $��_Grafik��6   $��16(�6(   $
��Bold"�66   .@�5F      m� -   5        $��Grafik_sveta��5F   1   $��Grafik sveta��6   $ CTRL + G��6a   $1	 +Prikaz svetske rasprostranjenosti dogadjaja��6}   5G      m� 5H      $��_Pomoc��6   $��16(�6'   $
��Bold"�65   .@�5I      m� -   5        $��pomoc��5I   *   $��Pomoc��6   $ F1��6K   $	 Pomoc��6a   5J      5K      �� 5M   
   $��0��6\   $��1��6l   $��3��6y   $��	0,460,0,0q�6�   $��2��6�   
������� � DataContext 6   ��  �� ElementName$ ocDogadjajListBox�� �� Path$ SelectedItem�.@�5N      �� $
 
Horizontal=�6   $	��Top=�62   .+�5O      �� $��14(�6   $
��Bold"�6&   .��68   	Oznaka:6A   �� 5P      -   5        $��oznakaLabel��5P   3   $	��130��6F   $��14(�6R   $
��Bold"�6`   $��Italic$�6r   ��6   �� *Oznaka+6�   �� 5Q      $��14(�6   $
��Bold"�6&   .��68   Naziv:6@   �� 5R      -   5        $��
nazivLabel��5R   2   $	��130��6D   $��14(�6P   $
��Bold"�6^   $��Italic$�6p   ��6   �� *Naziv+6�   �� 5S      $��14(�6   $
��Bold"�6&   .��68   Datum odrzavanja:6K   �� 5T      -   5        $��
datumLabel��5T   P   $��80��6b   $��14(�6m   $
��Bold"�6{   $��Italic$�6�   ��6   �� *%#DatumOdrzavanjaZaTekucuGodinuString+6�   �� 5U      $��14(�6   $
��Bold"�6&   .��69   Cena:6@   �� 5V      -   5        $��	cenaLabel��5V   1   $	��100��6B   $��14(�6N   $
��Bold"�6\   ��6   �� *Cena+6q   �� 5W      $��14(�6   $
��Bold"�6&   .��68   Grad i drzava:6H   �� 5X      -   5        $��gradIDrzavaLabel��5X   J   $	��150��6b   $��14(�6n   $
��Bold"�6|   $��Italic$�6�   ��6   �� *DrzavaIGradKaoMestoOdrzavanja+6�   �� 5Y      $��14(�6   $
��Bold"�6&   .��68   
Posecnost:6D   �� 5Z      -   5        $��posecenostLabel��5Z   @   $	��100��6W   $��14(�6c   $
��Bold"�6q   $��Italic$�6�   ��6   �� *PosecenostDogadjaja+6�   5[      5\      5^      5`      