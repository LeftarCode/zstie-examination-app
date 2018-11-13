using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ZSTIE.Models.Response;
using ZSTIE.Utilities;
using ZSTIE.ViewModels.Notifiers;

namespace ZSTIE.ViewModels
{
    class QualificationListViewModel
    {
        string code;
        BitmapImage picture;
        INotifyQualificationImageLoaded notifyQualificationImageLoaded;
        INotifyQualificationSelected notifyQualificationSelected;

        public QualificationListViewModel(QualificationModel model,
            INotifyQualificationImageLoaded notifyQualificationImageLoaded,
            INotifyQualificationSelected notifyQualificationSelected)
        {
            this.code = model.Code;
            this.notifyQualificationImageLoaded = notifyQualificationImageLoaded;
            this.notifyQualificationSelected = notifyQualificationSelected;

            picture = new BitmapImage();
            picture.DownloadCompleted += (s, e) =>
            {
                notifyQualificationImageLoaded.ImageLoaded();
            };

            picture.BeginInit();
            picture.UriSource = new Uri(model.PictureUrl);
            picture.EndInit();
        }

        public BitmapImage Picture
        {
            get => picture;
            set => picture = value;
        }
        public string Code
        {
            get => code;
            set => code = value;
        }

        public ICommand Click
        {
            get
            {
                return new RelayCommand(ClickExecute, CanClickExecute);
            }
        }

        void ClickExecute()
        {
            notifyQualificationSelected.QualificationSelected(Code);
        }

        bool CanClickExecute()
        {
            return true;
        }
    }
}
