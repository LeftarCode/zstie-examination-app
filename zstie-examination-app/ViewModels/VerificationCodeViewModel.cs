using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ZSTIE.Managers;
using ZSTIE.Models.Response;
using ZSTIE.REST;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.ListItems;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class VerificationCodeViewModel : ViewModelBase
    {
        UserManager userManager = new UserManager();
        string className = "";
        int count = 0;

        public VerificationCodeViewModel()
        {
            
        }

        public ICommand GenerateCodes
        {
            get
            {
                return new RelayCommand(GenerateCodesExecute, CanGenerateCodesExecute);
            }
        }

        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged("Count");
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


        private void GenerateCodesExecute()
        {
            try
            {
                List<string> classNames = new List<string>();

                for(int i = 0; i < Count; i++)
                {
                    classNames.Add(ClassName);
                }

                Response<List<VerificationCodeSimpleModel>> response = userManager.GetRandomVerificationCode(classNames);
                List<VerificationCodeSimpleModel> data = response.Data;

                string fileContent = "";
                foreach(var code in data)
                {
                    fileContent += code.Code;
                    fileContent += Environment.NewLine;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text file (*.txt)|*.txt"; ;
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, fileContent);
                }
            }
            catch (Exception exception)
            {
                NotifyMessageViewVisibility.ShowMessageView("Błąd!", exception.Message);
            }
        }

        private bool CanGenerateCodesExecute()
        {
            return true;
        }
    }
}
