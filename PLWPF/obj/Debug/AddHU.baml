   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.AddHU   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	     � Title$&   הוספת יחידת אירוח��5	   	   $	��450��6#   $	��850��60    � 	Resources 5
         hostingUnitViewSource  hostViewSource  bankBranchViewSource �� 
TargetType �� Property �� Value��%�   &	        &	      &	 &     '�� 9     �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ Right=�5      5      5      ��5      �� 5   
    �� ImageSource$ image/background.jpg��6   .��5      � .+�5   
   �� $��0,10,9.2,27q�6   $��Right=�6'   $��Stretch=�6C   ._�5      � $��Center=�6   $��Center=�60   $	��363��6K   $��0,10,0,10.2q�6X   .+�5      �� $'��!מלא את פרטי היחידה��6   $��Stretch=�65   $	��Top=�6T   $��131,0,9.6,0q�6l   $��31��6�   � 5      -   5         �Name$ grid1��5      $��Center=�6&   $��13,47,-0.4,9.8q�6C   $��Stretch=�6[    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+    � RowDefinitions 5       �� 5!      $
��Auto �6(   �� 5"      $
��Auto �6(   �� 5#      $
��Auto �6(   �� 5$      $
��Auto �6(   �� 5%      $
��Auto �6(   �� 5&      $	��38* �6(   �� 5'      $
��101* �6(   .+�5)      �� $#��אטרקציות לילדים��6   $��1��66   $
��Left=�6F   $��	3,4,0,2.8q�6a   $��1��6t   $��Center=�6�   $��26��6�   $	��123��6�   �� 5*      -   5        	 ��Name$"	 childrensAttractionsCheckBox��5*      $�� ��6E   $��0��6P   $
��Left=�6`   $��0,0,0,10q�6�   $��1��6�   $��Bottom=�6�   $��15��6�   $��18��6�   
 d� 	IsChecked
 6{   �� *ChildrensAttractions+ �� Mode$ TwoWay=�6�   �� 5+      $��שם המקום��6   $��1��6/   $
��Left=�6?   $��3,4.2,0,1.8q�6Z   $��0��6o   $��Center=�6|   $��26��6�   $	��114��6�   �� 5,      -   5         ��Name$ hostingUnitNameTextBox��5,      $��0��6>   $
��Left=�6N   $��23��6i   $��2.6,6.2,-0.2,2.8q�6u   $��0��6�   $��Center=�6�   $	��120��6�   ��6�   �� *HostingUnitName+$ TwoWay=�6�   �� 5-      $��אזור��6   $��1��6+   $
��Left=�6;   $��	2.8,5,0,1q�6V   $��3��6i   $��Center=�6v   $��26��6�   $	��123��6�   �� 5.      -   5         ��Name$ locationComboBox��5.      $��0��69   $
��Left=�6J   $��22��6e   $��2.6,7.2,-0.2,2.8q�6r   $��3��6�   $��Center=�6�   $	��120��6�    �� SelectedItem 6�   �� *
location+$ TwoWay=��� 5/      $��
בריכה��6   $��1��6,   $
��Left=�6<   $��	2.8,6,0,0q�6W   $��2��6j   $��Center=�6w   $��26��6�   $	��117��6�   �� 50      -   5        $	 poolCheckBox��50      $�� ��65   $��0��6@   $
��Left=�6P   $��0,6,0,10q�6�   $��2��6�   $��Center=�6�   $��16��6�   $��21��6�   
 6k   �� *Pool+$ TwoWay=�6�   �� 51      $��סוג האירוח��6   $��1��61   $
��Left=�6A   $��2.8,2,0,4.8q�6\   $��4��6q   $��Center=�6~   $��26��6�   $	��123��6�   �� 52      -   5        $ typeComboBox��52      $��0��65   $
��Left=�6E   $��22��6`   $��2.6,9.2,-0.2,1.6q�6m   $��4��6�   $��Center=�6�   $	��120��6�    6�   �� *type+$ TwoWay=�53      54      55      �� 56   
   $��291,10,300.2,10q�6   $��Center=�6*   $��Stretch=�6G   ._�57      � $��Center=�6   $��Center=�60   .+�58      �� $$��מלא פרטים אישיים��6   $��116,0,10,364q�63   $��Stretch=�6I   � 59      -   5        $ grid2��59      $��Center=�6&   $��
10,31,9,25q�6C   $��Stretch=�6W   $	��232��6s    5:      �� 5;      $
��Auto �6+   �� 5<      $
��Auto �6+    5>      �� 5?      $
��Auto �6(   �� 5@      $
��Auto �6(   �� 5A      $
��Auto �6(   �� 5B      $
��Auto �6(   �� 5C      $
��Auto �6(   �� 5D      $
��Auto �6(   �� 5E      $
��Auto �6(   �� 5F      $
��Auto �6(   .+�5H      �� $ ��מספר חשבון בנק��6   $��1��65   $
��Left=�6E   $��3q�6`   $��4��6k   $��Center=�6x   �� 5I      -   5        $ bankAccountNumberTextBox��5I      $��0��6@   $
��Left=�6P   $��25��6k   $��10,6,0,4q�6w   $��4��6�   $��Center=�6�   $��99��6�   ��6�   �� *BankAccountNumber+$ TwoWay=�6�   �� 5J      $&�� הרשאה לחיוב חשבון��6   $
��Left=�68   $��98,8,0,2q�6S   $��5��6e   $��Center=�6r   $	��119��6�   $��2��6�   �� 5K      -	   5        $!	 collectionClearanceCheckBox��5K      $�� ��6D   $��0��6O   $
��Left=�6_   $��
10,10,0,10q�6�   $��5��6�   $��Center=�6�   
 6z   �� *CollectionClearance+$ TwoWay=�6�   �� 5L      $��שם משפחה��6   $��1��6/   $
��Left=�6?   $��3.2,3.6,0,4q�6Z   $��1��6o   $��Center=�6|   $��97��6�   �� 5M      -
   5        $ familyNameTextBox��5M      $��0��69   $
��Left=�6I   $��24��6d   $��10,6,0,5q�6p   $��1��6�   $��Center=�6�   $��99��6�   ��6�   �� *
FamilyName+$ TwoWay=�6�   �� 5N      $��מספר פלאפון��6   $��1��62   $
��Left=�6B   $��3.2,4.2,0,4.4q�6]   $��2��6t   $��Center=�6�   $��97��6�   �� 5O      -   5        $ fhoneNumberTextBox��5O      $��0��6:   $
��Left=�6J   $��25��6e   $��10,6,0,5q�6q   $��2��6�   $��Center=�6�   $��99��6�   ��6�   �� *FhoneNumber+$ TwoWay=�6�   �� 5P      $��כתובת מיל��6   $��1��60   $
��Left=�6@   $��3.2,4,0,3.6q�6[   $��3��6p   $��Center=�6}   $��92��6�   �� 5Q      -   5        $ mailAddressTextBox��5Q      $��0��6:   $
��Left=�6J   $��25��6e   $��10,6,0,4q�6q   $��3��6�   $��Center=�6�   $��99��6�   ��6�   �� *MailAddress+$ TwoWay=�6�   �� 5R      $��שם פרטי��6   $��1��6.   $
��Left=�6>   $��3.2,4,0,3.6q�6Y   $��0��6n   $��Center=�6{   $��97��6�   �� 5S      -   5        $ privateNameTextBox��5S      $��0��6:   $
��Left=�6J   $��25��6e   $��10,6,0,4q�6q   $��0��6�   $��Center=�6�   $��99��6�   ��6�   �� *PrivateName+$ TwoWay=�6�   5T      5U      5V      �� 5W   
   $��
24,10,0,27q�6   $
��Left=�6%   $��Stretch=�6@   $	��262��6\   ._�5X      � $��	0,0,0,0.2q�6   $��Center=�6&   $��Center=�6C   .+�5Y      �� $&��  בחר פרטי סניף בנק��6   $��123,0,-0.4,341.2q�65   $��Stretch=�6O   $��Right=�6m   �� 5Z      -   5        $��BankName_comboBox��5Z      $��	63,81,0,0q�64   $	��Top=�6G   $	��120��6_   6k   �� 5[      -   5        $��BranchNumber_comboBox��5[      $��
63,194,0,0q�68   $	��Top=�6L   $	��120��6d   {�.  6p   �� 5\      $��בחר בנק��6   $��98,31,24.8,310.2q�6+   $��Stretch=�6E   $��Right=�6c   �� 5]      $��בחר סניף��6   $��98,133,24.8,208.4q�6+   $��Stretch=�6F   $��Right=�6d   5^      5_      �� 5`   
   -   5        $��הוסף��5`      $
��Left=�6    $��	24,0,0,10q�6=   $��Bottom=�6P   $��75��6k   ���	#FFEEEBE06�   5a      5b      