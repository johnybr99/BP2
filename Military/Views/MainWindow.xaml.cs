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
            mc.Ranks.Add(new Rank() { Name = "Corporal" });
            mc.Ranks.Add(new Rank() { Name = "Lieutenant" });
            mc.Ranks.Add(new Rank() { Name = "General" });
            mc.Camps.Add(new Camp());
            mc.Camps.Add(new Camp());
            mc.Camps.Add(new Camp());
            mc.Camps.Add(new Camp());
            mc.SaveChanges();
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new MainWindowViewModel(); };
        }
    }
}
