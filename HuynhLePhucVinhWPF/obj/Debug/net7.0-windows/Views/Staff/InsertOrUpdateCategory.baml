   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HuynhLePhucVinhWPFHuynhLePhucVinhWPF  5   	   /    )HuynhLePhucVinhWPF.InsertOrUpdateCategory   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HuynhLePhucVinhWPF     5   	     � Title$  InsertOrUpdateCategory��5   	   $	��300��6(   $	��500��65   .��5	      � .+�5
   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��450��6C   $��Center=�6O   .+�5      �� -   5         ��Name$ 
titleLabel��5   %   
���  ��$��DemiBold"�69   $��20(�6O   �� 5      .��6   ID6   �� 5      -   5         ��Name$
 tbID��5       �� 
IsReadOnly$
 True��6P   ��6$   �� *CurrentCategory.CategoryId+6d   �� 5      .��6   Name6   �� 5      -   5        $ tbName��5      ��6'   �� *CurrentCategory.CategoryName+6X   �� 5      .��6   Description6!   �� 5      -   5        $ tbDescription��5      $��30��6-   ��69   �� *$"CurrentCategory.CategoryDesciption+6p   � 5       � Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$
 btOK��5   <   $��55��6   $��25��6$   $��10q�60   ��6J   �� *OKCategoryCommand+��6p   ��  �� RelativeSource ��  �� AncestorType
 Window6�   �� 5      -   5        $ btUpdate��5   <   $��55��6   $��25��6$   $��10q�60   ��6N   �� *ChangeCategoryCommand+��6x   ��  �� 
 Window6�   �� 5      -   5        $ btClose��5   <   $��65��6   $��25��6$   $��10q�60   ��6M   �� *CloseCategoryCommand+��6v   ��  �� 
 Window.��6�   Close6�   5      5      5      5      