   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HuynhLePhucVinhWPF.Views.StaffHuynhLePhucVinhWPF.Views.Staff  5   	   7    1HuynhLePhucVinhWPF.Views.Staff.InsertOrUpdateNews   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:HuynhLePhucVinhWPF.Views.Staff     5   	     � Title$  InsertOrUpdateNews��5   	   $	��550��6$   $	��800��61   .��5	      � $��0,0,0,22q�6   .+�5
   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��750��6C   $��Center=�6O   $��	0,0,0,116q�6l   .+�5      �� -   5         ��Name$ 
titleLabel��5   %   
���  ��$��DemiBold"�69   $��20(�6O   �� 5      .��6   ID6   �� 5      -   5         ��Name$ ID��5       �� 
IsReadOnly$
 True��6M   ��6"   �� *CurrentNews.NewsArticleId+6a   �� 5      .��6   Title6   �� 5      -   5        $ Title��5      ��6&   �� *CurrentNews.NewsTitle+6O   �� 5      .��6   	Content6   �� 5      -   5        $ Content��5   "   $��40��6   ��63   �� *CurrentNews.NewsContent+�� 5      .��6   
Category6   �� 5      -   5         ��Name$ 
cbCategory��5       �� DisplayMemberPath$ CategoryName��6N    �� SelectedValuePath$ 
CategoryId��6o   $	��400��6�   $
��Left=�6�   ��6+   �� *
Categories+ �� SelectedValue 6�   �� *CurrentNews.CategoryId+	 �� Mode$	 TwoWay=�6�   � 5      
 � Orientation$
 
Horizontal=�6   .+�5      �� -   5        $
��btOK��5   <   $��55��6   $��25��6$   $��10q�60   ��6H   �� *OKNewsCommand+��6j   ��  �� RelativeSource ��  �� AncestorType
 Window6�   �� 5      -   5         ��Name$ btUpdate��5   <   $��65��6   $��25��6$   $��10q�60   ��6N   �� *UpdateNewsCommand+��6t   ��  �� 
 Window6�   �� 5      -   5        $��btDelete��5   <   $��79��6   $��25��6$   $��10q�60   ��6L   �� *CloseNewsCommand+��6q   ��  �� 
 Window.��6�   Close6�   5      5      5      5      