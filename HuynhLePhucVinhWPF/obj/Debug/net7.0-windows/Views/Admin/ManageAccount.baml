   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HuynhLePhucVinhWPF.Views.AdminHuynhLePhucVinhWPF.Views.Admin  5   	   2    ,HuynhLePhucVinhWPF.Views.Admin.ManageAccount   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:HuynhLePhucVinhWPF.Views.Admin     5   	     � Title$  ManageAccount��5   	   $	��500��6   $
��1200��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��7* �6   .+�5   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��360��6C   $��Center=�6O   .+�5      �� 
���  ��$��DemiBold"�6%   $��20(�6;   $��Manage Account��6I   �� 5      .��6   ID6   �� 5      -   5         ��Name$ ID��5       �� 
IsReadOnly$
 True��6M   ��6"   �� *CurrentAccount.AccountId+6a   �� 5      .��6   Name6   �� 5      -   5        $
 Name��5      ��6$   �� *CurrentAccount.AccountName+6T   �� 5      .��6   Email6   �� 5      -   5        $ Email��5      ��6%   �� *CurrentAccount.AccountEmail+6U   �� 5      .��6   Role6   �� 5      -   5        $
 Role��5      ��6$   �� *CurrentAccount.AccountRole+6S   �� 5      .��6   
Password6   �� 5      -   5        $ Password��5      ��6(   �� * CurrentAccount.AccountPassword+6[   � 5       � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��btImportFile��5   <   $��70��6   $��25��6$   $��10q�60   ��6P   �� *ReloadCommand+.��6s   ReLoad6{   �� 5      -   5        $��btAdd��5   <   $��55��6   $��25��6$   $��10q�60   ��6I   �� *AddAccountCommand+.��6p   Add6u   �� 5      -   5         ��Name$ btUpdate��5   <   $��65��6   $��25��6$   $��10q�60   ��6N   �� *UpdateAccountCommand+.��6w   Update6   �� 5      -	   5        $��btDelete��5   <   $��79��6   $��25��6$   $��10q�60   ��6L   �� *DeteleAccountCommand+.��6u   Delete6}   �� 5       -
   5        $��btReport��5    <   $��79��6   $��25��6$   $��10q�60   ��6L   �� *ReportNewsCommand+.��6r   	Statistic6}   5!      5"      �� 5$   
   $��1��6   $��Center=�6%   $	��840��6B   .+�5%      �� ��6   �� *
Accounts+ �� SelectedItem 69   �� *CurrentAccount+ �� View 5&      �� 5'      .P�5(      �� $��ID��6)   	 �� Width$	 25��65   
 �� DisplayMemberBinding
 6@   ��  �� Path$ 	AccountId��� 5)      $
��Name��6)   $		 170��67   
 6C   �� $ AccountName��� 5*      $��Email��6)   $		 290��68   
 6D   �� $ AccountEmail��� 5+      $
��Role��6)   $	 75��67   
 6B   �� $ AccountRole��� 5,      $��Password��6)   $		 180��6;   
 6G   �� $ AccountPassword�5-      5/      50      51      52      