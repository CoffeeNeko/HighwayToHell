using System.Collections.Generic;
using HighwayToHell.GUI.Interface;

namespace HighwayToHell.GUI.Model
{
    public class PersonData : IData
    {
        public List<SinData> Sins { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; set; }

        public PersonData(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Sins = new List<SinData>();
        }
    }
}
