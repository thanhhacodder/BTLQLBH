   M S B A M L   `   `   `  ����H  DQuanLyBanHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLyBanHangQuanLyBanHang  5   	       QuanLyBanHang.DangNhap   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLyBanHang     5   	     � Title$  Đăng nhập��5   	   $	��340��6   $	��550��6(    � WindowStartupLocation$ CenterScreen=�64    � Icon$ Images/icon.ico��6Y    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  '��       �� 5
   
   " ��6   .�5      ��  � ��
 � � �6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ Border1��6%   #��z��66   
���   �$��0q�6t   ._�5   "   �� $��Center=�63   $��Center=�6P   5      5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   �� $ Border1��6)    � �� �#F7D3586T   5      5      5      5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5       $
��1.5* �6   �� 5!      $��5* �6   �� 5"      $��* �6   .+�5$   
   � $��0��6   
����+��$��0,0,0,10q�65   .+�5%      �� $��0,5,0,11q�6   $��Center=�6*   $
��Bold"�6G   $��25(�6Y   
�������$	��146��6z   Đăng nhập6�   5&      �� 5'   
   $��1��6   $��	0,32,0,38q�6"   $��Center=�65   .+�5(      �� 
�������$��3,0,0,3q�6)   $��42��6C   $	��308��6O   ._�5)      � $��0,10,0,0q�6   $��Stretch=�6/   .+�5*      �� $��50��6   $
��auto��6'   $��images/User-Yellow.png��5+      6:   �� 5,      -   5        $��txtTaiKhoan��5,      $��18(�61   $��25��6?   $	��244��6K   5-      5.      �� 5/      $��0,2,0,0q�6   
�������$��3,0,0,3q�69   $	��308��6S   $��41��6_   ._�50      � $��0,10,0,0q�6   $��Stretch=�6.   .+�51      �� $��50��6   $
��auto��6'   $��images/Key-Yellow.png��52      69   G� 53      -   5        $��passMatKhau��53   "   $��18(�65   $	��245��6C   $��26��6O   54      55      �� 56      -   5        $��btnDangNhap��56      
���   � �� 	IsDefault . 
���/���$��22(�6e   $��Center=�6s   $��41��6�   $��0,10,0,0q�6�   $	��138��6�   .��6�   Đăng nhập6�   57      � 58   
   $��2��6   
����+��.+�59      �� $��0,15,6,0q�6   $��13(�6*   $
��Bold"�68   ���#FFF$��Right=�6]   $"Ứng dụng quản lý bán hàng6�   5:      5<      5=      