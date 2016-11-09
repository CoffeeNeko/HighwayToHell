using System.Collections.Generic;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service;

namespace HighwayToHell.GUI.ViewModel
{
    public class SinChoiceViewModel : ViewModelAbstractBase
    {
        public List<SinData> Sins { get; set; }
        public List<SinData> AllSins { get; private set; }
        public Command<SinData> AddCommand { get; private set; }
        public Command<SinData> RemoveCommand { get; private set; }
        public Command SaveCommand { get; private set; }

        public SinChoiceViewModel()
        {
            Sins = Data.Persons[Index].Sins;
            AddCommand = new Command<SinData>(Add);
            RemoveCommand = new Command<SinData>(Remove);
            SaveCommand = new Command(Save);
            AllSins = new List<SinData>();
            UpdateElements.Add("Sins");
            for (var i = 0; i < 101; i++)
            {
                AllSins.Add(new SinData("SündenText" + i, "Sünde" + i));
            }
        }

        private void Add(SinData data)
        {
            if (data == null)
            {
                return;
            }
            Sins.Add(data);
            SinsUpdate();
        }

        private void Remove(SinData data)
        {
            if (data == null)
            {
                return;
            }
            Sins.Remove(data);
            SinsUpdate();
        }

        private void SinsUpdate()
        {
            var sins = Sins;
            Sins = null;
            Update();
            Sins = sins;
            Update();
        }

        private void Save()
        {
            Data.Persons[Index].Sins = Sins;
            Close();
        }

        private static void Close()
        {
            IsPopUpActivated = false;
            SinView.Close();
        }
    }
}