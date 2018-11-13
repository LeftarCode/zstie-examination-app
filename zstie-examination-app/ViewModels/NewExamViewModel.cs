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
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class NewExamViewModel : ViewModelBase, INotifyQualificationImageLoaded, INotifyQualificationSelected
    {
        ObservableCollection<QualificationListViewModel> examsList = new ObservableCollection<QualificationListViewModel>();
        NewExamManager newExamManager = new NewExamManager();
        int loadedImage = 0;

        public ObservableCollection<QualificationListViewModel> ExamsList
        {
            get => examsList;
            set
            {
                examsList = value;
                OnPropertyChanged("ExamsList");
            }
        }

        public ICommand Loaded
        {
            get
            {
                return new RelayCommand(LoadedExecute, CanLoadedExecute);
            }
        }

        bool CheckIfImageImageAlreadyLoaded(QualificationListViewModel model)
        {
            return !model.Picture.IsDownloading;
        }

        void OnGetNewExamResponse(Response<List<QualificationModel>> response)
        {
            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var qualifications = response.Data;

                    int i = 0;
                    foreach (var qualification in qualifications)
                    {
                        ExamsList.Add(new QualificationListViewModel(qualification, this, this));
                        if (CheckIfImageImageAlreadyLoaded(ExamsList[i]))
                        {
                            ImageLoaded();
                        }

                        i++;
                    }
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    NotifyMessageViewVisibility.ShowMessageView("Brak aktywnych egzaminów!", "Nie masz aktualnie żadnych aktywnych egzaminów!");
                    NotifyProgressBarVisibility.HideProgressBar();
                    break;
            }
        }

        void LoadedExecute()
        {
            NotifyProgressBarVisibility.ShowProgressBar();
            try
            {
                Response<List<QualificationModel>> response = newExamManager.GetActiveExam();
                OnGetNewExamResponse(response);
            }
            catch (Exception exception)
            {
                NotifyProgressBarVisibility.HideProgressBar();
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
                NotifyChangeView.ChangeView(new MenuViewModel());
            }
        }

        bool CanLoadedExecute()
        {
            return true;
        }

        public void ImageLoaded()
        {
            loadedImage++;

            if (loadedImage >= examsList.Count)
            {
                NotifyProgressBarVisibility.HideProgressBar();
            }
        }

        public void QualificationSelected(string code)
        {
            NotifyChangeView.ChangeView(new ExamViewModel(code));
        }

        public NewExamViewModel()
        {
            
        }
    }
}
