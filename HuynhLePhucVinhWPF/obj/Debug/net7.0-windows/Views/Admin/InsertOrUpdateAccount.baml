   M S B A M L   `   `   `  ����M  IHuynhLePhucVinhWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HuynhLePhucVinhWPF.Views.AdminHuynhLePhucVinhWPF.Views.Admin  5   	   :    4HuynhLePhucVinhWPF.Views.Admin.InsertOrUpdateAccount   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:HuynhLePhucVinhWPF.Views.Admin     5   	     � Title$  InsertOrUpdateAccount��5   	   $	��450��6'   $	��800��64   .��5	      � .+�5
   
   �� 
����ح� �� Orientation$ Vertical=�6,   $	��700��6C   $��Center=�6O   .+�5      �� -   5         ��Name$ 
titleLabel��5   %   
���  ��$��DemiBold"�69   $��20(�6O   �� 5      .��6   ID6   �� 5      -   5         ��Name$ ID��5       �� 
IsReadOnly$
 True��6M   ��6"   �� *CurrentAccount.AccountId+6a   �� 5      .��6   Name6   �� 5      -   5        $
 Name��5      ��6$   �� *CurrentAccount.AccountName+6T   �� 5      .��6   Email6   �� 5      -   5        $ Email��5      ��6%   �� *CurrentAccount.AccountEmail+6U   �� 5      .��6   Role6   �� 5      -   5        $
 Role��5      ��6$   �� *CurrentAccount.AccountRole+6S   �� 5      .��6   
Password6   �� 5      -   5        $ Password��5      ��6(   �� * CurrentAccount.AccountPassword+6[   � 5       � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $
��btOK��5   <   $��55��6   $��25��6$   $��10q�60   ��6H   �� *AddAccountCommand+��6n   ��  �� RelativeSource ��  �� AncestorType
 Window6�   �� 5      -   5         ��Name$ btUpdate��5   <   $��65��6   $��25��6$   $��10q�60   ��6N   �� *UpdateAccountCommand+��6w   ��  �� 
 Window6�   �� 5      -	   5        $��btClose��5   <   $��79��6   $��25��6$   $��10q�60   ��6K   �� *CloseAccountCommand+��6s   ��  �� 
 Window.��6�   Close6�   5      5      5      5      