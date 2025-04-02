using AR_ImportHelper.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using AR_ImportHelper.Controllers;
using System.Threading;
using System.Collections;
using System.Collections.ObjectModel;

namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for MachineMonitor.xaml
    /// </summary>
    public partial class MachineMonitor : UserControl
    {
        private DirectoryMonitor _monitor;
        public MachineMonitor(Machines machine)
        {
            DataContext = machine;

            _monitor = new DirectoryMonitor(machine.ExportLocation);
            _monitor.OnNewFilesDetected += files =>
            {
                Dispatcher.Invoke(() =>
                {
                    machine.Files = new ObservableCollection<string>(files);
                });
            };

            _monitor.StartMonitoring();

            InitializeComponent();
        }
    }
}
