using System.Collections.Generic;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Dto
{
    public class SinDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
