using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_ImportHelper.Models
{
    internal class ImportList
    {
        public ObservableCollection<Import> Imports;
        public ImportList() 
        {
            Imports = new ObservableCollection<Import>();
        }
    }
}
