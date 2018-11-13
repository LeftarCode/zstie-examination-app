using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class MenuViewModel : ViewModelBase
    {
        bool isAdmin;
        INotifyMessageViewVisibility notifyMessageViewVisibility;

        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        
        public ICommand SelectQualification
        {
            get
            {
                return new RelayCommand(SelectQualificationExecute, CanSelectQualificationExecute);
            }
        }

        public ICommand OnCreateExamClick
        {
            get
            {
                return new RelayCommand(SelectCreateExamExecute, CanSelectExamListExecute);
            }
        }

        public ICommand OnGenerateCodeClick
        {
            get
            {
                return new RelayCommand(SelectGenerateCodeExecute, CanSelectGenerateCodeExecute);
            }
        }

        public ICommand SelectExamList
        {
            get
            {
                return new RelayCommand(SelectExamListExecute, CanSelectExamListExecute);
            }
        }
        
        public ICommand OnCreateQuestionClick
        {
            get
            {
                return new RelayCommand(OnCreateQuestionClickExecute, CanOnCreateQuestionClickExecute);
            }
        }

        private void OnCreateQuestionClickExecute()
        {
            NotifyChangeView.ChangeView(new CreateQuestionViewModel());
        }

        private void SelectGenerateCodeExecute()
        {
            NotifyChangeView.ChangeView(new VerificationCodeViewModel());
        }

        private void SelectCreateExamExecute()
        {
            NotifyChangeView.ChangeView(new CreateExamViewModel());
        }

        private void SelectQualificationExecute()
        {
            NotifyChangeView.ChangeView(new NewExamViewModel());
        }

        private void SelectExamListExecute()
        {
            NotifyChangeView.ChangeView(new ExamListViewModel());
        }
        
        private bool CanOnCreateQuestionClickExecute()
        {
            return true;
        }

        private bool CanSelectExamListExecute()
        {
            return true;
        }

        private bool CanSelectGenerateCodeExecute()
        {
            return true;
        }

        private bool CanSelectQualificationExecute()
        {
            return true;
        }
    }
}
