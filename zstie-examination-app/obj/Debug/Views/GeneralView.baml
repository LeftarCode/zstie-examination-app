   M S B A M L   `   `   `  ����G  CZSTiE, Version=0.0.7118.20475, Culture=neutral, PublicKeyToken=null)clr-namespace:ZSTIE.ViewsZSTIE.Views  5      3clr-namespace:ZSTIE.ViewModelsZSTIE.ViewModels  5          ZSTIE.Views.GeneralView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +viewsclr-namespace:ZSTIE.Views     5      5
viewmodelsclr-namespace:ZSTIE.ViewModels     5      ���	#FF252526  � 	Resources  5
       �� DataType%  ZSTIE.ViewModels.LoginViewModel   ZSTIE.Views.LoginView(  "ZSTIE.ViewModels.RegisterViewModel   ZSTIE.Views.RegisterView$  ZSTIE.ViewModels.MenuViewModel   ZSTIE.Views.MenuView'  !ZSTIE.ViewModels.NewExamViewModel   ZSTIE.Views.NewExamView$	  ZSTIE.ViewModels.ExamViewModel
   ZSTIE.Views.ExamView)  #ZSTIE.ViewModels.ExamScoreViewModel   ZSTIE.Views.ExamScoreView,  &ZSTIE.ViewModels.FinishedExamViewModel"   ZSTIE.Views.FinishedExamView(  "ZSTIE.ViewModels.ExamListViewModel   ZSTIE.Views.ExamListView*  $ZSTIE.ViewModels.CreateExamViewModel    ZSTIE.Views.CreateExamView0  *ZSTIE.ViewModels.VerificationCodeViewModel&    ZSTIE.Views.VerificationCodeView.  (ZSTIE.ViewModels.CreateQuestionViewModel$   ZSTIE.Views.CreateQuestionView��%9  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)(�� ,    5      *, +)(�� ^    5       *, +)(�� �    5#      *, +)(�� �    5&      *, +)(�� �    5)      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!        5"      �� 5#   
   "  6   .R�5$        5%      �� 5&   
   "  6   .R�5'        5(      �� 5)   
   "  6   .R�5*        5+      5,      .��5-      �  � RowDefinitions 5.   
   �� 5/      $��40 �6   �� 50      $��* �6   .+�52   
   � $��0��6   .+�53      �� $%��/Resources/Images/user_icon.png��6   $��20��6=   $��20��6H    �� BitmapScalingMode$ HighQuality=�6T   $��	140,5,0,0q�6�   $
��Left=�6�    J� Effect 54      3  -System.Windows.Media.Effects.DropShadowEffect  55         	Direction$	 360Q�6'      ShadowDepth$ 0Q�67      
BlurRadius$ 10Q�6G   57      �� 58         BlueNeonButtonStyle#��[  6   $��Wstecz��6B   $	��100��6p   $
��Left=�6|   $��Center=�6�   $��Center=�6�   $��30��6�   $��20,0,0,0q�6�   ��6S   �� *
Backward+ 59        5:      $ 0Q�6'   $ 0Q�65      Color$ 	#FF6888BA��6E   5<      �� 5=      $��165,0,0,0.4q�61   $
��Left=�6F   $��Center=�6a   $��15(�6�   ���	#FF6888BA��6   �� *
UserName+ 5>        5?      $ 0Q�6'   $	 360Q�67   $ 10Q�6G   $ 	#FF6888BA��6W   5A      �� 5B      #��[  6   $��Wyloguj��6B   $	��100��6t   $��Right=�6�   $��Center=�6�   $��Center=�6�   $��30��6�   $��0,0,10,0q�6�   ��6T   �� *GoLoginView+ 5C        5D      $ 0Q�6'   $ 0Q�65   $ 	#FF6888BA��6E   5F      5G      �� 5H   
   -   5        	 ��Name$	 CurrentContentControl��5H   &   $��1��6   ��6E   �� *CurrentViewModel+5I      5J      