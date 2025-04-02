using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_ImportHelper.Models
{
    public class Machines : INotifyPropertyChanged
    {
        private ObservableCollection<string> _files;
        public string MachineName { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public string ExportLocation { get; set; }

        // Private field for Files
        public ObservableCollection<string> Files
        {
            get => _files;
            set
            {
                if (_files != value)
                {
                    _files = value;
                    OnPropertyChanged(nameof(Files));  // Notify the UI that Files has changed
                }
            }
        }
        public Machines() 
        {
            MachineName = string.Empty;
            Id = 0;
            Location = string.Empty;
            ExportLocation = string.Empty;
            Files = new ObservableCollection<string>();
        }
        public Machines(string name, int id, string location, string exportLoc) 
        {
            MachineName = name;
            Id = id;
            Location = location;
            ExportLocation = exportLoc;
            Files = new ObservableCollection<string>();
        }

        // Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
