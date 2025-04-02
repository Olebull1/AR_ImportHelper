using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using AR_ImportHelper.Commands;

namespace AR_ImportHelper.Models
{
    //public class MainViewModel : ViewModelBase
    //{
    //    private ICommand _navigateCommand;
    //    private string _currentPage;

    //    // Property to hold the current page name (could be any type, string or enum)
    //    public string CurrentPage
    //    {
    //        get { return _currentPage; }
    //        set
    //        {
    //            if (_currentPage != value)
    //            {
    //                _currentPage = value;
    //                OnPropertyChanged(nameof(CurrentPage)); // Notify the View of the change
    //            }
    //        }
    //    }

    //    // Command for navigation
    //    public ICommand NavigateCommand
    //    {
    //        get
    //        {
    //            return _navigateCommand ??= new RelayCommand<string>(Navigate);
    //        }
    //    }

    //    // Navigate method for changing pages/views
    //    private void Navigate(string page)
    //    {
    //        CurrentPage = page; // Change the current page
    //    }
    //}
}
