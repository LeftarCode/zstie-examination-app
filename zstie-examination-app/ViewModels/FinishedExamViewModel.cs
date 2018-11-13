using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZSTIE.Managers;
using ZSTIE.Models.Response;
using ZSTIE.REST;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.ListItems;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class FinishedExamViewModel : ViewModelBase, INotifyQuestionSelected
    {
        ObservableCollection<FinishedExamQuestionListItemViewModel> questions = new ObservableCollection<FinishedExamQuestionListItemViewModel>();
        FinishedExamQuestionListItemViewModel selectedQuestion;
        ExamManager examManager = new ExamManager();

        public FinishedExamViewModel(string id)
        {
            try
            {
                Response<FinishedExamModel> response = examManager.GetExamById(id);

                FinishedExamModel data = response.Data;

                int index = 1;
                foreach(var question in data.Questions)
                {
                    Questions.Add(new FinishedExamQuestionListItemViewModel(index, question, this));
                    index++;
                }

                SelectedQuestion = Questions[0];
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        public ICommand FinishReview
        {
            get
            {
                return new RelayCommand(FinishReviewExecute, CanFinishReviewExecute);
            }
        }

        public ObservableCollection<FinishedExamQuestionListItemViewModel> Questions
        {
            get => questions;
            set
            {
                questions = value;
                OnPropertyChanged("Questions");
            }
        }

        public FinishedExamQuestionListItemViewModel SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        private void FinishReviewExecute()
        {
            NotifyChangeView.ChangeView(new ExamListViewModel());
        }

        private bool CanFinishReviewExecute()
        {
            return true;
        }

        public void QuestionSelected(int index)
        {
            SelectedQuestion = Questions[index - 1];
        }
    }
}
