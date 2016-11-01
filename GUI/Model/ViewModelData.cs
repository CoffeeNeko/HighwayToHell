using System.Collections.Generic;

namespace HighwayToHell.GUI.Model
{
    public class ViewModelData
    {
        public List<PersonData> Persons { get; private set; }

        public ViewModelData()
        {
            Persons = new List<PersonData>();
        }
    }
}
