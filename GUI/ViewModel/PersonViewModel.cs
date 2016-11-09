using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service;

namespace HighwayToHell.GUI.ViewModel
{
    public class PersonViewModel : ViewModelAbstractBase
    {
        public Command ClosingCommand { get; private set; }

        public Command AbortCommand { get; private set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        /// <summary>
        /// Initializes a new instance of the PersonViewModel class.
        /// </summary>
        public PersonViewModel()
        {
            ClosingCommand = new Command(AddPerson);
            AbortCommand = new Command(Abort);
            UpdateElements.Add("Name");
            UpdateElements.Add("Surname");
        }

        private static void Abort()
        {
            IsPopUpActivated = false;
        }
        private static void Close()
        {
            Abort();
            PersonView.Close();
        }

        private void AddPerson()
        {
            var person = new PersonData(Name, Surname);
            Data.Persons.Add(person);
            Name = string.Empty;
            Surname = string.Empty;
            SavePersonsToDB();
            Update();
            Close();
        }
    }
}