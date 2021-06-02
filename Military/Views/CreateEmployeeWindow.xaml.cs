using Military.Models;
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
    /// Interaction logic for CreateEmployeeWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window
    {
        public CreateEmployeeWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new CreateEmployeeViewModel(); };
        }

        public CreateEmployeeWindow(EmployeeTypeModel type, MilitaryPersonTypeModel militaryType)
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new CreateEmployeeViewModel(type, militaryType); };
        }
    }
}
