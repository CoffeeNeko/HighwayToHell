using System.Windows.Controls;
using HighwayToHell.GUI.Service;
using HighwayToHell.GUI.View;

namespace HighwayToHell.GUI.ViewModel
{
    public class SinViewModel : ViewModelAbstractBase
    {
        private bool _isNew = true;

        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                if (value == _isNew)
                {
                    return;
                }
                _isNew = value;
                if (value)
                {
                    View = new SinChoice();
                }
                else
                {
                    View = new NewSinView();
                }
                RaisePropertyChanged();
            }
        }

        private UserControl _view = new SinChoice();

        public UserControl View
        {
            get { return _view; }
            private set
            {
                if (value.Equals(_view))
                {
                    return;
                }
                _view = value;
                RaisePropertyChanged();
            }
        }

        public Command ClosingCommand { get; set; }

        public SinViewModel()
        {
            ClosingCommand = new Command(Close);
        }

        private static void Close()
        {
            IsPopUpActivated = false;
        }
    }
}