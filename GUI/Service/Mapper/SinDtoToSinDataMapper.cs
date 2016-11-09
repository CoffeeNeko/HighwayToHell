using System;
using HighwayToHell.GUI.Interface;
using HighwayToHell.Repository.Interface;
using HighwayToHell.Repository.Dto;
using HighwayToHell.GUI.Model;

namespace HighwayToHell.GUI.Service.Mapper
{
    class SinDtoToSinDataMapper : GenericAbstractMapper<SinDto>
    {
        protected override IData MapDataFrom(SinDto dto)
        {
            return new SinData(dto.Description, dto.Name)
            {
                Dto = dto
            };
        }
    }
}
