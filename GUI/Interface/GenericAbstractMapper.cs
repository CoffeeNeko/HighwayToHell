using HighwayToHell.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToHell.GUI.Interface
{
    public abstract class GenericAbstractMapper<TDto> : IMapper where TDto : IDto
    {
        public abstract IData MapDtoToData(IDto dto);

    }
}
