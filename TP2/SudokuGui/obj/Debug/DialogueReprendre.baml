   M S B A M L   `   `   `  ����  	SudokuGui"    Sudoku.Gui.DialogueReprendre   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � ShowInTaskbar  .   � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Reprendre une partie��5   	   $	��500��6&   $	��300��63   .��5      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��listeDeParties��5
      $��0,0,0,35q�6)      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Date de sauvegarde��6&      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 275 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6`   �� *Item2+  5      $ Identifiant��6&   	   
Visibility$	 Hidden=�6;    . $ 0 6a    6k   �� *Item1+5      �� 5   
   -   5        $��	reprendre��5      $��	Reprendre��6"   $
��Left=�66   $��
52,441,0,0q�6Q   $��75��6e   6p   �� 5   
   -   5        $��annuler��5      $��Annuler��6    $
��Left=�62   $��160,441,0,0q�6M   $��75��6b   6m   5      5      