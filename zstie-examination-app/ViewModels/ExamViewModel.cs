using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZSTIE.Managers;
using ZSTIE.Models.DTO;
using ZSTIE.Models.Response;
using ZSTIE.Properties;
using ZSTIE.REST;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.ListItems;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class ExamViewModel : ViewModelBase, INotifyQuestionSelected
    {
        ObservableCollection<ExamQuestionListItemViewModel> questions = new ObservableCollection<ExamQuestionListItemViewModel>();
        ExamQuestionListItemViewModel selectedQuestion;
        ExamManager examManager = new ExamManager();

        string professionCode;

        public ICommand SubmitExam
        {
            get
            {
                return new RelayCommand(SubmitExamExecute, CanSubmitExamExecute);
            }
        }

        public ICommand Loaded
        {
            get
            {
                return new RelayCommand(LoadedExecute, CanLoadedExecute);
            }
        }

        public ObservableCollection<ExamQuestionListItemViewModel> Questions
        {
            get => questions;
            set
            {
                questions = value;
                OnPropertyChanged("Questions");
            }
        }

        public ExamQuestionListItemViewModel SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        private void OnGetExamResponse(Response<ExamModel> response)
        {
            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    ExamModel exam = response.Data;

                    int i = 0;
                    foreach (var question in exam.Questions)
                    {
                        ExamQuestionListItemViewModel questionListItemViewModel = new ExamQuestionListItemViewModel(i + 1, question, this);

                        Questions.Add(questionListItemViewModel);
                        i++;
                    }
                    break;
                case System.Net.HttpStatusCode.Conflict:
                    NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Możesz mieć tylko jeden aktywny egzamin w tym samym czasie!");
                    NotifyChangeView.ChangeView(new NewExamViewModel());
                    break;
            }
        }

        public ExamViewModel(string professionCode)
        {
            this.professionCode = professionCode;
        }

        private void OnSubmitExamResponse(Response<ExamScore> response)
        {
            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    NotifyChangeView.ChangeView(new ExamScoreViewModel(response.Data));
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Nie masz żadnego aktywnego egzaminu do, którego można wysłać odpowiedzi!");
                    NotifyChangeView.ChangeView(new NewExamViewModel());
                    break;
            }
        }

        void LoadedExecute()
        {
            try
            {
                Response<ExamModel> response = examManager.CreateExam(40, professionCode, Settings.Default.USER_ID);
                OnGetExamResponse(response);
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
                NotifyChangeView.ChangeView(new NewExamViewModel());
            }
        }

        bool CanLoadedExecute()
        {
            return true;
        }

        void SubmitExamExecute()
        {
            SubmitExamDTO submitExamDTO = new SubmitExamDTO
            {
                UserCode = "3C06"
            };
            foreach (var question in questions)
            {
                submitExamDTO.AnswersIndices.Add(question.AnswerIndex);
                submitExamDTO.QuestionsId.Add(question.Id);
            }

            try
            {
                Response<ExamScore> response = examManager.SubmitExam(submitExamDTO);
                OnSubmitExamResponse(response);
            }
            catch(Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        bool CanSubmitExamExecute()
        {
            return true;
        }

        public void QuestionSelected(int index)
        {
            SelectedQuestion = questions[index - 1];
        }
    }
}
