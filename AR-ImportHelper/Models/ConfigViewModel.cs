using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using AR_ImportHelper.Views;
using AR_ImportHelper.Constants;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AR_ImportHelper.Models
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
        // The single instance of the ConfigViewModel class
        private static ConfigViewModel _instance;

        // Public string array property for ImportDirs
        public ObservableCollection<Machines> Machines { get; set; }
        public ObservableCollection<Locations> ExamRooms { get; set; }

        // Private constructor to prevent instantiation from outside
        private ConfigViewModel()
        {
            //ExamRooms = new ObservableCollection<Locations>
            //{
            //    new Locations { RoomName = "Exam 1", CrystalScannerImportLocation = @"C:\Path\To\Scanner1" },
            //    new Locations { RoomName = "Exam 2", CrystalScannerImportLocation = @"C:\Path\To\Scanner2" },
            //    new Locations { RoomName = "Exam 3", CrystalScannerImportLocation = @"C:\Path\To\Scanner3" },
            //    new Locations { RoomName = "Exam 4", CrystalScannerImportLocation = @"C:\Path\To\Scanner4" },
            //};

            //Machines = new ObservableCollection<Machines>
            //{
            //    new Machines { MachineName = "Machine A", Id = 1, Location = "Location 1", ExportLocation = @"C:\Path\To\Export1" },
            //    new Machines { MachineName = "Machine B", Id = 2, Location = "Location 2", ExportLocation = @"C:\Path\To\Export2" },
            //    new Machines { MachineName = "Machine C", Id = 3, Location = "Location 3", ExportLocation = @"C:\Path\To\Export3" },
            //    new Machines { MachineName = "Machine D", Id = 4, Location = "Location 4", ExportLocation = @"C:\Path\To\Export4" },
            //    new Machines { MachineName = "Machine E", Id = 4, Location = "Location 5", ExportLocation = @"C:\Path\To\Export5" }
            //};
            Console.Write("Filler");
            getConfigModelFromJson();
        }

        // Use JsonConstructor for the parameterized constructor, this avoids problems with the private singleton constructor, it does make the singleton less safe.
        [JsonConstructor]
        private ConfigViewModel(ObservableCollection<Machines> machines, ObservableCollection<Locations> examRooms)
        {
            Machines = machines;
            ExamRooms = examRooms;
        }

        // Public property to access the single instance of ConfigViewModel
        public static ConfigViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigViewModel();
                }
                return _instance;
            }
        }
        public void saveConfigToFile()
        {
            // Serialize the object to a JSON string
            string jsonString = JsonSerializer.Serialize(this);

            // Check if the folder exists
            if (!Directory.Exists(Constants.Constants.cfgDir))
            {
                Directory.CreateDirectory(Constants.Constants.cfgDir);
            }
            // Check if the file exists
            if (!File.Exists(Constants.Constants.cfgFilePath))
            {
                File.Create(Constants.Constants.cfgFilePath);
            }
            try
            {
                // Write the JSON string to the file
                File.WriteAllText(Constants.Constants.cfgFilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
        public void getConfigModelFromJson()
        {
            // Check if the file exists
            if (File.Exists(Constants.Constants.cfgFilePath))
            {

                // Read the JSON string from the file
                string jsonString = File.ReadAllText(Constants.Constants.cfgFilePath);

                // Deserialize the JSON string back into an object
                var config = JsonSerializer.Deserialize<ConfigViewModel>(jsonString);
                ExamRooms = config.ExamRooms;
                Machines = config.Machines;
            }
            else
            {
                Console.WriteLine($"The file {Constants.Constants.cfgFilePath} does not exist.");
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Method to raise the PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
