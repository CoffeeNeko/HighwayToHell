using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Dto
{
    public class SinDto : IDto
    {
        private readonly int _id;

        public SinDto(int id, string description, string name)
        {
            _id = id;
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Id
        {
            get { return _id; }
        }
    }
}
