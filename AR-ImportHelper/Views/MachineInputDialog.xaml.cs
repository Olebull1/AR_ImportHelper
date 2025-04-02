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
    /// Interaction logic for MachineInputDialog.xaml
    /// </summary>
    public partial class MachineInputDialog : Window
    {
        public Machines Result { get; private set; }
        public bool IsConfirmed { get; private set; }

        public MachineInputDialog()
        {
            InitializeComponent();
            Result = new Machines();  // Initialize with an empty Machine object
            IsConfirmed = false;     // Default to false
        }

        // When OK is clicked, populate the Result property and set IsConfirmed to true
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Capture the values entered by the user
            Result.MachineName = MachineNameTextBox.Text;
            Result.Id = int.TryParse(IdTextBox.Text, out var id) ? id : 0;
            Result.Location = LocationTextBox.Text;
            Result.ExportLocation = ExportLocationTextBox.Text;

            // Set confirmation flag to true
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
    }
}
