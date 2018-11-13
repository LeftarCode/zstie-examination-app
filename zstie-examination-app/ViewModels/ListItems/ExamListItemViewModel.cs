using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZSTIE.Models.Response;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels.ListItems
{
    class ExamListItemViewModel : ViewModelBase
    {
        ExamUltraSimpleModel exam;
        QualificationListViewModel qualification;
        int score;
        int maxScore;

        INotifyExamSelected notifyExamSelected;

        public ExamListItemViewModel(ExamListItemModel examListItemModel, 
            INotifyQualificationImageLoaded notifyQualificationImageLoaded,
            INotifyExamSelected notifyExamSelected)
        {
            this.notifyExamSelected = notifyExamSelected;
            this.Exam = examListItemModel.Exam;
            this.Qualification = new QualificationListViewModel(examListItemModel.Qualification, notifyQualificationImageLoaded, null);
        }

        public ICommand Click
        {
            get
            {
                return new RelayCommand(ClickExecute, CanClickExecute);
            }
        }

        void ClickExecute()
        {
            notifyExamSelected.ExamSelected(exam.Id);
        }

        bool CanClickExecute()
        {
            return true;
        }

        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        public int MaxScore
        {
            get => maxScore;
            set
            {
                maxScore = value;
                OnPropertyChanged("MaxScore");
            }
        }

        public QualificationListViewModel Qualification
        {
            get => qualification;
            set
            {
                qualification = value;
                OnPropertyChanged("Qualification");
            }
        }

        public ExamUltraSimpleModel Exam
        {
            get => exam;
            set
            {
                exam = value;
                OnPropertyChanged("Exam");
            }
        }
    }
}
