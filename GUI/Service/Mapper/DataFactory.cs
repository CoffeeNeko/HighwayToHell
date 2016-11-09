using HighwayToHell.GUI.Interface;
using HighwayToHell.Repository.Interface;
using System.Collections.Generic;

namespace HighwayToHell.GUI.Service.Mapper
{

    class DataFactory
    {
        private List<IMapper> _mappers;

        public DataFactory()
        {
            _mappers = new List<IMapper>();
        }

        public void RegisterMapper(IMapper mapper)
        {
            _mappers.Add(mapper);
        }

        public IData GetDtoToDataMapper(IDto dto)
        {
            IData data = null;
            foreach (var mapper in _mappers)
            {
                data = mapper.MapDtoToData(dto);
            }
            return data;
        }
    }
}
