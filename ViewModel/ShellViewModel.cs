using GalaSoft.MvvmLight;
using BingImageSearchApp.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace BingImageSearchApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ShellViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged("WelcomeTitle");
            }
        }

        /// <summary>
        /// Initializes a new instance of the ShellViewModel class.
        /// </summary>
        public ShellViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        private ICommand _myCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand MyCommand
        {
            get
            {
                return _myCommand
                    ?? (_myCommand = new RelayCommand<object>(this.ExecuteTestCommand));
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private void ExecuteTestCommand(object param)
        {
            this.WelcomeTitle = param.ToString();
        }
    }
}