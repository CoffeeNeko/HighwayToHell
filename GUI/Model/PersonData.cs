using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using HighwayToHell.GUI.Interface;

namespace HighwayToHell.GUI.Model
{
    public class PersonData : IData
    {
        public List<SinData> Sins { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; set; }
        private static BitmapImage _evilSkin;
        private static BitmapImage _normalSkin;
        private static BitmapImage _goodSkin;

        public double HeavCount
        {
            get
            {
                if (Sins == null)
                {
                    Sins = new List<SinData>();
                }
                return Convert.ToDouble(50 - Sins.Count);
            }
        }
        public double HellCount
        {
            get
            {
                if (HeavCount > 0)
                {
                    return 0;
                }
                if (Sins == null)
                {
                    Sins = new List<SinData>();
                }
                return Convert.ToDouble(Sins.Count - 50);
            }
        }

        public BitmapImage Skin
        {
            get
            {
                if (HeavCount > 0)
                {
                    return GetGoodSkin();
                }
                return HellCount > 0 ? GetEvilSkin() : GetNormalSkin();
            }
        }

        private static BitmapImage GetGoodSkin()
        {
            return _goodSkin ??
                   (_goodSkin =
                       new BitmapImage(new Uri("pack://application:,,,/Resources/Minutensprunguhr_animiert.gif",
                           UriKind.Absolute)));
        }
        private static BitmapImage GetEvilSkin()
        {
            return _evilSkin ??
                   (_evilSkin =
                       new BitmapImage(new Uri("pack://application:,,,/Resources/Minutensprunguhr_animiert.gif",
                           UriKind.Absolute)));
        }
        private static BitmapImage GetNormalSkin()
        {
            return _normalSkin ??
                   (_normalSkin =
                       new BitmapImage(new Uri("pack://application:,,,/Resources/Minutensprunguhr_animiert.gif",
                           UriKind.Absolute)));
        }

        public PersonData(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Sins = new List<SinData>();
        }
    }
}
