using System;
using System.Windows.Media.Imaging;

namespace HighwayToHell.GUI.Service
{
    public class ImageContainer
    {
        private static ImageContainer _insctnace;
        private BitmapImage _evilSkin;
        private BitmapImage _normalSkin;
        private BitmapImage _goodSkin;

        private ImageContainer() { }

        public static ImageContainer GetInstance()
        {
            return _insctnace ?? (_insctnace = new ImageContainer());
        }

        public BitmapImage GetPersonSkin(double hellCount, double heavCount)
        {
            if (heavCount >= 50)
            {
                return GetGoodSkin();
            }
            return hellCount >= 50 ? GetEvilSkin() : GetNormalSkin();
        }

        private BitmapImage GetGoodSkin()
        {
            return _goodSkin ??
                   (_goodSkin =
                       new BitmapImage(new Uri("pack://application:,,,/Resources/Good.gif",
                           UriKind.Absolute)));
        }
        private BitmapImage GetEvilSkin()
        {
            return _evilSkin ??
                   (_evilSkin =
                       new BitmapImage(new Uri("pack://application:,,,/Resources/Evil.gif",
                           UriKind.Absolute)));
        }
        private BitmapImage GetNormalSkin()
        {
            return _normalSkin ??
                   (_normalSkin =
                       new BitmapImage(new Uri("pack://application:,,,/Resources/Normal.gif",
                           UriKind.Absolute)));
        }
    }
}
