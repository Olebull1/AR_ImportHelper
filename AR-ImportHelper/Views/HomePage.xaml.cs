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
using System.Windows.Navigation;
using System.Windows.Shapes;

using AR_ImportHelper.Constants;

namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private MainWindow _mainWindow;
        public HomePage(MainWindow dep)
        {
            InitializeComponent();
            _mainWindow = dep;
        }

        private void NavigateToConfig(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToPage(NavigationTarget.ConfigPage);
        }

        private void NavigateToImportHelper(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToPage(NavigationTarget.ImportHelperPage);
        }
    }
}
