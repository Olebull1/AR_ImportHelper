using AR_ImportHelper.Constants;
using AR_ImportHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for ImportHelper.xaml
    /// </summary>
    public partial class ImportHelper : Page
    {
        private MainWindow _mainWindow;
        private Dictionary<int, MachineMonitor> _machineMonitors = new Dictionary<int, MachineMonitor>();
        public ImportHelper(MainWindow dep)
        {
            InitializeComponent();
            _mainWindow = dep;
            GenerateMonitorList();
            GenerateRadioList();
            // Set the data context of the window to the 
            //this.DataContext;
        }
        private void GenerateMonitorList()
        {
            ConfigViewModel config = ConfigViewModel.Instance;
            foreach (Machines item in config.Machines)
            {
                MachineMonitor machineMonitor = new MachineMonitor(item);
                _machineMonitors[item.Id] = machineMonitor;
            }
        }
        private void GenerateRadioList()
        {
            ConfigViewModel config = ConfigViewModel.Instance;
            foreach(Machines item in config.Machines)
            {
                RadioButton radioButton = new RadioButton
                {
                    Height = 50,
                    Foreground = Brushes.Black,
                    FontSize = 14,
                    Content = item.MachineName, // Set the text
                    Tag = item.Id // Store the machine ID for reference
                };

                radioButton.SetResourceReference(StyleProperty, "MenuButtonTheme");

                // Optionally handle Checked event
                radioButton.Checked += (s, e) =>
                {
                    int selectedMachineId = (int)((RadioButton)s).Tag;

                    // Set the existing MachineMonitor to the ContentControl
                    MonitorContainer.Content = _machineMonitors[selectedMachineId];
                };

                // Add to the container
                RadioStack.Children.Add(radioButton);
            }
        }

        //All below is helper functions for hamburger menu
        private void HamburgerButton_Hover(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the side menu
            if (SideMenu.Visibility == Visibility.Collapsed)
            {
                SideMenu.Visibility = Visibility.Visible;
            }
            else
            {
                SideMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void StackPanel_CollapseMenuUnhover(object sender, MouseEventArgs e)
        {
            // Toggle the visibility of the side menu
            if (SideMenu.Visibility == Visibility.Collapsed)
            {
                SideMenu.Visibility = Visibility.Visible;
            }
            else
            {
                SideMenu.Visibility = Visibility.Collapsed;
            }
        }
        private void Button_NavHome(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToPage(NavigationTarget.HomePage);
        }
        private void Button_NavConfig(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToPage(NavigationTarget.ConfigPage);
        }
        private void Button_NavImportHelper(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToPage(NavigationTarget.ImportHelperPage);
        }

        private void importList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
