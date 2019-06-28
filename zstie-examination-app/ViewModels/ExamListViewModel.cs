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
    class ExamListViewModel : ViewModelBase, INotifyQualificationImageLoaded, INotifyExamSelected
    {
        ExamManager examManager = new ExamManager();
        ObservableCollection<ExamListItemViewModel> exams = new ObservableCollection<ExamListItemViewModel>();
        int loadedImage = 0;

        public ICommand Loaded
        {
            get
            {
                return new RelayCommand(LoadedExecute, CanLoadedExecute);
            }
        }

        public ObservableCollection<ExamListItemViewModel> Exams
        {
            get => exams;
            set => exams = value;
        }

        bool CheckIfImageImageAlreadyLoaded(QualificationListViewModel model)
        {
            return !model.Picture.IsDownloading;
        }

        void OnGetUserExamResponse(Response<List<ExamListItemModel>> response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    int i = 0;
                    foreach (var exam in response.Data)
                    {
                        Exams.Add(new ExamListItemViewModel(exam, this, this));
                        if (CheckIfImageImageAlreadyLoaded(Exams[i].Qualification))
                        {
                            ImageLoaded();
                        }

                        i++;
                    }
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    NotifyMessageViewVisibility.ShowMessageView("Błąd!", "Niespodziewany błąd serwera!");
                    break;
            }
        }

        void LoadedExecute()
        {
            exams.Clear();
            NotifyProgressBarVisibility.ShowProgressBar();
            try
            {
                Response<List<ExamListItemModel>> response = examManager.GetUserExams();
                OnGetUserExamResponse(response);
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        bool CanLoadedExecute()
        {
            return true;
        }

        public void ImageLoaded()
        {
            loadedImage++;

            if (loadedImage >= exams.Count)
            {
                NotifyProgressBarVisibility.HideProgressBar();
            }
        }

        public void ExamSelected(string id)
        {
            NotifyChangeView.ChangeView(new FinishedExamViewModel(id));
        }
    }
}
