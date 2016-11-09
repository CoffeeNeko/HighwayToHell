using HighwayToHell.GUI.Interface;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.GUI.Model
{
    public class SinData : IData
    {
        public string Description { get; private set; }
        public string Name { get; private set; }
        public IDto Dto { get; set; }
        public SinData(string description, string name)
        {
            Description = description;
            Name = name;
        }
    }
}
