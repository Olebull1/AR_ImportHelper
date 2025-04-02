using AR_ImportHelper.Models;
using AR_ImportHelper.Views;
using AR_ImportHelper.Constants;

using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AR_ImportHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    public delegate void Notify();
    public partial class MainWindow : Window
    {
        //Store a reference to persistent page?
        Config config;
        HomePage homePage;
        ImportHelper importHelper;
        public MainWindow()
        {
            InitializeComponent();

            config = new Config(this);
            homePage = new HomePage(this);
            importHelper = new ImportHelper(this);

            //var viewModel = new MainViewModel();
            //this.DataContext = viewModel;

            // Initially set the frame to show the home page
            NavigateToPage(NavigationTarget.HomePage);
        }
        // Method to handle page navigation from ViewModel
        public void NavigateToPage(NavigationTarget target)
        {
            switch (target)
            {
                case NavigationTarget.HomePage:
                    MainFrame.Navigate(homePage);
                    break;
                case NavigationTarget.ConfigPage:
                    MainFrame.Navigate(config);
                    break;
                case NavigationTarget.ImportHelperPage:
                    MainFrame.Navigate(importHelper);
                    break;
                default:
                    MainFrame.Navigate(homePage);
                    break;
            }
        }
        public void NavigateToPage(NavigationTarget target, ConfigViewModel cfg)
        {
            switch (target)
            {
                case NavigationTarget.HomePage:
                    MainFrame.Navigate(homePage);
                    break;
                case NavigationTarget.ConfigPage:
                    MainFrame.Navigate(config);
                    break;
                case NavigationTarget.ImportHelperPage:
                    MainFrame.Navigate(importHelper);
                    break;
                default:
                    MainFrame.Navigate(homePage);
                    break;
            }
        }
    }
}