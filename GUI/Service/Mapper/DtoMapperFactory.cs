using HighwayToHell.GUI.Interface;
using HighwayToHell.GUI.Model;
using HighwayToHell.Repository.Interface;
using System.Collections.Generic;

namespace HighwayToHell.GUI.Service.Mapper
{
    class DtoMapperFactory
    {
        private readonly List<IMapper> _mappers;

        public DtoMapperFactory()
        {
            _mappers = new List<IMapper>();
        }

        private void InitMappers()
        {
            SinDtoToSinDataMapper sinMapper = new SinDtoToSinDataMapper();
            PersonDtoToPersonDataMapper personMapper = new PersonDtoToPersonDataMapper(this.GiveDataOf);

            RegisterFactory(sinMapper);
            RegisterFactory(personMapper);
        }


        public void RegisterFactory(IMapper mapper)
        {
            _mappers.Add(mapper);
        }

        public IData GiveDataOf(IDto dto)
        {
            foreach (var mapper in _mappers)
            {
                var returnData = mapper.MapDataFrom(dto);
                if (returnData != null)
                {
                    FillPersonWithSins(returnData);
                    return returnData;
                }
            }

            return null;
        }

        private void FillPersonWithSins(IData data)
        {

        }
    }
}

