using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToHell.Repository.Interface
{
    public interface IEntityFactory
    {
        IEntity GiveEntityOf(IDto dto);
    }
}
