using AR_ImportHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using Windows.Storage.Pickers;
using Microsoft.Win32;

namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for MachineInputDialog.xaml
    /// </summary>
    public partial class MachineInputDialog : Window
    {
        public Machines Result { get; private set; }
        public bool IsConfirmed { get; private set; }
        public MachineInputDialog()
        {
            InitializeComponent();
            IsConfirmed = false;
            Result = new Machines();  // Initialize with an empty Machine object
        }

        // When OK is clicked, populate the Result property
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool filled = true;
            if (MachineNameTextBox.Text == string.Empty)
            {
                //Icon1 toggle
                MNameAsterisk.Visibility = Visibility.Visible;
                filled = false;
            }
            if (IDTextBox.Text == string.Empty)
            {
                //Icon1 toggle
                IDAsterisk.Visibility = Visibility.Visible;
                filled = false;
            }
            if (LocationTextBox.Text == string.Empty)
            {
                //Icon1 toggle
                LocationAsterisk.Visibility = Visibility.Visible;
                filled = false;
            }
            if(ExportDirectoryTextBox.Text == string.Empty)
            {
                //Icon1 toggle
                ExportDirAsterisk.Visibility = Visibility.Visible;
                filled = false;
            }
            if (!filled)
            {
                return;
            }
            // Capture the values entered by the user
            Result.MachineName = MachineNameTextBox.Text;
            Result.Id = int.TryParse(IDTextBox.Text, out var id) ? id : 0;
            Result.Location = LocationTextBox.Text;
            Result.ExportLocation = ExportDirectoryTextBox.Text;
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
                ExportDirectoryTextBox.Text = dialog.FolderName;
            }
        }
    }
}
