using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZSTIE.Managers;
using ZSTIE.Models.DTO;
using ZSTIE.Models.Response;
using ZSTIE.REST;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.ListItems;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class CreateQuestionViewModel : ViewModelBase
    {
        string qualifName;
        string answerA;
        string answerB;
        string answerC;
        string answerD;
        string imageUrl;
        string question;
        int correctAnswerIndex;
        ObservableCollection<string> qualifsList = new ObservableCollection<string>();
        QualificationManager qualificationManager = new QualificationManager();
        ExamManager examManager = new ExamManager();

        public CreateQuestionViewModel()
        {
            try
            {
                Response<List<QualificationModel>> response = qualificationManager.GetAllQualifications();

                List<QualificationModel> data = response.Data;

                foreach (var qualif in data)
                {
                    QualifsList.Add(qualif.Code);
                }
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        public string QualifName
        {
            get => qualifName;
            set
            {
                qualifName = value;
                OnPropertyChanged("QualifName");
            }
        }

        public string AnswerA
        {
            get => answerA;
            set
            {
                answerA = value;
                OnPropertyChanged("AnswerA");
            }
        }

        public string AnswerB
        {
            get => answerB;
            set
            {
                answerB = value;
                OnPropertyChanged("AnswerB");
            }
        }

        public string AnswerC
        {
            get => answerC;
            set
            {
                answerC = value;
                OnPropertyChanged("AnswerC");
            }
        }

        public string AnswerD
        {
            get => answerD;
            set
            {
                answerD = value;
                OnPropertyChanged("AnswerD");
            }
        }

        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }

        public string Question
        {
            get => question;
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }

        public int CorrectAnswerIndex
        {
            get => correctAnswerIndex;
            set
            {
                correctAnswerIndex = value;
                OnPropertyChanged("CorrectAnswerIndex");
            }
        }

        public ObservableCollection<string> QualifsList
        {
            get => qualifsList;
            set
            {
                qualifsList = value;
                OnPropertyChanged("QualifsList");
            }
        }

        public ICommand OnCreateQuestion
        {
            get
            {
                return new RelayCommand(OnCreateQuestionExecute, CanOnCreateQuestionExecute);
            }
        }

        private bool CanOnCreateQuestionExecute()
        {
            return true;
        }

        private void OnCreateQuestionExecute()
        {
            try
            {
                CreateQuestionDTO createQuestionDTO = new CreateQuestionDTO
                {
                    CorrectAnswerIndex = CorrectAnswerIndex,
                    ImageUrl = ImageUrl,
                    ProfessionCode = QualifName,
                    Question = Question
                };
                createQuestionDTO.Answers.Add(AnswerA);
                createQuestionDTO.Answers.Add(AnswerB);
                createQuestionDTO.Answers.Add(AnswerC);
                createQuestionDTO.Answers.Add(AnswerD);

                IRestResponse response = examManager.CreateQuestion(createQuestionDTO);

                switch(response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Created:
                        NotifyMessageViewVisibility.ShowMessageView("Sukces!", "Udało się dodać pytanie!");
                        break;
                    default:
                        NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Niespodziewany błąd!");
                        break;
                }
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }
    }
}
