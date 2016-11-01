using System.Collections.Generic;
using HighwayToHell.Repository.Dto;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Service
{
    class Repository : IRepository
    {
        public List<PersonDto> GetAllPersons()
        {
            throw new System.NotImplementedException();
        }

        public List<SinDto> GetAllSins()
        {
            throw new System.NotImplementedException();
        }

        public void AddSin(SinDto sin)
        {
            throw new System.NotImplementedException();
        }

        public void AddPerson(PersonDto person)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSin(SinDto sin)
        {
            throw new System.NotImplementedException();
        }

        public void RemovePerson(PersonDto person)
        {
            throw new System.NotImplementedException();
        }
    }
}
