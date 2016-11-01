using System.Collections.Generic;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Dto
{
    public class PersonDto : IDto
    {
        private readonly int _id;

        public PersonDto(int id, string name, string surname, List<SinDto> sins)
        {
            _id = id;
            Name = name;
            Surname = surname;
            Sins = sins;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public List<SinDto> Sins { get; private set; }

        public int Id
        {
            get { return _id; }
        }
    }
}
