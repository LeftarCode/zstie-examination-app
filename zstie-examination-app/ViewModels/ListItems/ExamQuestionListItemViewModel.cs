using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ZSTIE.Models.Response;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels.ListItems
{
    class ExamQuestionListItemViewModel : ViewModelBase
    {
        int index;
        string id;
        string question;
        string pictureUrl;
        ObservableCollection<string> answers;
        BitmapImage picture;
        int answerIndex = -1;

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

        public string Id { get => id; set => id = value; }

        public ExamQuestionListItemViewModel(int index, QuestionModel questionModel, INotifyQuestionSelected notifyQuestionSelected)
        {
            Index = index;
            Question = questionModel.Question;
            Id = questionModel.Id;

            Answers = new ObservableCollection<string>();
            foreach(var answer in questionModel.Answers)
            {
                Answers.Add(answer);
            }

            PictureUrl = questionModel.ImageUrl;
            NotifyQuestionSelected = notifyQuestionSelected;

            Picture = new BitmapImage();

            if( PictureUrl != null )
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
