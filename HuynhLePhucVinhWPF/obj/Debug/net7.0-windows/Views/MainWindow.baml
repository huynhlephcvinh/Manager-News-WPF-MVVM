   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HuynhLePhucVinhWPFHuynhLePhucVinhWPF  5   	   #    HuynhLePhucVinhWPF.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HuynhLePhucVinhWPF     5   	     � Title$  
MainWindow��5   	   $	��500��6   $
��1200��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��109��6C   $��Center=�6O   .+�5      �� -   5        $��btLogin��5   8   $��55��6   $��25��6    $��10q�6,   ��6G   �� *LoginCommand+.��6i   Login6p   5      �� 5   
   $��1��6   $
��Auto=�6'   .��5      �� $��1��6   $
��1091��6)   .+�5      �� ��6   �� *NewsArticles+��5      �� 5      .R�5      �� 
���   �$��1q�69   $��5q�6M    �� Padding$ 10q�6X   ._�5   "   �� .+�5   &   �� $
��Bold"�6K   $��16(�6]   ��60   �� *	NewsTitle+6]   �� 5   &   $
��Wrap=�6M   $��0,10,0,0q�6a   ��60   �� *NewsContent+6a   �� 5!   &   $��Italic$�6W   
�������$
��Left=�6|   $��0,10,0,0q�6�   ��60   �� *Category.CategoryName+6�   �� 5#   &   $��Tags:��60   $
��Bold"�6=   $��10q�6O   �� 5$   &    �� DisplayMemberPath$ TagName��6K   $��10q�6g   ��6.   �� *Tags+6g   5%   #   5&      5'      5)      5*      5+      5/      50      