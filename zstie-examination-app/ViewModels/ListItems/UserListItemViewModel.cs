using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSTIE.ViewModels.ListItems
{
    class UserListItemViewModel : ViewModelBase
    {
        String name;
        String id;
        bool isSelected = false;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string Id { get => id; set => id = value; }

        public UserListItemViewModel(string fullName, string id)
        {
            Name = fullName;
            Id = id;
        }

        public UserListItemViewModel()
        {
        }
    }
}
