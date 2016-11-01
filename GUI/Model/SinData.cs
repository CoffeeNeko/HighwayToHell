using HighwayToHell.GUI.Interface;

namespace HighwayToHell.GUI.Model
{
    public class SinData : IData
    {
        public string Description { get; private set; }

        public SinData(string description)
        {
            Description = description;
        }
    }
}
