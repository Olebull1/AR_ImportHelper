using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_ImportHelper.Models
{
    public class Locations
    {
        public string RoomName { get; set; }
        public string CrystalScannerImportLocation { get; set; }
        public Locations() 
        {
            RoomName = string.Empty;
            CrystalScannerImportLocation = string.Empty;
        }
        public Locations(string roomName, string crystalScannerImportLocation)
        {
            RoomName = roomName;
            CrystalScannerImportLocation = crystalScannerImportLocation;
        }
    }
}
