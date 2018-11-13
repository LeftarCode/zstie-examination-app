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
    class CreateExamViewModel : ViewModelBase
    {
        ObservableCollection<UserListItemViewModel> usersList = new ObservableCollection<UserListItemViewModel>();
        ObservableCollection<string> classesList = new ObservableCollection<string>();
        ObservableCollection<string> qualifsList = new ObservableCollection<string>();
        String className;
        String qualifName;
        UserManager userManager = new UserManager();
        QualificationManager qualificationManager = new QualificationManager();
        List<int> selectedIndex = new List<int>();
        ExamManager examManager = new ExamManager();

        public CreateExamViewModel()
        {
            try
            {
                Response<List<QualificationModel>> response = qualificationManager.GetAllQualifications();

                List<QualificationModel> data = response.Data;

                foreach(var qualif in data)
                {
                    QualifsList.Add(qualif.Code);
                }

                Response<List<ClassSimpleModel>> responseClass = userManager.GetAllClasses();

                List<ClassSimpleModel> dataClass = responseClass.Data;

                foreach(var className in dataClass)
                {
                    ClassesList.Add(className.ClassName);
                }
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        public ObservableCollection<UserListItemViewModel> UsersList
        {
            get => usersList;
            set
            {
                usersList = value;
                OnPropertyChanged("UsersList");
            }
        }

        public ObservableCollection<string> ClassesList
        {
            get => classesList;
            set
            {
                classesList = value;
                OnPropertyChanged("ClassesList");
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

        public string ClassName
        {
            get => className;
            set
            {
                className = value;
                OnPropertyChanged("ClassName");
            }
        }

        public ICommand OnClassChanged
        {
            get
            {
                return new RelayCommand(OnClassChangedExecute, CanOnClassChangedExecute);
            }
        }

        public ICommand OnSubmitExam
        {
            get
            {
                return new RelayCommand(OnSubmitExamExecute, CanOnSubmitExamExecute);
            }
        }

        internal List<int> SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedUser");
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

        private void OnClassChangedExecute()
        {
            try
            {
                Response<List<UserSimpleModel>> response = userManager.GetAllClassUsers(ClassName);
                List<UserSimpleModel> data = response.Data;

                UsersList.Clear();
                foreach (var user in data)
                {
                    UsersList.Add(new UserListItemViewModel(user.FullName, user.Id));
                }
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        private bool CanOnClassChangedExecute()
        {
            return true;
        }

        private void OnSubmitExamExecute()
        {
            try
            {
                foreach(var user in usersList)
                {
                    if(user.IsSelected)
                    {
                        examManager.CreateExam(40, qualifName, user.Id);
                    }
                }
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        private bool CanOnSubmitExamExecute()
        {
            return true;
        }
    }
}
