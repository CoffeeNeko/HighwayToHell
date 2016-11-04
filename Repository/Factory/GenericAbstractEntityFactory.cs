using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToHell.Repository.Interface;

namespace HighwayToHell.Repository.Factory
{
    public abstract class GenericAbstractEntityFactory<TDto> : IEntityFactory
        where TDto : class, IDto
    {
        public IEntity GiveEntityOf(IDto dto)
        {
            return dto.GetType() == typeof(TDto) ? MapEntityFrom(dto as TDto) : null;
        }

        protected abstract IEntity MapEntityFrom(TDto dto);
    }
}
