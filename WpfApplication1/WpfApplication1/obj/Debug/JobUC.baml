   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5         WpfApplication1.JobUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9System&clr-namespace:System;assembly=mscorlib     5      /Localclr-namespace:WpfApplication1     5        � 	Resources  5
         dataFromEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName��%�   &	        S� 5   
   $ 	GetValues��5      "  5       5      M� 5      $ Local:JobPriority��6   5      5      .��5      A� -   5         A�Name$ JobDesc��5       A� Rows$ 8��5       A� Columns$ 2��5      .+�5   
   �� .��6   Job ID6   �� 5   
   ��6   ��  �� Path$ JobId�60   �� 5   
   .��6   	Job Title6   �� 5   
   -   5        	 ��Name$	 JobDescJobTitle��5      
 �� TextWrapping$

 Wrap=�5      ��6&   �� $ JobTitle�.��6E   5      �� 5   
   .��6   Description6   �� 5    
   -   5        $	 JobDescJobDescription��5       $

 Wrap=�5!      ��6&   �� $ JobDescription��� 5#   
   .��6   
Employee6   �� 5$   
   -   5         ��Name$ JobDescJobEmployee��5$       �� Text 5%      �� $ AssignedEmployee��� 5*   
   .��6   Date Submitted6    �� 5+   
   ��6   �� $
 Time� �� Mode$ TwoWay=��� 51   
   .��6   
Supervisor6   �� 52   
   -   5         ��Name$ JobDescSupervisor��52      ��53      ��  �� Source$ JobTest��$ SupereeName�$ TwoWay=��� 58   
   .��6   
Priority6   �� 59   
   -   5        $ JobDescPriority��59       �� SelectedIndex$ 0��5;      ��5:      �� # [  5;      �� 5B   
   -   5         ��Name$ AddJob��5B      .��66   	Add Job6?   �� 5C   
   -   5        $ AddEmployee��5C      .��6@   Add Employee6N   5D      5E      