using Military.Database;
using Military.Models;
using Military.Utils;
using Military.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Military.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        MilitaryContainer mc = new MilitaryContainer();
        public MainWindowViewModel()
        {
            EmployeeTypes = new List<EmployeeTypeModel>();
            EmployeeTypes = populateEmployeeTypes(Enum.GetValues(typeof(EEmployeeType)).Length);
            EmployeeTypesSelected = EmployeeTypes[0];
            employeesSource = filterEmployees();
            MilitaryComboBoxEnabled = false;
            MilitaryPersonTypes = populateMilitaryPersonnelTypes(Enum.GetValues(typeof(MilitaryPersonType)).Length);
            MilitaryPersonTypesSelected = MilitaryPersonTypes[0];
            
        }

        private ObservableCollection<Employee> employeesSource;
        private string jmbg;
        private string name;
        private string surname;
        private Rank soldierRank;
        private List<EmployeeTypeModel> employeeTypes;
        private EmployeeTypeModel employeeTypesSelected;
        private List<MilitaryPersonTypeModel> militaryPersonTypes;
        private MilitaryPersonTypeModel militaryPersonTypesSelected;
        private bool militaryComboBoxEnabled;
        

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
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

        public Rank SoldierRank
        {
            get { return soldierRank; }
            set
            {
                if (soldierRank != value)
                {
                    soldierRank = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool MilitaryComboBoxEnabled
        {
            get { return militaryComboBoxEnabled; }
            set
            {
                if (militaryComboBoxEnabled != value)
                {
                    militaryComboBoxEnabled = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<EmployeeTypeModel> EmployeeTypes
        {
            get { return employeeTypes; }
            set
            {
                if (employeeTypes != value)
                {
                    employeeTypes = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public EmployeeTypeModel EmployeeTypesSelected
        {
            get { return employeeTypesSelected; }
            set
            {
                if (employeeTypesSelected != value)
                {
                    employeeTypesSelected = value;
                    EmployeesSource = filterEmployees();
                    NotifyPropertyChanged();
                }
            }
        }

        public List<MilitaryPersonTypeModel> MilitaryPersonTypes
        {
            get { return militaryPersonTypes; }
            set
            {
                if (militaryPersonTypes != value)
                {
                    militaryPersonTypes = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public MilitaryPersonTypeModel MilitaryPersonTypesSelected
        {
            get { return militaryPersonTypesSelected; }
            set
            {
                if (militaryPersonTypesSelected != value)
                {
                    militaryPersonTypesSelected = value;
                    EmployeesSource = filterEmployees();
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Employee> EmployeesSource
        {
            get { return employeesSource; }
            set
            {
                if (employeesSource != value)
                {
                    employeesSource = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region Commands

        public ICommand CreateEmployeeWindowCommand { get { return new RelayCommand(createEmployeeWindow, canCreateEmployeeWindow); } }

        private void createEmployeeWindow(object param)
        {
            CreateEmployeeWindow cew = new CreateEmployeeWindow(EmployeeTypesSelected, MilitaryPersonTypesSelected);
            cew.Show();
        }

        private bool canCreateEmployeeWindow(object param)
        {
            if (EmployeeTypesSelected.ID == 2)
            {
                return false;
            } else if(EmployeeTypesSelected.ID == 0 && MilitaryPersonTypesSelected.ID == 2)
            {
                return false;
            }

            return true;
            
        }

        private ObservableCollection<Employee> populateEmployeeList()
        {
            var employees = new ObservableCollection<Employee>();
            foreach (var item in mc.Employees)
            {
                employees.Add(item);
            }

            return employees;
        }

        private ObservableCollection<Employee> filterEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            List<Employee> filteredList = new List<Employee>();
            if(EmployeeTypesSelected.ID == 0)
            {
                MilitaryComboBoxEnabled = true;

                if (MilitaryPersonTypesSelected.TypeName != "All")
                {
                    var militaryPersonnel = mc.MilitaryPersons.Where(x => (int)x.Type == MilitaryPersonTypesSelected.ID).ToList();
                    foreach(var item in militaryPersonnel)
                    {
                        employees.Add(item);
                    }
                } else
                {
                    filteredList = mc.Employees.Where(x => (int)x.EmployeeType == employeeTypesSelected.ID).ToList();

                    foreach (var item in filteredList)
                    {
                        employees.Add(item);
                    }
                }
                
            }
            else
            {

                filteredList = mc.Employees.Where(x => (int)x.EmployeeType == employeeTypesSelected.ID).ToList();

                foreach (var item in filteredList)
                {
                    employees.Add(item);
                }

                if (!filteredList.Any())
                {
                    employees = populateEmployeeList();

                }
                MilitaryComboBoxEnabled = false;
            }

            return employees;

        }

        private List<MilitaryPersonTypeModel> populateMilitaryPersonnelTypes(int len)
        {
            var militantTypes = new List<MilitaryPersonTypeModel>();
            militantTypes.Add(new MilitaryPersonTypeModel
            { ID = len, TypeName = "All" });

            foreach (var item in Enum.GetValues(typeof(MilitaryPersonType)))
            {
                militantTypes.Add(new MilitaryPersonTypeModel { ID = (int)item, TypeName = item.ToString() });
            }

            return militantTypes;
        }

        private List<EmployeeTypeModel> populateEmployeeTypes(int len)
        {
            var employeeTypes = new List<EmployeeTypeModel>();
            employeeTypes.Add(new EmployeeTypeModel { ID = len, TypeName = "All" });

            foreach (var item in Enum.GetValues(typeof(EEmployeeType)))
            {
                employeeTypes.Add(new EmployeeTypeModel { ID = (int)item, TypeName = item.ToString() });
            }

            return employeeTypes;
        }
        public ICommand EmployeeDetailsWindowCommand { get { return new RelayCommand(employeeDetailsWindow, canEmployeeDetailsWindow); } }

        private void employeeDetailsWindow(object param)
        {
            EmployeeDetailsWindow edw = new EmployeeDetailsWindow();
            edw.Show();
        }

        private bool canEmployeeDetailsWindow(object param)
        {
            return true;
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
