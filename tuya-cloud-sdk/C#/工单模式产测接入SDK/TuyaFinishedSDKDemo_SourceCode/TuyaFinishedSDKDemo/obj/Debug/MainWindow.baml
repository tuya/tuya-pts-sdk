   M S B A M L   `   `   `  ����N  JTuyaFinishedSDKDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TuyaFinishedSDKDemoTuyaFinishedSDKDemo  5      $    TuyaFinishedSDKDemo.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.5.1.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      -local!clr-namespace:TuyaFinishedSDKDemo  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � Title$)  #工单模式产测接入SDK 1.0.0.0��5      $	��800��5	      $	��450��5
       � Icon$ Tuya.ico��5       � DataContext 5      �� 5   
    �� Path$ MainVM�6      Locator �� Source# [  6    .��5      � (  "HandyControl.Controls.TitleElement   TitlePlacement$
 Left=�6      
TitleWidth$ 90 �60    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��10q�6   .+�5      �� $��20,0,0,0q�6   $��Center=�6*   ��6E   �� *
Infomation+5      � 5   
   -   5         �Name$ 	LoginGrid��5      $��1��6"   y�6/   �� *	IsLogin+ ! Boolean2VisibilityReConverter	 �� 	Converter#	 [ .+�5      '  !HandyControl.Controls.SimplePanel  -   5        
  Name$
 LoginSimplePanel��5      $��Center=�67   $��Center=�6T   .+�5      �� $��Center=�6   .+�5      �� .+�5      #  HandyControl.Controls.TextBox     Title$ 	用户名��6%   ��6A   �� *
UserName+  5      $ 密码��6%   ��6@   �� *
Password+5       �� 5!      -   5         ��Name$ LoginButton��5!      $	��120��5"      $��20q�5#      $��Right=�5$      $��登录��5'        ButtonSuccess#��[ 5(      ��5%      �� *TuyaButtonCommand+��5&      ��  �� ElementName$ LoginButton��5(      5)      5+      5-      � 5.   
   $��1��6   y�6   �� *	IsLogin+  Boolean2VisibilityConverter#	 [ .+�5/        -   5        $
 ProductTransitSimplePanel��5/      $��Center=�6@   $��Center=�6]   .+�50      �� $��Center=�6   .+�51      �� .+�52      �  � ColumnDefinitions 53      �� 54   "   $��* �63   �� 55   "   $
��auto �63   .+�57        -   5          Name$ WorkOrderTextBox��57   )   $	��0,2q�58   )   $ 工单��59   )   ��5<   )   �� *	WorkOrder+�� 5=      -   5        $ WorkOrderButton��5=   %   $��1��5>   %   $	��5,2q�5?   %   $��Right=�5@   %   $��确定��5C   %   #��[ 5D   %   ��5A   %   �� *TuyaButtonCommand+��5B   %   �� $ WorkOrderButton��5D   %   5E        5F      $	��0,2q�6%   $ 产品信息��5G   %    �� 
IsReadOnly . ��5I   %   �� *ProductModel+$  HandyControl.Controls.ComboBox  5J      $	��0,2q�6&   $ 工序��5K   &    �� DisplayMemberPath$
 desc��5L   &   ��5M   &   �� *
NodeList+ �� SelectedValue 5N   &   �� *	OrderNode+ �� Mode$ TwoWay=�  5O      $	��0,2q�6%   $ SN��62   ��6M   �� *	ProductSN+5P      � 5R      $
��0,20q�6    5S      �� 5T      $��* �6/   �� 5U      $
��auto �6/   �� 5V      $
��auto �6/   .+�5X      �� $��Center=�6$   ��6?   �� *MessageInfo+�� 5Y      -   5        $ ProductTransitButton��5Y   !   $��2��5Z   !   $	��120��5[   !   $
��10,0q�5\   !   $��Right=�5]   !   $��成品过站��5`   !   #��[ 5a   !   ��5^   !   �� *TuyaButtonCommand+��5_   !   �� $ ProductTransitButton��5a   !   �� 5b      -	   5        $ ProductionTestLogUpload��5b   !   $��1��5c   !   $	��120��5d   !   $��Right=�5e   !   $��日志上报��5h   !   #��[ 5i   !   ��5f   !   �� *TuyaButtonCommand+��5g   !   �� $ ProductionTestLogUpload��5i   !   5j      5l      5n      5p      � 5q   
   -
   5        $
 XXXX��5q      $��2��5r      
������� J� Opacity$	 0.5Q�5t      $y�	Collapsed=�5u      .+�5v      '  !HandyControl.Controls.LoadingLine  $
��0,30q�6   
���  ��$ 1Q�5x        LoadingLineLarge#��[ 5y      5z      5|      5}      