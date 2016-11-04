using System.Threading;
using System.Windows;
using System.Windows.Media;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service;
using HighwayToHell.GUI.View;
using MessageBox = System.Windows.MessageBox;

namespace HighwayToHell.GUI.ViewModel
{
    // ReSharper disable once InconsistentNaming
    public class GUIViewModel : ViewModelAbstractBase
    {
        private readonly ColorCalculator _colorCalculator;

        public bool Active
        {
            get { return !IsPopUpActivated; }
        }
        public Command NextCommand { get; private set; }
        public Command PreCommand { get; private set; }
        public Command AddCommand { get; private set; }
        public Command<SinData> DeleteCommand { get; private set; }
        private PersonData _person;
        public PersonData Person
        {
            set
            {
                if (value.Equals(_person))
                {
                    return;
                }
                _person = value;
                // ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged("BackgroundColor");
                RaisePropertyChanged();
            }
            get { return _person; }
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
            get { return _colorCalculator.GetBackgroundColor(Person.HeavCount, Person.HellCount); }
        }

        public GUIViewModel()
        {
            Index = 0;
            UpdateElements.Add("CanBack");
            UpdateElements.Add("CanNext");
            UpdateElements.Add("Active");
            _colorCalculator = new ColorCalculator(100,255,100);
            NextCommand = new Command(Next);
            PreCommand = new Command(Pre);
            AddCommand = new Command(OpenAdd);
            DeleteCommand = new Command<SinData>(Delete);
            Person = Data.Persons[Index];
        }

        private static void IndexValidation()
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
            ChangePerson();
        }

        private void Pre()
        {
            Index--;
            ChangePerson();
        }

        private void ChangePerson()
        {
            IndexValidation();
            Person = Data.Persons[Index];
            Update();
        }

        private void Delete(SinData data)
        {
            if (data == null)
            {
                return;
            }
            var dialogResult = MessageBox.Show("Wollen Sie wirklich diese Sünde ablegen?", "Entfernen", MessageBoxButton.YesNo);
            if (dialogResult != MessageBoxResult.Yes)
            {
                return;
            }
            Person.Sins.Remove(data);
            PersonUpdate();
        }

        private void PersonUpdate()
        {
            _person = null;
            // ReSharper disable once ExplicitCallerInfoArgument
            RaisePropertyChanged("Person");
            Person = Data.Persons[Index];
        }

        private void OpenAdd()
        {
            var waitThread = new Thread(Wait);
            waitThread.SetApartmentState(ApartmentState.STA);
            IsPopUpActivated = true;
            // ReSharper disable once ExplicitCallerInfoArgument
            Update();
            SinView = new SinView();
            SinView.Show();
            waitThread.Start();
        }

        private void Wait()
        {
            while (IsPopUpActivated)
            {
                Thread.Sleep(500);
            }
            // ReSharper disable once ExplicitCallerInfoArgument
            Update();
            Thread.Sleep(500);
            PersonUpdate(); 
        }
    }
}