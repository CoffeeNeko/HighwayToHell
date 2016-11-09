using System;
using HighwayToHell.GUI.Interface;
using HighwayToHell.Repository.Interface;
using HighwayToHell.Repository.Dto;
using HighwayToHell.GUI.Model;

namespace HighwayToHell.GUI.Service.Mapper
{
    class PersonDtoToPersonDataMapper : GenericAbstractMapper<PersonDto>
    {
        public Func<IDto, IData> GetSinDataOfDto;

        public PersonDtoToPersonDataMapper(Func<IDto, IData> sinFunction)
        {
            GetSinDataOfDto = sinFunction;
        }

        protected override IData MapDataFrom(PersonDto dto)
        {

            PersonData data = new PersonData(dto.Name, dto.Surname)
            {
                dto = dto
            };

            foreach (var sin in dto.Sins)
            {
                IData sinData = GetSinDataOfDto(sin);
                data.Sins.Add((SinData) sinData);
            }
            return data;
        }
    }
}
