using System.Collections.Generic;
using HighwayToHell.GUI.Model;
using HighwayToHell.GUI.Service.Mapper;
using HighwayToHell.Repository.Dto;

namespace HighwayToHell.GUI.Service
{
    class ViewModelDataBuilder
    {
        private readonly DtoMapperFactory _dtoMapperFactory;

        public ViewModelDataBuilder()
        {
            _dtoMapperFactory = new DtoMapperFactory();
        }

        public void AddPersonDtoList(IEnumerable<PersonDto> personDtoList)
        {

        }

        public void AddSinDtoList(IEnumerable<SinDto> sinDtoList)
        {

        }

        public ViewModelData BuildViewModelData()
        {
            return new ViewModelData();
        }
    }
}
