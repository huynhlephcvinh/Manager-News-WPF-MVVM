   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HuynhLePhucVinhWPFHuynhLePhucVinhWPF  5      &     HuynhLePhucVinhWPF.CategoryPage1   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HuynhLePhucVinhWPF     5        N� Title$  CategoryPage1��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��5* �6   .+�5   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��300��6C   $��Center=�6O   .+�5      �� 
���  ��$��DemiBold"�6%   $��20(�6;   $��Manage Category��6I   �� 5      .��6   ID6   �� 5      -   5         ��Name$ ID��5       �� 
IsReadOnly$
 True��6O   ��6"   �� *CurrentCategory.CategoryId+6c   �� 5      .��6   Name6   �� 5      -   5        $
 Name��5      ��6%   �� *CurrentCategory.CategoryName+6W   �� 5      .��6   Description6!   �� 5      -   5        $ Description��5      $��30��6+   ��67   �� *$"CurrentCategory.CategoryDesciption+6n   � 5       � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��btImportFile��5   <   $��70��6   $��25��6$   $��10q�60   ��6P   �� *ReloadCommand+.��6s   ReLoad6{   �� 5      -   5        $��btAdd��5   <   $��55��6   $��25��6$   $��10q�60   ��6I   �� *AddCategoryCommand+.��6q   Add6v   �� 5      -   5         ��Name$ btUpdate��5   <   $��65��6   $��25��6$   $��10q�60   ��6N   �� *UpdateCategoryCommand+.��6x   Update6�   �� 5      -   5        $��btDelete��5   <   $��79��6   $��25��6$   $��10q�60   ��6L   �� *DeteleCategoryCommand+.��6v   Delete6~   5      5      �� 5!   
   $��1��6   $��Center=�6%   $	��500��6B   .+�5"      �� ��6   �� *
Categories+ �� SelectedItem 6;   �� *CurrentCategory+ �� View 5#      �� 5$      .P�5%      �� $��ID��6)   	 �� Width$	 50��65   
 �� DisplayMemberBinding
 6@   ��  �� Path$ 
CategoryId��� 5&      $
��Name��6)   $		 150��67   
 6C   �� $ CategoryName��� 5'      $��
Desciption��6)   $		 280��6=   
 6I   �� $ CategoryDesciption�5)      5+      5,      5-      5.      