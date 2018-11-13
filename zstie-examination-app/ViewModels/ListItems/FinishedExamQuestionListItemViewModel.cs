using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ZSTIE.Models.Response;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels.ListItems
{
    class FinishedExamQuestionListItemViewModel : ViewModelBase
    {
        int index;
        string question;
        string pictureUrl;
        ObservableCollection<string> answers;
        BitmapImage picture;
        int answerIndex;
        int correctAnswerIndex;

        INotifyQuestionSelected notifyQuestionSelected;

        public int Index
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged("Index");
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

        public ICommand QuestionSelect
        {
            get
            {
                return new RelayCommand(QuestionSelectExecute, CanQuestionSelectExecute);
            }
        }

        public BitmapImage Picture
        {
            get => picture;
            set
            {
                picture = value;
                OnPropertyChanged("Picture");
            }
        }

        public string PictureUrl { get => pictureUrl; set => pictureUrl = value; }
        internal INotifyQuestionSelected NotifyQuestionSelected { get => notifyQuestionSelected; set => notifyQuestionSelected = value; }
        public ObservableCollection<string> Answers
        {
            get => answers;
            set
            {
                answers = value;
                OnPropertyChanged("Answers");
            }
        }

        public int AnswerIndex
        {
            get => answerIndex;
            set
            {
                answerIndex = value;
                OnPropertyChanged("AnswerIndex");
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

        public FinishedExamQuestionListItemViewModel(int index, FinishedExamQuestionModel questionModel, INotifyQuestionSelected notifyQuestionSelected)
        {
            Index = index;
            Question = questionModel.Content;
            CorrectAnswerIndex = questionModel.CorrectAnswerIndex;
            AnswerIndex = questionModel.SelectedAnswer;

            Answers = new ObservableCollection<string>();
            foreach (var answer in questionModel.Answers)
            {
                Answers.Add(answer);
            }

            PictureUrl = questionModel.ImageUrl;
            NotifyQuestionSelected = notifyQuestionSelected;

            Picture = new BitmapImage();

            if (PictureUrl != null && PictureUrl.Length > 0)
            {
                Picture.BeginInit();
                Picture.UriSource = new Uri(PictureUrl);
                Picture.EndInit();
            }
        }

        void QuestionSelectExecute()
        {
            notifyQuestionSelected.QuestionSelected(index);
        }

        bool CanQuestionSelectExecute()
        {
            return true;
        }
    }
}
