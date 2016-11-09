using System.Collections.Generic;
using HighwayToHell.Repository.Dto;

namespace HighwayToHell.Repository.Interface
{
    public interface IRepository
    {
        List<PersonDto> GetAllPersons();
        List<SinDto> GetAllSins();
        List<PersonDto> GetAllPersonsOfSin(SinDto sin);
        void AddOrUpdateSin(SinDto sin);
        void AddOrUpdatePerson(PersonDto person);
        void RemoveSin(SinDto sin);
        void RemovePerson(PersonDto person);
    }
}