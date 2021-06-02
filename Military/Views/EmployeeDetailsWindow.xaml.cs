using Military.Database;
using Military.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Military.Views
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsWindow.xaml
    /// </summary>
    public partial class EmployeeDetailsWindow : Window
    {
        public EmployeeDetailsWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new EmployeeDetailsViewModel(); };
        }

        public EmployeeDetailsWindow(Employee employee)
        {
            InitializeComponent();
            var vm = new EmployeeDetailsViewModel(employee);
            this.Loaded += (s, e) => { this.DataContext = vm; };
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        public EmployeeDetailsWindow(Employee employee, string type)
        {
            InitializeComponent();
            var vm = new EmployeeDetailsViewModel(employee, type);
            this.Loaded += (s, e) => { this.DataContext = vm; };
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
