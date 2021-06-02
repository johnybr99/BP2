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
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new MainWindowViewModel(); };
        }
    }
}
