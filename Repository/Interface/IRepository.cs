using System.Collections.Generic;
using HighwayToHell.Repository.Dto;

namespace HighwayToHell.Repository.Interface
{
    public interface IRepository
    {
        List<PersonDto> GetAllPersons();
        List<SinDto> GetAllSins();
        void AddSin(SinDto sin);
        void AddPerson(PersonDto person);
        void RemoveSin(SinDto sin);
        void RemovePerson(PersonDto person);
    }
}