   M S B A M L   `   `   `  ����F  BTP4_CHEKATT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TP4_CHEKATT.ViewTP4_CHEKATT.View  5   	   %    TP4_CHEKATT.View.HelloWorldView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TP4_CHEKATT.View     5   	   -   5          �Name$  wMain��5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   
   $��13(�5
   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
   ���	#FF303030  MaterialDesignFont#���  5   
    � Title$ HelloWorldView��5   	   $��528.561��6    $��971.498��61   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��261* �6   �� 5      $
��710* �6   .+�5   
   �� -   5         ��Name$ 
lbxJoueurs��5      $
��Left=�6&   $	��283��6A   $��
40,120,0,0q�6N   $	��Top=�6b   $	��214��6z   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   $��2q�6�   ���	#26FFFFFF6�   �� 5   
   -   5         ��Name$ btnShopping��5      $��Shopping��6&   $
��Left=�69   $��
168,23,0,0q�6T   $	��Top=�6h   $	��114��6�   $��2��6�   �� 5   
   -   5        $ btnApparence��5      $��	Apparence��6'   $
��Left=�6;   $��	30,23,0,0q�6V   $	��Top=�6i   $	��114��6�   6�   �� 5   
   -   5        $ btnAjouterJoueur��5      $��Ajouter un joueur��6+   $
��Left=�6G   $��
74,412,0,0q�6b   $	��Top=�6v   $	��148��6�   ���	#FF46A22B���	#FF46A22B$��25��6�    � Cursor$
 Hand��6�   �� 5   
   -   5        $ btnSupprimerJoueur��5      $��Supprimer un joueur��6-   $
��Left=�6K   $��
62,444,0,0q�6f   $	��Top=�6z   $	��172��6�   ���	#FFC12727���	#FFC12727$��26��6�   �� 5   
   -   5        $ btnSupprimerArme��5      $	��✖��6+   $
��Left=�67   $��389,423,0,0q�6R   $	��Top=�6g   $��51��6   ���	#FFC12727���	#FFC12727$��32��6�   $��1��6�   �� 5   
   -   5        $ btnAjouterArme��5      $	��➕��6)   $
��Left=�65   $��309,423,0,0q�6P   $	��Top=�6e   $��50��6}   ���	#FF46A22B���	#FF46A22B$��32��6�   $��1��6�   &   System.Windows.Controls.DataGrid  5#   
   -	   5        	  Name$	 dgArmes��5#      
   
IsReadOnly
 . $
��Left=�66   $	��156��6Q   $��
70,247,0,0q�6^   $	��Top=�6r   $	��604��6�   $��2q�6�   ���	#26FFFFFF$��1��6�      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Nom+  5&      $ Dégâts min��6%    69   �� *DegatMinimum+  5'      $ Dégâts max��6%    69   �� *DegatMaximum+  5(      $ Type d'arme��6%    6:   �� *
ArmeType+  5)      $ Temps de rechargement��6%    6D   �� *TempsRechargement+5+      �� 5.   
   $��Vaisseau du Joueur :��6   $
��Left=�6/   $��
286,42,0,0q�6J   $	��Top=�6^   $��1��6v   �� 5/   
   -
   5         ��Name$ lblNomJoueur��5/      $��Label��6&   $
��Left=�66   $��
426,42,0,0q�6Q   $	��Top=�6e   $��1��6}   �� 50   
   $��Nom :��6   $
��Left=�6    $��
218,91,0,0q�6;   $	��Top=�6O   }�. $��1��6{   �� 51   
   -   5        $ lblVaisseauJoueur��51      $��Label��6+   $
��Left=�6;   $��
298,91,0,0q�6V   $	��Top=�6j   $��1��6�   �� 52   
   $��Structure :��6   $
��Left=�6&   $��218,122,0,0q�6A   $	��Top=�6V   }�. $��1��6�   �� 53   
   -   5        $ lblStructureVaisseau��53      $��Label��6.   $
��Left=�6>   $��298,122,0,0q�6Y   $	��Top=�6n   $��1��6�   �� 54   
   $��
Bouclier :��6   $
��Left=�6%   $��218,153,0,0q�6@   $	��Top=�6U   }�. $��1��6�   �� 55   
   -   5        $ lblBouclierVaisseau��55      $��Label��6-   $
��Left=�6=   $��298,153,0,0q�6X   $	��Top=�6m   $��1��6�   �� 56   
   -   5        $ lblBouclierVaisseau_Copy��56      $��Dégâts moyens :��62   $
��Left=�6L   $��218,184,0,0q�6g   $	��Top=�6|   }�. $��1��6�   �� 57   
   -   5        $ lblDegatMoyenVaisseau��57      $��Label��6/   $
��Left=�6?   $��338,184,0,0q�6Z   $	��Top=�6o   $��1��6�   �� 58   
   -   5         ��Name$ imgVaisseau��58      $��1��6%   $
��Left=�65   $	��100��6P   $��
520,91,0,0q�6]   $	��Top=�6q   $	��100��6�   59      5:      