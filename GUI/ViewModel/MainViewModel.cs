using System.Windows.Controls;
using HighwayToHell.GUI.View;

namespace HighwayToHell.GUI.ViewModel
{
    public class MainViewModel : ViewModelAbstractBase
    {
        public UserControl View
        {
            get
            {
                if (Main.GetVersion() == Main.Version.White)
                {
                    return new GUIViewWhite();
                }
                return new GUIViewBlack();
            }
        }
    }
}