using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Dto
{
    public class SinDto : IDto
    {
        private readonly int _id;

        public SinDto(int id, string description)
        {
            _id = id;
            Description = description;
        }

        public string Description { get; private set; }

        public int Id
        {
            get { return _id; }
        }
    }
}
