   M S B A M L   `   `   `  ????K  GCritterpediaPlus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CritterpediaPlusCritterpediaPlus  5   	   +    %CritterpediaPlus.UpdatePasswordWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CritterpediaPlus     5   	     ? Title$  ChangePassword??5   	   $	??450??6    $	??800??6-   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      $	??160 ?6   6-   ?? 5      $	??220 ?6   6-   ?? 5      6!   .+?5   
   ?? -   5         ??Name$ 	lblHeader??5      $??0??6#   $??2??60   $??24(?6D   $??75,0,0,0q?6R   $
??Left=?6d   $??Bottom=?6   .??6?   Change Password6?   ?? 5   
   -   5        $ lblLoginName??5      $??1??6&   $??	0 30 10 0q?63   $??Right=?6F   .??6i   
User Name:6u   ?? 5   
   -   5         ??Name$ txtLoginName??5      $??1??6(   $??1??65   $??0 35 0 0q?6E   6Y   ?? 5   
   -   5        $ lblOldPassword??5      $??2??6(   $??	0 30 10 0q?65   $??Right=?6H   .??6k   Old Password:6z   G? 5   
   -   5         G?Name$ pwdOldPassword??5      $??2??6.   $??1??6;   $??0 35 0 0q?6K   ?? 5   
   -   5        $ lblNewPassword??5      $??3??6(   $??	0 30 10 0q?65   $??Right=?6H   .??6k   New Password:6z   G? 5   
   -   5        $ pwdNewPassword??5      $??3??6.   $??1??6;   $??0 35 0 0q?6K   ?? 5   
   -   5        $ lblConfirmPassword??5      $??4??6,   $??	0 30 10 0q?69   $??Right=?6L   .??6o   Confirm Password:6?   G? 5    
   -	   5        $ pwdConfirmPassword??5       $??4??62   $??1??6?   $??0 35 0 0q?6O   ?? 5!   
   -
   5         ??Name$ 
btnConfirm??5!      $??5??6%   $??1??62   $
??25 5q?6B   $
??Left=?6R   $	??Top=?6m   $??0,20,0,0q?6?   $??16(?6?   .??6?   	Confirm6?   ?? 5"   
   -   5        $ 	btnCancel??5"      $??5??6$   $??1??61   $
??25 5q?6A   $??Right=?6Q   $	??Top=?6m   $??0,20,0,0q?6?   $??16(?6?   .??6?   Cancel6?   ?? 5#   
   $??6??6   $??3??6!   $??Bottom=?65   $
??30px??6P   .@?5$      ?? -   5         ??Name$ 
StaMessage??5$      $Q??KPlease enter your login information and a new password, then click Confirm.??60   $??	20px, 0pxq?6?   5%      ?? 5&   
   -   5         ??Name$ imgLogin??5&      $??0??6"   $??6??6/   $??2??6@   $0??*pack://siteoforigin:,,,/Resources/Leaf.png??6P   6?   5'      5(      