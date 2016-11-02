using System;
using System.Windows.Media;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service;

namespace HighwayToHell.GUI.ViewModel
{
    // ReSharper disable once InconsistentNaming
    public class GUIViewModel : ViewModelAbstractBase
    {
        public int Index { get; set; }
        private const int DefaultRed = 100;
        private const int DefaultGreen = 255;
        private const int DefaultBlue = 100;
        public Command NextCommand { get; private set; }
        public Command PreCommand { get; private set; }
        public PersonData Person
        {
            get
            {
                IndexValidation();
                return Data.Persons[Index];
            }
        }

        public bool CanBack
        {
            get
            {
                return Index > 0;
            }
        }

        public bool CanNext
        {
            get
            {
                return Index < Data.Persons.Count - 1;
            }
        }

        public Color BackgroundColor
        {
            get
            {
                if (Person.HeavCount > 0)
                {
                    return CalcColor(50, 50, 255, Person.HeavCount);
                }
                return Person.HellCount > 0 ? CalcColor(255, 125, 50, Person.HellCount) : CalcColor(DefaultRed, DefaultGreen, DefaultBlue, 0);
            }
        }

        public GUIViewModel()
        {
            Index = 0;
            NextCommand = new Command(Next);
            PreCommand = new Command(Pre);
            for (var i = 0; i < 100; i++)
            {
                Data.Persons.Add(CreatePerson(i));
            }
        }

        private static PersonData CreatePerson(int index)
        {
            var person = new PersonData("name:"+index, "surname:" + index);
            for (var i = 0; i < index; i++)
            {
                person.Sins.Add(new SinData("SündenText" + i, "Sünde" + i));
            }
            return person;
        }

        private void IndexValidation()
        {
            if (Index >= Data.Persons.Count)
            {
                Index = Data.Persons.Count - 1;
            }
            if (Index < 0)
            {
                Index = 0;
            }
        }

        private void Next()
        {
            Index++;
            UpdateView();
        }

        private void Pre()
        {
            Index--;
            UpdateView();
        }

        private void UpdateView()
        {
            RaisePropertyChanged("Person");
            RaisePropertyChanged("CanBack");
            RaisePropertyChanged("CanNext");
            RaisePropertyChanged("BackgroundColor");
        }

        private static Color CalcColor(int red, int green, int blue, double count)
        {
            count = count*2;
            var redFeet = red/DefaultRed;
            var greenFeet = green/DefaultGreen;
            var blueFeet = blue/DefaultBlue;
            var redByte = Convert.ToByte(redFeet * count);
            var greenByte = Convert.ToByte(greenFeet * count);
            var blueByte = Convert.ToByte(blueFeet * count);
            return Color.FromRgb(redByte, greenByte, blueByte);
        }
    }
}