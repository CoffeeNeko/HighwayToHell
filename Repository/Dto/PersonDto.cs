using System.Collections.Generic;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Dto
{
    public class PersonDto : IDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<SinDto> Sins { get; set; }

        public int Id { get; set; }
    }
}
