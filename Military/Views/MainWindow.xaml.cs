using Military.Database;
using Military.ViewModels;
using System.Windows;

namespace Military
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MilitaryContainer mc = new MilitaryContainer();
        public MainWindow()
        {
            //mc.Employees.Add(new Soldier
            //{ JMBG = "1302999790038", Name = "Nikola", Surname = "Zivanovic", Rank = new Rank { Name = "Corporal" }, Camp = new Camp() });
            //mc.Employees.Add(new Medic
            //{ JMBG = "1302999790036", Name = "Cvijetin", Surname = "Mladjenovic", LicenseNo = "34@as21s", Camp = new Camp() });
            //mc.Employees.Add(new SupportPerson
            //{ JMBG = "1302999790031", Name = "Bogdan", Surname = "Kondic" });
            //mc.SaveChanges();
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new MainWindowViewModel(); };
        }
    }
}
