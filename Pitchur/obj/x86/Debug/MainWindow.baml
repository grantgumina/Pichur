   M S B A M L   `   `   `  ����`  \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35tNclr-namespace:Microsoft.Windows.Controls.Ribbon;assembly=RibbonControlsLibrary!Microsoft.Windows.Controls.Ribbon  5   	   
 Pichur   Pichur.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   aribbonNclr-namespace:Microsoft.Windows.Controls.Ribbon;assembly=RibbonControlsLibrary     5   	   -   5        4   .Microsoft.Windows.Controls.Ribbon.RibbonWindow   Name$  RibbonWindow��5       � Title$ Pichur��5   	   $	��385��5      $	��533��6    � 
ResizeMode$ 	CanResize=�6O    � WindowStartupLocation$ CenterScreen=�6f   ���	#FF270909���	#FFEDF3F9 � Icon$) #/Pichur;component/Images/camera.png��6�   $	��385��6!  $	��385��60  $	��533��6?  $	��533��6O  .��5      � -   5         �Name$ 
LayoutRoot��5      $	��436��6   ���	#FFEDF3F9 � ColumnDefinitions 5	      �� 5
      $
��154* �6   �� 5      $
��386* �6    � RowDefinitions 5      �� 5      $	��105 �6   �� 5      $
��331* �6   .+�5      .   (Microsoft.Windows.Controls.Ribbon.Ribbon  -   5          Name$ Ribbon��5      $��
-1,-40,1,5q�6"   $	��174��66   $��2��6C   	   ApplicationMenu	 5      =   7Microsoft.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�	Collapsed=�6#   8   2Microsoft.Windows.Controls.Ribbon.RibbonMenuButton
   SmallImageSource$
 Images\SmallIcon.png��6:   .@�5      A   ;Microsoft.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   5          Name$ 	MenuItem1��5   7   $��App Menu��5   (   6   0Microsoft.Windows.Controls.Ribbon.RibbonMenuItem   ImageSource$ Images\LargeIcon.png��5   7   5      .@�5      1   +Microsoft.Windows.Controls.Ribbon.RibbonTab  -   5          Name$ 
EffectsTab��5      $��Effects��5      .@�5      3   -Microsoft.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ ClassicGroup��5      $��Classic��5   
      GroupSizeDefinitions 5      O	   IMicrosoft.Windows.Controls.Ribbon.RibbonGroupSizeDefinitionBaseCollection	  A
   ;Microsoft.Windows.Controls.Ribbon.RibbonGroupSizeDefinition
  5    	    
  ControlSizeDefinitions. 5!   
   C   =Microsoft.Windows.Controls.Ribbon.RibbonControlSizeDefinition     	ImageSize$ Large=�6-      IsLabelVisible . 6?     5"   
   $ Large=�6-    . 6?     5#   
   $ Large=�6-    . 6?     5$   
   $ Large=�6-    . 6?     5%   
   $ Large=�6-    . 6?   5&   
   5'   	   .@�5)      4   .Microsoft.Windows.Controls.Ribbon.RibbonButton  -   5          Name$ e0RibBtn��5)         LargeImageSource$ Images\cancel.png��6-      Label$
 None��6R   6_     5*      -   5        $ e1RibBtn��5*      $" Images\Effects\Grayscale.png��6-   $	 B/W��6]   6i     5+      -	   5        $ e9RibBtn��5+      $! Images\Effects\OldMovie.png��6-   $ 	Old Movie��6\   6n   5,        5-      -
   5        $ ArtisticGroup��5-      $��Artistic��5.   
    50      	  
  51   	   . 52   
     $ Large=�6-    . 6?     53   
   $ Large=�6-    . 6?     54   
   $ Large=�6-    . 6?     55   
   $ Large=�6-    . 6?     56   
   $ Large=�6-    . 6?     57   
   $ Large=�6-    . 6?   58   
   59   	   .@�5;        -   5        $ e3RibBtn��5;      $ Images\Effects\Invert.png��6-   $ Invert��6Z   6i     5<      -   5        $ e4RibBtn��5<      $$ Images\Effects\ColorAdjust.png��6-   $ Contrast Adjust��6_   6w     5=      -   5        $ e5RibBtn��5=      $ Images\Effects\Bloom.png��6-   $ Bloom��6Y   6g     5>      -   5        $ e6RibBtn��5>      $ Images\Effects\Gloom.png��6-   $ Gloom��6Y   6g     5?      -   5        $ 	e13RibBtn��5?      $ Images\Effects\Copier.png��6.   $ Copier��6[   6j   5@        5A      -   5        $ DistortionGroup��5A      $��Distort��5B   
    5D      	  
  5E   	   . 5F   
     $ Large=�6-    . 6?     5G   
   $ Large=�6-    . 6?     5H   
   $ Large=�6-    . 6?     5I   
   $ Large=�6-    . 6?   5J   
   5K   	   .@�5M        -   5        $ e7RibBtn��5M      $ Images\Effects\Swirl.png��6-   $ Swirl��6Y   6g     5N      -   5        $ e8RibBtn��5N      $ Images\Effects\Pinch.png��6-   $ Pinch��6Y   6g     5O      -   5        $ 	e10RibBtn��5O      $! Images\Effects\Pixelate.png��6.   $ Pixelate��6]   6n     5P      -   5        $ 	e11RibBtn��5P      $ Images\Effects\Ripple.png��6.   $ Ripple��6[   6j   5Q      5R        5S      -   5        $ DoneTab��5S      $��Save and Upload��6(   .@�5T        -   5        $ 	saveGroup��5T      .@�5U        -   5        $ saveBtn��5U      $ Images\save.png��6-   $
 Save��6P   6]   5V        5W      -   5        $ uploadGroup��5W      $��Upload��6/   .@�5X        -   5        $ 	uploadBtn��5X      $ Images\facebook.png��6/   $ Facebook��6V   6g   5Y      5Z      5[      �� 5\      -   5        $��
captureBtn��5\   T   $��1��6   $��61��6   $
��Left=�6$   $��136,270,0,0q�6?   $	��Top=�6f   $��90��6~   $��2��6�   .��5]      �� -   5         ��Name$ captureIcon��5]      $��Images/camera.png��6    5^      �� 5_      -   5        $��
refreshBtn��5_   T   $��1��6   $��30��6   $
��Left=�6$   $��185,289,0,0q�6?   $	��Top=�6f   $��58��6~   $��1��6�   |�.  .��5`      �� $��Images/refresh.png��6   5a      �� 5b      -   5        $��border1��5b   �   
�������$��1q�6    $��2��64   $��1��6H   $	��247��6U   $
��Left=�6b   $��	18,12,0,0q�6}   $	��Top=�6�   $	��329��6�   ._�5c      �� -   5        $��camImg��5c      ��5d      �� 5e       �� 	UriSource$  ?�6   5g      5h      5i      5j      