   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HuynhLePhucVinhWPF.Views.StaffHuynhLePhucVinhWPF.Views.Staff  5      -    'HuynhLePhucVinhWPF.Views.Staff.TagPage3   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:HuynhLePhucVinhWPF.Views.Staff     5        N� Title$  TagPage3��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��5* �6   .+�5   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��300��6C   $��Center=�6O   .+�5      �� 
���  ��$��DemiBold"�6%   $��20(�6;   $��
Manage Tag��6I   �� 5      .��6   ID6   �� 5      -   5         ��Name$ ID��5       �� 
IsReadOnly$
 True��6E   ��6"   �� *CurrentTag.TagId+6Y   �� 5      .��6   Name6   �� 5      -   5        $
 Name��5      ��6%   �� *CurrentTag.TagName+6M   �� 5      .��6   Note6   �� 5      -   5        $ Description��5      $��30��6+   ��67   �� *CurrentTag.Note+6[   � 5       � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��btImportFile��5   <   $��70��6   $��25��6$   $��10q�60   ��6P   �� *ReloadCommand+.��6s   ReLoad6{   �� 5      -   5        $��btAdd��5   <   $��55��6   $��25��6$   $��10q�60   ��6I   �� *AddTagCommand+.��6l   Add6q   �� 5      -   5         ��Name$ btUpdate��5   <   $��65��6   $��25��6$   $��10q�60   ��6N   �� *UpdateTagCommand+.��6s   Update6{   �� 5      -   5        $��btDelete��5   <   $��79��6   $��25��6$   $��10q�60   ��6L   �� *DeteleTagCommand+.��6q   Delete6y   5      5      �� 5!   
   $��1��6   $��Center=�6%   $	��500��6B   .+�5"      �� ��6   �� *Tags+ �� SelectedItem 65   �� *
CurrentTag+ �� View 5#      �� 5$      .P�5%      �� $��ID��6)   	 �� Width$	 50��65   
 �� DisplayMemberBinding
 6@   ��  �� Path$ TagId��� 5&      $
��Name��6)   $		 150��67   
 6C   �� $ TagName��� 5'      $
��Note��6)   $		 280��67   
 6C   �� $
 Note�5)      5+      5,      5-      5.      