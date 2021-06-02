using Military.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Military.ViewModels
{
    public class CreateEmployeeViewModel : INotifyPropertyChanged
    {
        private MainWindowViewModel mwvm;
        private Visibility soldierFieldsVisible;
        private Visibility medicFieldsVisible;
        public CreateEmployeeViewModel()
        {
        }

        public CreateEmployeeViewModel(EmployeeTypeModel type, MilitaryPersonTypeModel militaryType)
        {
            SetFields(type, militaryType);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility SoldierFieldsVisible
        {
            get { return soldierFieldsVisible; }
            set
            {
                if (soldierFieldsVisible != value)
                {
                    soldierFieldsVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Visibility MedicFieldsVisible
        {
            get { return medicFieldsVisible; }
            set
            {
                if (medicFieldsVisible != value)
                {
                    medicFieldsVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void SetFields(EmployeeTypeModel type, MilitaryPersonTypeModel MilitaryType)
        {
            if(type.ID == 1)
            {
                SoldierFieldsVisible = Visibility.Hidden;
                MedicFieldsVisible = Visibility.Hidden;
            } else
            {
                if (MilitaryType.ID == 0)
                {
                    SoldierFieldsVisible = Visibility.Visible;
                    MedicFieldsVisible = Visibility.Hidden;
                }
                else
                {
                    SoldierFieldsVisible = Visibility.Hidden;
                    MedicFieldsVisible = Visibility.Visible;
                }
            }
            
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
