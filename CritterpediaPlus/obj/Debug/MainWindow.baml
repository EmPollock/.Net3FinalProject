   M S B A M L   `   `   `  ????K  GCritterpediaPlus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CritterpediaPlusCritterpediaPlus  5   	   !    CritterpediaPlus.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CritterpediaPlus     5   	   -   5          ?Name$  frmMainWindow??5   	    ? Title$ 
MainWindow??5	   	   $	??450??6   $	??800??6)   .??5
      ?  ? RowDefinitions 5   
   ?? 5      6   ?? 5      $
??30px ?6   6,   .+?5   
   ?? -   5         ??Name$ 
tabsetMain??5      $??0??6)   .@?5      ?? -   5         ??Name$ tabHome??5   $   $
??Home??6   $
??20px(?65   .??5      ?  5      ?? 5      $
??30px ?6(   68   ?? 5      $
??70px ?6(   68   ?? 5      $
??30px ?6(   68   ?? 5      $
??40px ?6(   68   .+?5      ?? -   5         ??Name$ 
lblWelcome??5      $??1??60   $??40(?6=   $??50px 0pxq?6K   .??6]   Welcome to Critterpedia Plus!6|   ?? 5      -   5        $ lblSubWelcome??5      $??3??63   $??20(?6@   $??50px 0pxq?6N   .??6`   Please log in to continue.6|   5      5      ?? 5      -   5        $ tabMyCritterpedia??5   /   $??My Critterpedia??6   $
??20px(?6J   .??5      ?  5      ?? 5      $
??60px ?6(   68   ?? 5       $
??30px ?6(   68   ?? 5!      6*   ?? 5"      $
??30px ?6(   68   .+?5$      ?? -   5        $ lblMyCrittersHeader??5$      $??0??69   $??40(?6F   $??50px 0pxq?6T   .??6f   My Critters6s   ? 5%      $??2??6    5&      ?? 5'      6.   ?? 5(      6.   ?? 5)      6.   5+      &   System.Windows.Controls.DataGrid  5,      -   5          Name$ datMyCritters??5,      $??2??66      SelectionMode$ Single=?6C      
IsReadOnly . $??12(?6l   	   AutoGenerateColumns	 . 
   Columns
 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Critter Name??61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   ?? *	CritterId+6g     5/      $
 Type??61    6?   ?? *CritterTypeId+6c     50      $ Seasonality??61    6F   ?? *CatchableMonthString+6q     51      $ Active Hours??61    6G   ?? *CatchableHourString+6q     52      $ Price??61    6@   ?? *Price+6\   4  .System.Windows.Controls.DataGridCheckBoxColumn  53      $ 	In Museum??65    6H   ?? *
InMuseum+6g     54      $ Put into the Museum by??61    6Q   ?? *
MuseumBy+6p   56      57      58      ?? 59      -	   5        $ tabAllCritters??59   ,   $??All Critters??6   $
??20px(?6D   $??33??6w   $??-2.143,-2,-2.429,-0.143q?6?   $??Bottom=?6?   .??5:      ?  5;      ?? 5<      $
??60px ?6(   68   ?? 5=      $
??30px ?6(   68   ?? 5>      6*   ?? 5?      $
??30px ?6(   68   .+?5A      ?? -
   5        $ lblAllCrittersHeader??5A      $??0??6:   $??40(?6G   $??50px 0pxq?6U   .??6g   All Critters6u     5B      -   5        $ datAllCritters??5B      $??2??67   $ Single=?6D    . $??12(?6m   	 .  
 5C        5D      $ Critter Name??61    6G   ?? *	CritterId+6g     5E      $
 Type??61    6?   ?? *CritterTypeId+6c     5F      $ Seasonality??61    6F   ?? *CatchableMonthString+6q     5G      $ Active Hours??61    6G   ?? *CatchableHourString+6q     5H      $ Price??61    6@   ?? *Price+6\     5I      $ Caught by Me??65    6K   ?? *CaughtByCurrentUser+6u     5J      $ Caught By...??61    6G   ?? *UserCaughtDateString+6r   5L      ?? 5M      -   5         ??Name$ btnAddCritter??5M   *   $??4??6   $??150px??6A   $??Right=?6O   $??0,0,30,0q?6k   .??6?   Add Critter6?   5N      5O      ?? 5P      -   5        $ tabLogIn??5P   &   $??Log In??6   $
??20px(?6U   .??5Q      ?  5R      ?? 5S      6*   ?? 5T      6*   ?? 5U      6*   ?? 5V      6*    ? ColumnDefinitions 5X      ?? 5Y      $	??160 ?6+   69   ?? 5Z      $	??220 ?6+   69   ?? 5[      6-   .+?5]      ?? -   5        $ 	lblHeader??5]      $??0??6/   $??24(?6<   $??75,0,0,0q?6J   $
??Left=?6\   $??Bottom=?6w   .??6?   Log In6?   ?? 5^      -   5        $ lblLoginName??5^      $??1??62   $??
0 30 10 30q?6?   $??Right=?6S   $
??12px(?6v   .??6?   
User Name:6?   ?? 5_      -   5         ??Name$ txtLoginName??5_      $??1??64   $??1??6A   $??	0 35 0 35q?6Q   $??12(?6d   $
??30px??6r   6?   ?? 5`      -   5        $ lblPassword??5`      $??2??61   $??	0 0 10 60q?6>   $??Right=?6Q   $
??12px(?6t   .??6?   	Password:6?   G? 5a      -   5         G?Name$ pwdPassword??5a   "   $??2??67   $??1??6D   $??0 0 0 70q?6T   $??12(?6f   $
??30px??6t   ?? 5b      -   5        $ btnChangePassword??5b      $??5??68   $??0??6E   $??2??6U   $
??25 5q?6i   $??Right=?6y   $	??Top=?6?   $??
0,20,110,0q?6?   $??16(?6?   .??6?   Change Password6   ?? 5c      -   5        $ btnLogin??5c      $??5??6/   $??1??6<   $
??25 5q?6L   $??Right=?6\   $	??Top=?6x   $??0,20,0,0q?6?   $??16(?6?    ?? 	IsDefault . .??6?   Log in6?   ?? 5d      -   5         ??Name$ imgLogin??5d      $??0??6.   $??4??6;   $??2??6L   $0??*pack://siteoforigin:,,,/Resources/Leaf.png??6\   6?   5e      5f      5g      ?? 5i   
   $??2??6   .@?5j      ?? -   5         ??Name$ 
staMessage??5j      .??60   $"Welcome! Please login to continue.6T   5k      5l      5m      