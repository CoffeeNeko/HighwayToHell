using HighwayToHell.GUI.Interface;
using HighwayToHell.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToHell.GUI.Service.Mapper
{
    public abstract class GenericAbstractDataMapper<TDto> : IMapper
        where TDto : class, IDto
    {
        public IData MapDataFrom(IDto dto)
        {
            return dto.GetType() == typeof(TDto) ? MapDataFrom(dto as TDto) : null;
        }

        protected abstract IData MapDataFrom(TDto dto);

    }
}
