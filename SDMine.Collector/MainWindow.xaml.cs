using SDMine.Collector.Services.Collectors;
using SDMine.Collector.ViewModels;
using System.Windows;

namespace SDMine.Collector
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel();
            //PostsCollector.Collect();
        }
    }
}
