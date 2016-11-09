using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using HighwayToHell.GUI.Interface;
using HighwayToHell.GUI.Service;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.GUI.Model
{
    public class PersonData : IData
    {
        public List<SinData> Sins { get; set; }
        public string Name { get; private set; }
        public string Surname { get; set; }
        public IDto dto { get; set; }

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
            get { return ImageContainer.GetInstance().GetPersonSkin(HellCount, HeavCount); }
        }

        public PersonData(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Sins = new List<SinData>();
        }
    }
}
