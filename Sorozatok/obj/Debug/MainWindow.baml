   M S B A M L   `   `   `  ����D  @Sorozatok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Sorozatok	Sorozatok  5   	       Sorozatok.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Sorozatok     5   	     � Title$  	Sorozatok��5   	   $��285.724��6   $��454.571��6,   $��0q�6<    J� SnapsToDevicePixels .  � 
ResizeMode$ NoResize=�6k    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � -   5         �Name$ Display��5	      $��0,0,-1,0q�6   $	��255��6.   $��Bottom=�6;   $	��448��6V    � RowDefinitions 5
   
   �� 5      $
��116* �6   �� 5      $
��129* �6    � ColumnDefinitions 5   
   �� 5      $	��57* �6   �� 5      $	��55* �6   .+�5   
   �� $��Felhasználónév��6   $
��Left=�6)   $��
157,52,0,0q�6D   $	��Top=�6X   $��Georgia)�6p   $��27��6�   $	��136��6�   $��18(�6�   $��2��6�   �� 5   
   $+��%Üdvözöllek! Kérlek jelentkezz be!��6   $
��Left=�6<   $��	50,10,0,0q�6W   $	��Top=�6j   $��24(�6�   $��Georgia)�6�   $	��365��6�   $��37��6�   $��2��6�   �� 5   
   $��Jelszó��6   $
��Left=�6!   $��190,104,0,0q�6<   $	��Top=�6Q   $��Georgia)�6i   $��27��6~   $��60��6�   $��18(�6�   $��2��6�   $��2��6�   �� 5   
   -   5         ��Name$ textBox1��5      $
��Left=�6$   $��26��6?   $��
118,79,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��216��6�   $��2��6�   $��16(�6�   $��Georgia)�6�   �� 5   
   -   5        	 ��Name$		 log��5      $��Bejelentkezés��6   $
��Left=�66   $��
157,46,0,0q�6Q   $	��Top=�6e   $	��136��6}   $��34��6�   $��2��6�   $��1��6�   
 � Cursor$

 Hand��6�   
���   �
���   �$��16(�6I  ��6�   Z� 6I  �� 5   
   -   5        $		 reg��5      $��Regisztráció��6   $
��Left=�65   $��
157,90,0,0q�6P   $	��Top=�6d   $	��136��6|   $��34��6�   $��2��6�   $��1��6�   $

 Hand��6�   
���   �$��16(�6K   �� IsCancel . ��6�   Z� ��6  Z� 6Y  G� 5   
   -   5         G�Name$ passwordBox1��5      $
��Left=�6,   $��
118,10,0,0q�6G   $	��Top=�6[   $��2��6s   $	��216��6�   $��25��6�   $��1��6�   �� 5   
   -   5        $��Button��5      $
��Left=�6"   $��	50,68,0,0q�6=   $��1��6P   $	��Top=�6]   $��75��6u   6�   5      5      