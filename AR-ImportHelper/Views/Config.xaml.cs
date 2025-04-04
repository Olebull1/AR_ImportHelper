using AR_ImportHelper.Constants;
using AR_ImportHelper.Models;
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


namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Page
    {
        private MainWindow _mainWindow;
        public Config(MainWindow dep)
        {
            InitializeComponent();
            ConfigViewModel config = ConfigViewModel.Instance;
            _mainWindow = dep;

            // Set the data context of the window to the Config instance
            this.DataContext = config;
            Console.WriteLine("Filler");
        }
        private void OpenMachineInputDialog()
        {
            var dialog = new MachineInputDialog();

            // Show the dialog and check if the user clicked OK
            dialog.ShowDialog();

            if (dialog.IsConfirmed) // If OK is clicked
            {
                // The Result property will contain the input data
                var machine = dialog.Result;

                // Do something with the machine data
                Console.WriteLine($"Machine Name: {machine.MachineName}");
                Console.WriteLine($"ID: {machine.Id}");
                Console.WriteLine($"Location: {machine.Location}");
                Console.WriteLine($"Export Location: {machine.ExportLocation}");
                ConfigViewModel config = ConfigViewModel.Instance;
                config.Machines.Add( machine );
            }
            else
            {
                // If Cancel was clicked, handle the cancellation
                Console.WriteLine("User cancelled the dialog.");
            }
        }
        private void OpenScannerInputDialog()
        {
            var dialog = new CPMScannerInput();

            // Show the dialog and check if the user clicked OK
            dialog.ShowDialog();

            if (dialog.IsConfirmed) // If OK is clicked
            {
                // The Result property will contain the input data
                var location = dialog.Result;

                // Do something with the machine data
                Console.WriteLine($"Machine Name: {location.RoomName}");
                Console.WriteLine($"ID: {location.CrystalScannerImportLocation}");
                ConfigViewModel config = ConfigViewModel.Instance;
                config.ExamRooms.Add(location);
            }
            else
            {
                // If Cancel was clicked, handle the cancellation
                Console.WriteLine("User cancelled the dialog.");
            }
        }

        // Click event for the hamburger button
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ConfigViewModel config = ConfigViewModel.Instance;
            config.saveConfigToFile();
            SaveSuccess save = new SaveSuccess();
            save.ShowDialog();
        }
        private void NetworkDirLbox_EditValue(object sender, RoutedEventArgs e)
        {
        }
        private void NetworkDirLbox_EditPath(object sender, RoutedEventArgs e)
        {
        }
        private void AddMachine_Click(object sender, RoutedEventArgs e)
        {
            OpenMachineInputDialog();
        }
        private void ImportDir_EditPath(object sender, RoutedEventArgs e)
        {
        }
        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            OpenScannerInputDialog();
        }
        private void RemoveRoom_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CPMScannerDirLbox.SelectedItem as Locations;
            ConfigViewModel config = ConfigViewModel.Instance;
            //TODO MAKE SURE THERE IS SOMETHING TO REMOVE FIRST
            config.ExamRooms.Remove(selectedItem);
        }
        private void RemoveMachine_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = MachineImportDirLbox.SelectedItem as Machines;
            ConfigViewModel config = ConfigViewModel.Instance;
            config.Machines.Remove(selectedItem);
        }
        //private void ImportDir_EditPath(object sender, RoutedEventArgs e)
        //{
        //    ConfigViewModel config = ConfigViewModel.Instance;
        //    var selected = ImportDirLbox.SelectedItem;
        //    if (!string.IsNullOrEmpty(selected.ToString()))
        //    {
        //        config.ImportDirs.Remove(selected.ToString());
        //    }
        //    // Configure open folder dialog box
        //    Microsoft.Win32.OpenFolderDialog dialog = new();

        //    dialog.Multiselect = false;
        //    dialog.Title = "Select a folder";

        //    // Show open folder dialog box
        //    bool? result = dialog.ShowDialog();

        //    // Process open folder dialog box results
        //    if (result == true)
        //    {
        //        // Get the selected folder
        //        string fullPathToFolder = dialog.FolderName;
        //        string folderNameOnly = dialog.SafeFolderName;
        //        config.ImportDirs.Add(fullPathToFolder);
        //    }
        //}

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    ConfigViewModel config = ConfigViewModel.Instance;
        //    // Configure open folder dialog box
        //    Microsoft.Win32.OpenFolderDialog dialog = new();

        //    dialog.Multiselect = true;
        //    dialog.Title = "Select a folder";

        //    // Show open folder dialog box
        //    bool? result = dialog.ShowDialog();

        //    // Process open folder dialog box results
        //    if (result == true)
        //    {
        //        // Get the selected folder
        //        string[] fullPathSToFolder = dialog.FolderNames;
        //        string folderNameOnly = dialog.SafeFolderName;
        //        foreach (string s in fullPathSToFolder)
        //        {
        //            config.ImportDirs.Add(s);
        //        }
        //    }
        //}
        //private void NetworkDirLbox_EditValue(object sender, MouseButtonEventArgs e)
        //{
        //    ConfigViewModel config = ConfigViewModel.Instance;
        //    // Configure open folder dialog box
        //    Microsoft.Win32.OpenFolderDialog dialog = new();

        //    dialog.Multiselect = false;
        //    dialog.Title = "Select a folder";

        //    // Show open folder dialog box
        //    bool? result = dialog.ShowDialog();

        //    // Process open folder dialog box results
        //    if (result == true)
        //    {
        //        // Get the selected folder
        //        string fullPathToFolder = dialog.FolderName;
        //        config.NetworkAutorefractionDir.Add(fullPathToFolder);
        //        Console.WriteLine("filler");
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ConfigViewModel config = ConfigViewModel.Instance;
        //    config.ImportDirs.Remove(ImportDirLbox.SelectedItem.ToString());
        //}
    }
}
