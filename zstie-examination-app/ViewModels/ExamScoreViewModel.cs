using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZSTIE.Models.Response;
using ZSTIE.Utilities;

namespace ZSTIE.ViewModels
{
    class ExamScoreViewModel : ViewModelBase
    {
        string scoreLabel;
        ExamScore examScore;
        Visibility passImageVisibility = Visibility.Hidden;
        Visibility failImageVisibility = Visibility.Hidden;

        public ExamScoreViewModel(ExamScore examScore)
        {
            this.examScore = examScore;

            int score = examScore.Score;
            int maxScore = examScore.AnswersCorrectness.Count;
            float percentage = ((float)score / (float)maxScore) * 100;

            scoreLabel = "Wynik: " + examScore.Score + "/" + examScore.AnswersCorrectness.Count;
            if( percentage >= 50)
            {
                PassExam();
            }
            else
            {
                FailExam();
            }
        }

        private void PassExam()
        {
            PassImageVisibility = Visibility.Visible;
            FailImageVisibility = Visibility.Hidden;
        }

        private void FailExam()
        {
            PassImageVisibility = Visibility.Hidden;
            FailImageVisibility = Visibility.Visible;
        }

        public ICommand ShowExam
        {
            get
            {
                return new RelayCommand(ShowExamExecute, CanShowExamExecute);
            }
        }

        public string ScoreLabel
        {
            get => scoreLabel;
            set
            {
                scoreLabel = value;
                OnPropertyChanged("ExamScoreLabel");
            }
        }

        public Visibility PassImageVisibility
        {
            get => passImageVisibility;
            set
            {
                passImageVisibility = value;
                OnPropertyChanged("PassImageVisibility");
            }
        }

        public Visibility FailImageVisibility
        {
            get => failImageVisibility;
            set
            {
                failImageVisibility = value;
                OnPropertyChanged("FailImageVisibility");
            }
        }

        void ShowExamExecute()
        {
            NotifyChangeView.ChangeView(new FinishedExamViewModel(examScore.Id));
        }

        bool CanShowExamExecute()
        {
            return true;
        }
    }
}
