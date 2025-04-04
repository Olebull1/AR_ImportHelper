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
using System.Windows.Shapes;

namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for CPMScannerInput.xaml
    /// </summary>
    public partial class CPMScannerInput : Window
    {
        public Locations Result { get; private set; }
        public bool IsConfirmed { get; private set; }
        public CPMScannerInput()
        {
            Result = new Locations();
            IsConfirmed = false;
            InitializeComponent();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool filled = true;
            if (ScannerDirectoryTextBox.Text == string.Empty)
            {
                //Icon1 toggle
                ScannerDirAsterisk.Visibility = Visibility.Visible;
                filled = false;
            }
            if (RoomNameTextBox.Text == string.Empty)
            {
                //Icon1 toggle
                RoomNameAsterisk.Visibility = Visibility.Visible;
                filled = false;
            }
            if (!filled)
            {
                return;
            }
            // Capture the values entered by the user
            Result.CrystalScannerImportLocation = ScannerDirectoryTextBox.Text;
            Result.RoomName = RoomNameTextBox.Text;
            IsConfirmed = true;
            // Close the window
            this.Close();
        }

        // When Cancel is clicked, set IsConfirmed to false and close the window
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }

        private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure open folder dialog box
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            // Show open folder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if (result == true)
            {
                // Get the selected folder
                ScannerDirectoryTextBox.Text = dialog.FolderName;
            }
        }
    }
}
