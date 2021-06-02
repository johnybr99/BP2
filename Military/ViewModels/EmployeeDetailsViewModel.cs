using Military.Database;
using Military.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Military.ViewModels
{
    public class EmployeeDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Visibility soldierFieldsVisible;
        private Visibility medicFieldsVisible;
        private string jmbgText;
        private string name;
        private string surname;
        private List<Rank> soldierRanks;
        private Rank soldierRanksSelected;
        private bool editEnabled;
        public Action CloseAction { get; set; }

        MilitaryContainer mc = new MilitaryContainer();
        public EmployeeDetailsViewModel()
        {

        }

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
        public EmployeeDetailsViewModel(Employee employee)
        {
            JMBGText = employee.JMBG;
            Name = employee.Name;
            Surname = employee.Surname;
            SoldierFieldsVisible = Visibility.Hidden;
            MedicFieldsVisible = Visibility.Hidden;
        }

        public EmployeeDetailsViewModel(Employee employee, string type)
        {
            JMBGText = employee.JMBG;
            Name = employee.Name;
            Surname = employee.Surname;
            if(type == "Soldier")
            {
                SoldierRanks = populateRanks();
                SoldierFieldsVisible = Visibility.Visible;
                MedicFieldsVisible = Visibility.Hidden;
            } else
            {
                SoldierFieldsVisible = Visibility.Hidden;
                MedicFieldsVisible = Visibility.Visible;
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool EditEnabled
        {
            get { return editEnabled; }
            set
            {
                if (editEnabled != value)
                {
                    editEnabled = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string JMBGText
        {
            get { return jmbgText; }
            set
            {
                if (jmbgText != value)
                {
                    jmbgText = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public List<Rank> SoldierRanks
        {
            get { return soldierRanks; }
            set
            {
                if (soldierRanks != value)
                {
                    soldierRanks = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Rank SoldierRanksSelected
        {
            get { return soldierRanksSelected; }
            set
            {
                if (soldierRanksSelected != value)
                {
                    soldierRanksSelected = value;
                    NotifyPropertyChanged();
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

        public ICommand EnableEditFields { get { return new RelayCommand(enableEdit, canEnableEdit); } }

        private void enableEdit(object param)
        {
            EditEnabled = true;
        }

        private bool canEnableEdit(object param)
        {
            return true;
        }

        public ICommand EditEmployee { get { return new RelayCommand(completeEdit, canExecuteEdit); } }

        private void completeEdit(object param)
        {
            if (!string.IsNullOrEmpty(JMBGText) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname))
            {
                
                if (SoldierFieldsVisible == Visibility.Visible)
                {
                    var soldier = mc.Soldiers.FirstOrDefault(x => x.JMBG == JMBGText);
                    soldier.Name = Name;
                    soldier.Surname = Surname;
                    if (SoldierRanksSelected != null)
                        soldier.Rank = SoldierRanksSelected;
                }
                else if(MedicFieldsVisible == Visibility.Visible)
                {
                    var medic = mc.Medics.FirstOrDefault(x => x.JMBG == JMBGText);
                    medic.Name = Name;
                    medic.Surname = Surname;
                } else
                {
                    var employee = mc.Employees.FirstOrDefault(x => x.JMBG == JMBGText);
                    employee.Name = Name;
                    employee.Surname = Surname;
                }
                
                mc.SaveChanges();
                CloseAction();
            }
        }

        private bool canExecuteEdit(object param)
        {
            return true;
        }

        private List<Rank> populateRanks()
        {

            var ranks = mc.Ranks.ToList();

            return ranks;
        }
    }
}
