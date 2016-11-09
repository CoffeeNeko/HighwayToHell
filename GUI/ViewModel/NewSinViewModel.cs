using System.Collections.Generic;
using System.Windows;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service;

namespace HighwayToHell.GUI.ViewModel
{
    public class NewSinViewModel : ViewModelAbstractBase
    {
        public Command SaveCommand { get; private set; }
        public Command CloseCommand { get; private set; }

        private readonly List<SinData> _sins; 
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public NewSinViewModel()
        {
            _sins = Data.Persons[Index].Sins;
            SaveCommand = new Command(Save);
            CloseCommand = new Command(Close);
            UpdateElements.Add("Name");
            UpdateElements.Add("Description");
        }

        private void Save()
        {
            var sin = new SinData(Description, Name);
            _sins.Add(sin);
            MessageBox.Show("Die Sünde wurde erfolgreich hinzugefügt.");
            Name = string.Empty;
            Description = string.Empty;
            Update();
        }

        private static void Close()
        {
            IsPopUpActivated = false;
            SinView.Close();
        }
    }
}